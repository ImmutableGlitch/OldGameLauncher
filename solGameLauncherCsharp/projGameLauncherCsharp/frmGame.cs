using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projGameLauncherCsharp {
    public partial class frmGame : Form {
        bool ButtonsEnabled = true;
        bool fullscreenForm = false;

        List<Game> gameCollection = new List<Game>();

        string[,] OldCollection = new string[3,6]; // row and column wrong orientation

        // Location of game collection data
        string NameTextfile = "Name.txt",
               LocationTextfile = "Loc.txt",
               PictureTextfile = "Pic.txt";

        public frmGame() {
            InitializeComponent();
        }

        private void FrmGame_Load(object sender,EventArgs e) {
            BtnEnlarge_Click(null,null); // Begin fullscreen


            //TODO: load previous colour setting that was saved, override paint method
            //p.Graphics.Clear(Color.FromArgb(37, 37, 37)); //Example paint choice
            BackColor = Color.FromArgb(37,37,37);
            panelGames.BackColor = Color.FromArgb(49,49,49);

            //LoadPreviousSession();
            CallGenerate();
        }

        private void CenterPanels() {
            // Repetition
            panelAddGame.Left = (panelGames.Width - panelAddGame.Width) / 2 + panelGames.Left;
            panelAddGame.Top = (panelGames.Height - panelAddGame.Height) / 2 + panelGames.Top;

            panelEditGame.Left = (panelGames.Width - panelEditGame.Width) / 2 + panelGames.Left;
            panelEditGame.Top = (panelGames.Height - panelEditGame.Height) / 2 + panelGames.Top;

            panelOptions.Left = (panelGames.Width - panelOptions.Width) / 2 + panelGames.Left;
            panelOptions.Top = (panelGames.Height - panelOptions.Height) / 2 + panelGames.Top;
        }

        #region Important Methods

        public void LoadPreviousSession() {
            //reset pointer and array
            Game.ResetNumberOfGames();
            Array.Clear(OldCollection,0,OldCollection.Length);

            if (File.Exists(NameTextfile) && File.Exists(LocationTextfile) && File.Exists(PictureTextfile)) {
                //Read all lines of the text files
                List<string> listOfNames = new List<string>(File.ReadAllLines(NameTextfile));
                List<string> listOfLocations = new List<string>(File.ReadAllLines(LocationTextfile));
                List<string> listOfPictures = new List<string>(File.ReadAllLines(PictureTextfile));

                //if text files are smaller than array
                if (listOfNames.Count < OldCollection.Length &&
                    listOfLocations.Count < OldCollection.Length &&
                    listOfPictures.Count < OldCollection.Length) {

                    //store name of games
                    foreach (string name in listOfNames) {
                        OldCollection[0,Game.numberOfGames] = name;
                        Game.numberOfGames++;
                    }
                    //store location of games
                    foreach (string location in listOfLocations) {
                        OldCollection[1,Game.numberOfGames] = location;
                        Game.numberOfGames++;
                    }
                    //store picture of games
                    foreach (string picture in listOfPictures) {
                        OldCollection[2,Game.numberOfGames] = picture;
                        Game.numberOfGames++;
                    }
                }
                else {
                    do {
                        OldCollection = ResizeArray(OldCollection);
                        //XOR addition below needs tested
                    } while ((listOfNames.Count | listOfLocations.Count | listOfPictures.Count) < OldCollection.Length);

                    LoadPreviousSession();
                }
            }//if Files exists
        }

        public void SaveCurrentSession() {
            if (File.Exists("Name.txt")) File.Delete("Name.txt");
            if (File.Exists("Loc.txt")) File.Delete("Loc.txt");
            if (File.Exists("Pic.txt")) File.Delete("Pic.txt");

            if (Game.numberOfGames >= 0) {
                using (StreamWriter sw = new StreamWriter("Name.txt")) {
                    for (int i = 0; i < Game.numberOfGames; i++) {
                        sw.WriteLine(OldCollection[0,i]);
                    }
                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter("Loc.txt")) {
                    for (int i = 0; i < Game.numberOfGames; i++) {
                        sw.WriteLine(OldCollection[1,i]);
                    }
                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter("Pic.txt")) {
                    for (int i = 0; i < Game.numberOfGames; i++) {
                        sw.WriteLine(OldCollection[2,i]);
                    }
                    sw.Close();
                }
            }
        }

        public void ExtractGamesFromPath(string path) {
            DirectoryInfo dir = new DirectoryInfo(path);

            try {
                foreach (FileInfo f in dir.GetFiles()) {
                    if (Game.numberOfGames == OldCollection.GetLength(1)) {
                        OldCollection = ResizeArray(OldCollection);
                    }

                    OldCollection[1,Game.numberOfGames] = f.FullName;

                    Icon.ExtractAssociatedIcon(f.FullName).ToBitmap().Save(Game.numberOfGames.ToString() + ".bmp");
                    Game.numberOfGames++;
                }

            }
            catch (System.Exception ex) {
                MessageBox.Show(ex.GetType() + ": " + ex.Message + " Error extracting games");
            }
        }

        string AddSpacesToSentence(string text) {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(Char.ToUpper(text[0]));
            for (int i = 1; i < text.Length; i++) {
                //If this character is uppercase and the previous char isn't upper or a space
                //Then begin a new word
                if (char.IsUpper(text[i]) && text[i - 1] != ' ' && char.IsLower(text[i - 1])) {
                    newText.Append(' ');
                }
                //would change Battlefield3 to Battlefield 3
                else if (char.IsNumber(text[i]) && char.IsLower(text[i - 1])) {
                    newText.Append(' ');
                }
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        private void PanelGames_DragDrop(object sender,DragEventArgs e) {
            // TODO: Break this method up
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop,false);

            foreach (string currentFile in droppedFiles) {
                string location = "";
                //TODO: Check if the item is url
                if (currentFile.EndsWith(".lnk")) {
                    try {
                        //Grab target path by creating a shortcut file
                        if (File.Exists(currentFile)) {
                            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                            IWshRuntimeLibrary.IWshShortcut link = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(currentFile);
                            location = link.TargetPath;
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message + " - Unable to find target path");
                    }
                }
                else {
                    location = currentFile;
                }

                // Resize array if needed
                if (Game.numberOfGames == OldCollection.GetLength(1)) {
                    OldCollection = ResizeArray(OldCollection);
                }

                // Select only the filename
                string fileName = Path.GetFileNameWithoutExtension(location);

                // Remove 'Shortcut' text if exists
                if (fileName.Contains("Shortcut")) {
                    int startPoint = fileName.LastIndexOf('.');
                    fileName = fileName.Remove(startPoint,fileName.Length - startPoint);
                }

                // Store new data
                OldCollection[0,Game.numberOfGames] = AddSpacesToSentence(fileName);
                OldCollection[1,Game.numberOfGames] = location;
                string iconPath = Directory.GetCurrentDirectory() + @"\icons\" + OldCollection[0,Game.numberOfGames] + ".bmp"; //give filename to bmp
                OldCollection[2,Game.numberOfGames] = iconPath;

                try {
                    //TODO - stores icon cache, will be redundant once images/steamgrids functionality replace it
                    //delete existing icon may not be needed, file would simply be overwritten
                    //File.Delete(iconPath);

                    //Extract icon and save it at iconPath
                    Icon.ExtractAssociatedIcon(location).ToBitmap().Save(iconPath);
                }
                catch (Exception ex) {
                    //TODO - Fix this exception
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show("Unable to extract icon" + ex.Message);
                }

                Game.numberOfGames++;

                /* TODO:
                 * Scan through code below, used to download images from theGamesDB.net
                 * Use Google API or custom web parsing?
                 */
                #region editMe

                //string URLforID = "http://thegamesdb.net/search/?searchview=table&string="
                //+ arrNameLocPic[0,  Game.numberOfGames]
                //+ "&function=Search&sortBy=&limit=20&page=1&updateview=yes&stringPlatform=";

                //string ID = "";

                //try
                //{
                //    HtmlWeb hw = new HtmlWeb();

                //    HtmlAgilityPack.HtmlDocument doc = hw.Load(URLforID);


                //    HtmlNode link = doc.DocumentNode.SelectSingleNode("//*[@id=\"listtable\"]/tr[2]/td[1]");
                //    ID = link.InnerHtml;

                //    //MessageBox.Show(ID);
                //}
                //catch (Exception ex)
                //{
                //    //MessageBox.Show("Game not found within database!");
                //}

                //try
                //{
                //    string URL2 = "http://thegamesdb.net/api/GetArt.php?id=" + ID;
                //    int pointer = 1;
                //    //Process.Start(URL);

                //    XmlTextReader reader = new XmlTextReader(URL2);

                //    // Skip non-significant whitespace  
                //    reader.WhitespaceHandling = WhitespaceHandling.Significant;

                //    string baseLink = "http://thegamesdb.net/banners/";
                //    string image = "";

                //    WebClient webClient = new WebClient();

                //    //while (reader.Read() && !ready)
                //    while (reader.Read())
                //    {
                //        if (reader.Value.Contains("graphical"))
                //        {
                //            //Form2 foo = new Form2();
                //            //foo.showLink(baseLink + reader.Value);
                //            //foo.Show();

                //            image = reader.Value;

                //            webClient.DownloadFile(baseLink + image, arrNameLocPic[0,  Game.numberOfGames] + "_" + pointer + ".jpg");
                //            arrNameLocPic[2,  Game.numberOfGames] = arrNameLocPic[0,  Game.numberOfGames] + "_" + pointer++ + ".jpg";
                //        }
                //        else if (reader.Value.Contains("clearlogo"))
                //        {
                //            //Form2 foo = new Form2();
                //            //foo.showLink(baseLink + reader.Value);
                //            //foo.Show();

                //            image = reader.Value;

                //            webClient.DownloadFile(baseLink + image, arrNameLocPic[0,  Game.numberOfGames] + "_" + pointer + ".jpg");
                //            arrNameLocPic[2,  Game.numberOfGames] = arrNameLocPic[0,  Game.numberOfGames] + "_" + pointer++ + ".jpg";
                //        }
                //    }//while

                //    if (image == "")
                //    {
                //        //MessageBox.Show("Sorry no images found.");
                //        arrNameLocPic[2,  Game.numberOfGames] =  Game.numberOfGames.ToString() + ".bmp";
                //    }


                //}
                //catch (Exception ex)
                //{
                //    //MessageBox.Show("Could not download image!");
                //}
                #endregion

            }

            SaveCurrentSession();

            panelGames.Controls.Clear();

            CallGenerate();
        }

        private void PaintBorderlessGroupBox(object sender,PaintEventArgs p) {
            GroupBox box = (GroupBox)sender;

            //Borderless
            //p.Graphics.Clear(box.Parent.BackColor);

            //GROUPBOX TITLE COLOUR NEEDS TO BE UPDATED ALONG WITH FLO COLOUR
            p.Graphics.Clear(Color.FromArgb(37,37,37));
            //p.Graphics.Clear(Color.FromArgb(3, 32, 53));
            p.Graphics.DrawString(box.Text,box.Font,Brushes.White,0,0);
            //p.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
        }

        private void Generate(int tagIndex) {
            PictureBox btn = new PictureBox();
            btn.Click += new EventHandler(GameClickEvent);
            btn.Tag = tagIndex;
            btn.BackColor = Color.FromArgb(68,68,68); //grayish TODO: grab more rgb colours, also have setting to use either icon or pic

            btn.Width = 230;
            btn.Height = 108;
            //btn.Margin = new Padding(0, 0, 60, 0); //left top right bottom
            //btn.Margin = new Padding(0, 54, 0, 60); //left top right bottom
            btn.Size = new System.Drawing.Size(230,108);

            try {
                Debug.WriteLine("Array Items: {0:G}/{1:G}.",Game.numberOfGames,OldCollection.GetUpperBound(1));
                //Image pic = Image.FromFile(arrNameLocPic[2 , tagIndex]);
                Image pic = ShellFile.FromFilePath(OldCollection[1,tagIndex]).Thumbnail.LargeIcon.ToBitmap();
                btn.Image = pic;
                if (pic.Height > 32) {
                    btn.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else {
                    btn.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                pic = null;
            }
            catch (Exception ex) {
                Debug.Write(ex.GetType() + ": " + ex.Message);
                //MessageBox.Show("Images not found for " + arrNameLocPic[0, tagIndex]);
                btn.Image = null;

            }

            Label buttonLabel = new Label();
            buttonLabel.Width = 230;
            buttonLabel.Text = OldCollection[0,tagIndex];
            buttonLabel.Font = new System.Drawing.Font("Minecraftia",6f);
            buttonLabel.ForeColor = Color.White;
            buttonLabel.Margin = new Padding(0,54,0,60);

            GroupBox groupBox = new GroupBox();
            groupBox.Paint += PaintBorderlessGroupBox;
            groupBox.Text = OldCollection[0,tagIndex];
            groupBox.ForeColor = Color.White;
            groupBox.Size = new Size(236,125);
            groupBox.Dock = DockStyle.Top;
            panelGames.Controls.Add(groupBox);

            groupBox.Margin = new Padding(55,10,10,25);
            btn.Location = groupBox.DisplayRectangle.Location;
            //btn.Size = new Size(0, 0);
            //btn.AutoSize = true;

            groupBox.Controls.Add(btn);


            //flo.Controls.Add(btn);
            //flo.Controls.Add(buttonLabel);
        }

        public void GameClickEvent(Object sender,EventArgs e) {
            PictureBox btn = (PictureBox)sender;

            frmMenu foo = new frmMenu();
            foo.Show();
            this.Hide();

            try {
                Process.Start(OldCollection[1,(int)btn.Tag]);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.GetType() + ": " + ex.Message + " Invalid game path");
            }
        }

        public void CallGenerate() {
            for (int i = 0; i < Game.numberOfGames; i++) {
                Generate(i);
            }

            lblNumOfGames.Text = "Game Count: " + panelGames.Controls.OfType<PictureBox>().Count().ToString();
        }

        #endregion

        #region Components
        public void ToggleButtons() {
            ButtonsEnabled = !ButtonsEnabled;

            btnAddGame.Enabled = ButtonsEnabled;
            btnEdit.Enabled = ButtonsEnabled;
            btnMenu.Enabled = ButtonsEnabled;
            btnEnlarge.Enabled = ButtonsEnabled;
            btnGameDir.Enabled = ButtonsEnabled;
            panelGames.Enabled = ButtonsEnabled;
        }

        private void FrmGame_MouseEnter(object sender,EventArgs e) {
            panelGames.Focus();
        }

        private void PanelGames_MouseEnter(object sender,EventArgs e) {
            panelGames.Focus();
        }

        private void PanelGames_DragEnter(object sender,DragEventArgs e) {
            e.Effect = DragDropEffects.All;
        }

        private void BtnMenu_MouseEnter(object sender,EventArgs e) {
            btnMenu.Image = Properties.Resources.menuH;
        }

        private void BtnMenu_MouseLeave(object sender,EventArgs e) {
            btnMenu.Image = Properties.Resources.menu;
        }

        private void BtnEnlarge_Click(object sender,EventArgs e) {
            if (!fullscreenForm) {
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(850,478);
                panelGames.Size = new Size(826,419);
                foreach (GroupBox gb in panelGames.Controls) {
                    gb.Margin = new Padding(15);
                }
                btnEnlarge.Location = new Point(766,10);
                btnMenu.Location = new Point(806,10);
                fullscreenForm = !fullscreenForm;
            }
            else {
                this.WindowState = FormWindowState.Maximized;
                //flo.Size = new Size(1256, 659);
                //btnEnlarge.Location = new Point(1186, 6);
                //btnMenu.Location = new Point(1225, 6);
                panelGames.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 24,Screen.PrimaryScreen.WorkingArea.Height - 30);
                btnEnlarge.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 80,6);
                btnMenu.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 40,6);
                fullscreenForm = !fullscreenForm;
            }

            this.Hide();     //provides smooth transition
            CenterPanels();
            this.Show();
        }

        private void BtnEnlarge_MouseEnter(object sender,EventArgs e) {
            btnEnlarge.Image = Properties.Resources.enlargeH;
        }

        private void BtnEnlarge_MouseLeave(object sender,EventArgs e) {
            btnEnlarge.Image = Properties.Resources.enlarge;
        }

        private void BtnEdit_Click(object sender,EventArgs e) {
            panelEditGame.Show();
            ToggleButtons();
            UpdateEditPanel();
        }

        private void BtnEdit_MouseEnter(object sender,EventArgs e) {
            btnEdit.Image = Properties.Resources.editH;
        }

        private void BtnEdit_MouseLeave(object sender,EventArgs e) {
            btnEdit.Image = Properties.Resources.edit;
        }

        private void BtnAddGame_Click(object sender,EventArgs e) {
            panelAddGame.Show();
            ToggleButtons();
        }

        private void BtnAddGame_MouseEnter(object sender,EventArgs e) {
            btnAddGame.Image = Properties.Resources.addH;
        }

        private void BtnAddGame_MouseLeave(object sender,EventArgs e) {
            btnAddGame.Image = Properties.Resources.add;
        }

        private void BtnGameDir_Click(object sender,EventArgs e) {
            try {
                Process.Start(@"E:\Games\Installed");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.GetType() + ": " + ex.Message + " Game Directory not found.");
            }
        }

        private void BtnGameDir_MouseEnter(object sender,EventArgs e) {
            btnGameDir.Image = Properties.Resources.gamesH;
        }

        private void BtnGameDir_MouseLeave(object sender,EventArgs e) {
            btnGameDir.Image = Properties.Resources.games;
        }

        private void BtnCloseAddPanel_Click(object sender,EventArgs e) {
            panelAddGame.Hide();
            ToggleButtons();
        }

        private void BtnCloseEditPanel_Click(object sender,EventArgs e) {
            panelEditGame.Hide();
            ToggleButtons();
        }

        private void BtnCloseAddPanel_MouseEnter(object sender,EventArgs e) {
            btnCloseAddPanel.Image = Properties.Resources.xH;
        }

        private void BtnCloseAddPanel_MouseLeave(object sender,EventArgs e) {
            btnCloseAddPanel.Image = Properties.Resources.x;
        }

        private void BtnCloseEditPanel_MouseEnter(object sender,EventArgs e) {
            btnCloseEditPanel.Image = Properties.Resources.xH;
        }

        private void BtnCloseEditPanel_MouseLeave(object sender,EventArgs e) {
            btnCloseEditPanel.Image = Properties.Resources.x;
        }

        private void BtnDoneAddPanel_Click(object sender,EventArgs e) {
            if (txtName.Text == "" || txtLocation.Text == "") {
                MessageBox.Show("You left fields blank!");
            }
            else {
                //Update Arrays
                OldCollection[0,Game.numberOfGames] = txtName.Text;
                OldCollection[1,Game.numberOfGames] = txtLocation.Text;
                OldCollection[2,Game.numberOfGames] = panelAddGameImage.ImageLocation;

                Game.numberOfGames++;

                //Update text files
                SaveCurrentSession();

                //'Update buttons
                panelGames.Controls.Clear();
                LoadPreviousSession();
                CallGenerate();

                //'Blank the textfields
                txtName.Text = "";
                txtLocation.Text = "";
                panelAddGameImage.Image = null;
                panelAddGameImage.ImageLocation = null;
            }
        }

        private void BtnSaveEditPanel_Click(object sender,EventArgs e) {
            OldCollection[0,cboSelectGame.SelectedIndex] = txtNameEdit.Text;
            OldCollection[1,cboSelectGame.SelectedIndex] = txtLocEdit.Text;
            if (panelEditGameImage.ImageLocation != null) {
                OldCollection[2,cboSelectGame.SelectedIndex] = panelEditGameImage.ImageLocation;
            }

            SaveCurrentSession();
            UpdateEditPanel();
            panelGames.Controls.Clear();
            LoadPreviousSession();
            CallGenerate();
        }

        private void BtnAddImage_Click(object sender,EventArgs e) {
            ofdAddImage.ShowDialog();
        }

        private void OfdAddImage_FileOk(object sender,CancelEventArgs e) {
            panelAddGameImage.ImageLocation = ofdAddImage.FileName;
        }

        private void BtnLocationAdd_Click(object sender,EventArgs e) {
            ofdGameLocAdd.ShowDialog();
        }

        private void BtnEditImage_Click(object sender,EventArgs e) {
            ofdEditImage.ShowDialog();
        }

        private void OfdGameLocEdit_FileOk(object sender,CancelEventArgs e) {
            txtLocEdit.Text = ofdGameLocEdit.FileName;
        }

        private void BtnLocationEdit_Click(object sender,EventArgs e) {
            ofdGameLocEdit.ShowDialog();
        }

        private void OfdEditImage_FileOk(object sender,CancelEventArgs e) {
            panelEditGameImage.ImageLocation = ofdEditImage.FileName;
        }

        private void OfdGameLocAdd_FileOk(object sender,CancelEventArgs e) {
            txtLocation.Text = ofdGameLocAdd.FileName;
        }

        private void BtnDeleteEditPanel_Click(object sender,EventArgs e) {
            if (cboSelectGame.SelectedIndex < Game.numberOfGames) {
                for (int i = cboSelectGame.SelectedIndex; i < Game.numberOfGames; i++) {
                    OldCollection[0,i] = OldCollection[0,i + 1];
                    OldCollection[1,i] = OldCollection[1,i + 1];
                    OldCollection[2,i] = OldCollection[2,i + 1];
                }

                Game.numberOfGames--;
                SaveCurrentSession();
                panelGames.Controls.Clear();
                LoadPreviousSession();
                CallGenerate();
            }

            UpdateEditPanel();
        }

        private void CboSelectGame_SelectedIndexChanged(object sender,EventArgs e) {

            txtNameEdit.Text = OldCollection[0,cboSelectGame.SelectedIndex];
            txtLocEdit.Text = OldCollection[1,cboSelectGame.SelectedIndex];
            try {
                Image pic = Image.FromFile(OldCollection[2,cboSelectGame.SelectedIndex]);
                panelEditGameImage.Image = pic;
                if (pic.Height > 32) {
                    panelEditGameImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else {
                    panelEditGameImage.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                pic = null;
            }
            catch (Exception ex) {
                Debug.Write(ex.Message);
                panelEditGameImage.Image = null;
            }
        }

        private void BtnMenuOptions(object sender,EventArgs e) {
            panelOptions.Show();
            ToggleButtons();
        }

        private void CboOption_SelectedIndexChanged(object sender,EventArgs e) {
            switch (cboOption.Text) {
                case "Games":
                    MessageBox.Show("Gamesssss");
                    //use generate method with game text files
                    break;

                case "Programs":
                    MessageBox.Show("Programsssss");
                    //use generate method with program text files
                    break;

                case "Other":
                    MessageBox.Show("Other");
                    //use text files which holds misc items
                    break;

                default:
                    MessageBox.Show("Selected Nothing?");
                    break;
            }

            panelOptions.Hide();
            ToggleButtons();
        }

        private void FrmGame_Click(object sender,EventArgs e) {
            frmMenu foo = new frmMenu();
            foo.Show();
            this.Hide();
        }

        private void BtnCloseMenu_Click(object sender,EventArgs e) {
            panelOptions.Hide();
            ToggleButtons();
        }

        private void BtnCloseMenu_MouseEnter(object sender,EventArgs e) {
            btnCloseMenu.Image = Properties.Resources.xH;
        }

        private void BtnCloseMenu_MouseLeave(object sender,EventArgs e) {
            btnCloseMenu.Image = Properties.Resources.x;
        }

        private void CboColour_SelectedIndexChanged(object sender,EventArgs e) {
            //Set colour and flow panel layout
            switch (cboColour.SelectedIndex) {
                case 0:
                    //TODO: get Red RGB colour
                    break;

                case 1:
                    this.BackColor = Color.FromArgb(21,71,0);//green
                    panelGames.BackColor = Color.FromArgb(44,108,17);//green
                    break;

                case 2:
                    this.BackColor = Color.FromArgb(3,32,53);//blue
                    panelGames.BackColor = Color.FromArgb(17,53,81);//blue
                    break;

                case 3:
                    this.BackColor = Color.FromArgb(37,37,37);//gray
                    panelGames.BackColor = Color.FromArgb(49,49,49);//gray

                    break;

                default:
                    MessageBox.Show("Pick a colour");
                    break;

            }
        }

        private void FrmGame_FormClosing(object sender,FormClosingEventArgs e) {
            Application.Exit();
        }

        #endregion

        #region Other Methods

        public static string[,] ResizeArray(string[,] x) {
            MessageBox.Show("resizing");
            string[,] increase = new string[3,x.GetLength(1) + 50];
            string[,] backup = x;
            x = increase;
            Array.Copy(backup,x,backup.Length);
            return x;
        }

        public void CenterObjectOnScreen(Control c) {
            c.Top = (this.Height - c.Height) / 2;
            c.Left = (this.Width - c.Width) / 2;
            //lblNumOfGames.Location = new Point((this.Width - lblNumOfGames.Width) / 2 , lblNumOfGames.Location.Y);
        }

        public void PrintArray() {
            String name = "", loc = "", pic = "";

            for (int j = 0; j < OldCollection.GetLength(1); j++) { //column
                for (int i = 0; i < OldCollection.GetLength(0); i++) { //row
                    switch (i) {
                        case 0:
                            name += OldCollection[i,j] + "\r";
                            break;

                        case 1:
                            loc += OldCollection[i,j] + "\r";
                            break;

                        case 2:
                            pic += OldCollection[i,j] + "\r";
                            break;
                    }
                }
            }

            MessageBox.Show(name.Trim());
            MessageBox.Show(loc.Trim());
            MessageBox.Show(pic.Trim());
        }

        public void UpdateEditPanel() {
            cboSelectGame.Items.Clear();
            cboSelectGame.Text = "...";
            txtNameEdit.Text = "...";
            txtLocEdit.Text = "...";
            panelEditGameImage.Image = null;
            panelEditGameImage.ImageLocation = null;

            for (int i = 0; i < Game.numberOfGames; i++) {
                cboSelectGame.Items.Add(OldCollection[0,i]);
            }
        }

        #endregion

    }
}
