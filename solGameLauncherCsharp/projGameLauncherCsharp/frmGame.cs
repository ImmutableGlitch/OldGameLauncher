using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System.Xml;

namespace projGameLauncherCsharp
{
    public partial class frmGame : Form
    {
        bool boolButton = true;
        bool smallSize = true;

        int pointerGames = 0;

        string[,] arrNameLocPic = new string[3, 200];

        string NameList = "Name.txt",
               LocList = "Loc.txt",
               PicList = "Pic.txt";

        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            //allows for key events to be used
            this.KeyPreview = true;

            //full screen mode
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            centerComponents();

            btnEnlarge_Click(null, null);

            //Hide panels
            pnlAdd.Hide();
            pnlEdit.Hide();

            //Set colour and flow panel layout
            //this.BackColor = Color.FromArgb(37, 37, 37);
            this.BackColor = Color.FromArgb(21, 71, 0);//green
            this.BackColor = Color.FromArgb(3, 32, 53);//blue
            
            //flo.BackColor = Color.FromArgb(49, 49, 49);
            flo.BackColor = Color.FromArgb(44, 108, 17);//green
            flo.BackColor = Color.FromArgb(17, 53, 81);//blue

            flo.FlowDirection = FlowDirection.LeftToRight;
            flo.WrapContents = true;
            flo.AutoScroll = true;

            ReadTextFile();

            CallGenerate();
        }

        #region Important Methods

        public void ReadTextFile()
        {
            //reset pointer and array
            pointerGames = 0;
            Array.Clear(arrNameLocPic, 0, arrNameLocPic.Length);

            if (File.Exists(NameList) && File.Exists(LocList) && File.Exists(PicList))
            {
                //Read all lines of the text files
                List<string> strNameList = new List<string>(File.ReadAllLines(NameList));
                List<string> strLocList = new List<string>(File.ReadAllLines(LocList));
                List<string> strPicList = new List<string>(File.ReadAllLines(PicList));

                //if text files are smaller than array
                if (strNameList.Count < arrNameLocPic.Length &&
                    strLocList.Count < arrNameLocPic.Length &&
                    strPicList.Count < arrNameLocPic.Length)
                {

                    //store name of games
                    foreach (string name in strNameList)
                    {
                        arrNameLocPic[0, pointerGames] = name;
                        pointerGames++;
                    }

                    pointerGames = 0;

                    //store location of games
                    foreach (string location in strLocList)
                    {
                        arrNameLocPic[1, pointerGames] = location;
                        pointerGames++;
                    }

                    pointerGames = 0;

                    //store picture of games
                    foreach (string picture in strPicList)
                    {
                        arrNameLocPic[2, pointerGames] = picture;
                        pointerGames++;
                    }

                }
                else
                {
                    do
                    {
                        arrNameLocPic = resizeArray(arrNameLocPic);
                    } while (strNameList.Count < arrNameLocPic.Length &&
                    strLocList.Count < arrNameLocPic.Length &&
                    strPicList.Count < arrNameLocPic.Length);

                    ReadTextFile();
                }
            }//if exists
        }

        public void WriteTextFile()
        {


            //delete the file for when there are no games
            //solves blank line issue with textfiles to prevent blank games being added
            if (File.Exists("Name.txt"))
            {
                File.Delete("Name.txt");
            }

            if (File.Exists("Loc.txt"))
            {
                File.Delete("Loc.txt");
            }

            if (File.Exists("Pic.txt"))
            {
                File.Delete("Pic.txt");
            }

            if (pointerGames > 0)
            {
                using (StreamWriter sw = new StreamWriter("Name.txt"))
                {
                    for (int i = 0; i < pointerGames; i++)
                    {
                        sw.WriteLine(arrNameLocPic[0, i]);
                    }

                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter("Loc.txt"))
                {
                    for (int i = 0; i < pointerGames; i++)
                    {
                        sw.WriteLine(arrNameLocPic[1, i]);
                    }

                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter("Pic.txt"))
                {
                    for (int i = 0; i < pointerGames; i++)
                    {
                        sw.WriteLine(arrNameLocPic[2, i]);
                    }

                    sw.Close();
                }
            }
        }

        public void DirSearch(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            try
            {
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    if (pointerGames == arrNameLocPic.GetLength(1))
                    {
                        arrNameLocPic = resizeArray(arrNameLocPic);
                    }

                    arrNameLocPic[1, pointerGames] = f.FullName;

                    Icon imageICO = Icon.ExtractAssociatedIcon(f.FullName);
                    Bitmap imageBMP = imageICO.ToBitmap();
                    imageBMP.Save(pointerGames.ToString() + ".bmp");
                    imageBMP = null;

                    //Icon.ExtractAssociatedIcon(f.FullName).ToBitmap().Save(pointerGames.ToString() + ".bmp");

                    pointerGames++;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.GetType() + ": " + ex.Message + " Dir search listing error occured");
            }
        }

        string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(Char.ToUpper(text[0]));
            for (int i = 1; i < text.Length; i++)
            {
                //If this character is uppercase and the previous char isn't upper or a space
                //Then begin a new word
                if (char.IsUpper(text[i]) && text[i - 1] != ' ' && char.IsLower(text[i - 1]))
                {
                    newText.Append(' ');
                }
                    //would change Battlefield3 to Battlefield 3
                else if (char.IsNumber(text[i]) && char.IsLower(text[i - 1]))
                {
                    newText.Append(' ');
                }
                newText.Append(text[i]);
            }
            return newText.ToString();
        }


        private void flo_DragDrop(object sender, DragEventArgs e)
        {
            //Store files that are dropped on to the form
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            
            //For each file
            foreach (string strFile in files)
            {
                string location = "";
                try
                {
                    if (System.IO.File.Exists(strFile))
                    {
                        //Create a new WshShell COM Object
                        IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell(); 
                        //Links the dropped file to the COM Object, providing access to game .exe instead of .ink
                        IWshRuntimeLibrary.IWshShortcut link = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(strFile); 
                        
                        //store actual game location
                        location = link.TargetPath;

                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Adding steam shortcuts wont allow access to original file.");
                    Debug.WriteLine(ex.Message);
                }

                //Resize array if needed
                if (pointerGames == arrNameLocPic.GetLength(1))
                {
                    arrNameLocPic = resizeArray(arrNameLocPic);
                }

                //Select only the filename
                string fileName = Path.GetFileNameWithoutExtension(location);

                //Remove 'Shortcut' text if exists
                if (fileName.Contains("Shortcut"))
                {
                    int startPoint = fileName.LastIndexOf('.');
                    fileName = fileName.Remove(startPoint, fileName.Length - startPoint);
                }

                //Call method which cleans file names
                arrNameLocPic[0, pointerGames] = AddSpacesToSentence(fileName);
                arrNameLocPic[1, pointerGames] = location;

                //TODO - SCAN THROUGH ALL THIS STUFF, used to download images from theGameDBs.net although not reliable. Use Google API or custom web parsing
                #region editMe
                ////start database stuff
                ////------------------------------------------------

                //string URLforID = "http://thegamesdb.net/search/?searchview=table&string="
                //+ arrNameLocPic[0, pointerGames]
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

                //            webClient.DownloadFile(baseLink + image, arrNameLocPic[0, pointerGames] + "_" + pointer + ".jpg");
                //            arrNameLocPic[2, pointerGames] = arrNameLocPic[0, pointerGames] + "_" + pointer++ + ".jpg";
                //        }
                //        else if (reader.Value.Contains("clearlogo"))
                //        {
                //            //Form2 foo = new Form2();
                //            //foo.showLink(baseLink + reader.Value);
                //            //foo.Show();

                //            image = reader.Value;

                //            webClient.DownloadFile(baseLink + image, arrNameLocPic[0, pointerGames] + "_" + pointer + ".jpg");
                //            arrNameLocPic[2, pointerGames] = arrNameLocPic[0, pointerGames] + "_" + pointer++ + ".jpg";
                //        }
                //    }//while

                //    if (image == "")
                //    {
                //        //MessageBox.Show("Sorry no images found.");
                //        arrNameLocPic[2, pointerGames] = pointerGames.ToString() + ".bmp";
                //    }


                //}
                //catch (Exception ex)
                //{
                //    //MessageBox.Show("Could not download image!");
                //}
                ////------------------------------------------------
                ////end database stuff
                #endregion

                //use filename as bmp image name
                string iconPath = Directory.GetCurrentDirectory() + @"\icons\" + arrNameLocPic[0, pointerGames] + ".bmp";
                arrNameLocPic[2, pointerGames] = iconPath;

                try
                {
                    //TODO - stores icon cache, will be redundant once images/steamgrids functionality replace it
                    //delete existing icon may not be needed, file would simply be overwritten
                    //File.Delete(iconPath);
                    Icon imageICO = Icon.ExtractAssociatedIcon(location);
                    Bitmap imageBMP = imageICO.ToBitmap();
                    imageBMP.Save(iconPath);
                }
                catch (Exception ex)
                {
                    //TODO - FIND OUT WHY THIS ERROR IS ACTUALLY OCCURING
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show("Exit and reopen the app before adding more games. Error Message: " + ex.Message);
                }

                pointerGames++;
            }

            WriteTextFile();

            flo.Controls.Clear();

            CallGenerate();
        }

        private void PaintBorderlessGroupBox(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            
            //Borderless
            //p.Graphics.Clear(box.Parent.BackColor);

            //p.Graphics.Clear(Color.FromArgb(37,37,37));
            p.Graphics.Clear(Color.FromArgb(3, 32, 53));
            p.Graphics.DrawString(box.Text, box.Font, Brushes.White, 0, 0);
            //p.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
        }

        private void Generate(int tagIndex)
        {
            PictureBox btn = new PictureBox();
            btn.Click += new EventHandler(GameClickEvent);
            btn.Tag = tagIndex;
            //btn.BackColor = Color.FromArgb(68, 68, 68); //grayish

            btn.Width = 230;
            btn.Height = 108;
            //btn.Margin = new Padding(0, 0, 60, 0); //left top right bottom
            //btn.Margin = new Padding(0, 54, 0, 60); //left top right bottom
            btn.Size = new System.Drawing.Size(230, 108);

            try
            {
                Image pic = Image.FromFile(arrNameLocPic[2, tagIndex]);
                btn.Image = pic;
                if (pic.Height > 32)
                {
                    btn.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    btn.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                pic = null;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.GetType() + ": " + ex.Message);
                //MessageBox.Show("Images not found for " + arrNameLocPic[0, tagIndex]);
                btn.Image = null;

            }

            Label buttonLabel = new Label();
            buttonLabel.Width = 230;
            buttonLabel.Text = arrNameLocPic[0, tagIndex];
            buttonLabel.Font = new System.Drawing.Font("Minecraftia", 6f);
            buttonLabel.ForeColor = Color.White;
            buttonLabel.Margin = new Padding(0, 54, 0, 60);

            //TODO - WHY AM I USING GROUPBOX 
            GroupBox groupBox = new GroupBox();
            groupBox.Paint += PaintBorderlessGroupBox;
            groupBox.Text = arrNameLocPic[0, tagIndex];
            groupBox.ForeColor = Color.White;
            groupBox.Size = new Size(236, 125);
            groupBox.Dock = DockStyle.Top;
            flo.Controls.Add(groupBox);

            groupBox.Margin = new Padding(55, 10, 10, 25);
            btn.Location = groupBox.DisplayRectangle.Location;
            //btn.Size = new Size(0, 0);
            //btn.AutoSize = true;

            groupBox.Controls.Add(btn);


            //flo.Controls.Add(btn);
            //flo.Controls.Add(buttonLabel);
        }

        public void GameClickEvent(Object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            frmMenu foo = new frmMenu();
            foo.Show();
            this.Hide();

            try
            {
                Process.Start(arrNameLocPic[1, (int)btn.Tag]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType() + ": " + ex.Message + " Invalid game path");
            }
        }

        public void CallGenerate()
        {
            for (int i = 0; i < pointerGames; i++)
            {
                Generate(i);
            }

            lblNumOfGames.Text = "Game Count: " + flo.Controls.OfType<PictureBox>().Count().ToString();
        }

        #endregion

        #region Components
        public void toggleButtons()
        {
            boolButton = !boolButton;

            btnAddGame.Enabled = boolButton;
            btnEdit.Enabled = boolButton;
            btnMenu.Enabled = boolButton;
            btnEnlarge.Enabled = boolButton;
            btnGameDir.Enabled = boolButton;
            flo.Enabled = boolButton;
        }


        private void btnMenu_MouseEnter(object sender, EventArgs e)
        {
            btnMenu.Image = Properties.Resources.menuH;
        }

        private void btnMenu_MouseLeave(object sender, EventArgs e)
        {
            btnMenu.Image = Properties.Resources.menu;
        }

        private void btnEnlarge_Click(object sender, EventArgs e)
        {
            if (!smallSize)
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(850, 478);
                flo.Size = new Size(826, 419);
                foreach (GroupBox gb in flo.Controls)
                {
                    gb.Margin = new Padding(15);
                }
                btnEnlarge.Location = new Point(766, 10);
                btnMenu.Location = new Point(806, 10);
                smallSize = !smallSize;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                //flo.Size = new Size(1256, 659);
                //btnEnlarge.Location = new Point(1186, 6);
                //btnMenu.Location = new Point(1225, 6);
                flo.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 24, Screen.PrimaryScreen.WorkingArea.Height - 30);
                btnEnlarge.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 80, 6);
                btnMenu.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 40, 6);
                smallSize = !smallSize;
            }

            //smooth transition
            this.Hide();
            centerComponents();
            this.Show();
        }

        private void btnEnlarge_MouseEnter(object sender, EventArgs e)
        {
            btnEnlarge.Image = Properties.Resources.enlargeH;
        }

        private void btnEnlarge_MouseLeave(object sender, EventArgs e)
        {
            btnEnlarge.Image = Properties.Resources.enlarge;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlEdit.Show();
            toggleButtons();
            UpdateEditPanel();
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.Image = Properties.Resources.editH;
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.Image = Properties.Resources.edit;
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            pnlAdd.Show();
            toggleButtons();
        }

        private void btnAddGame_MouseEnter(object sender, EventArgs e)
        {
            btnAddGame.Image = Properties.Resources.addH;
        }

        private void btnAddGame_MouseLeave(object sender, EventArgs e)
        {
            btnAddGame.Image = Properties.Resources.add;
        }

        private void btnGameDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"E:\Games\Installed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType() + ": " + ex.Message + " Game Directory not found.");
            }
        }

        private void btnGameDir_MouseEnter(object sender, EventArgs e)
        {
            btnGameDir.Image = Properties.Resources.gamesH;
        }

        private void btnGameDir_MouseLeave(object sender, EventArgs e)
        {
            btnGameDir.Image = Properties.Resources.games;
        }

        private void btnCloseAddPanel_Click(object sender, EventArgs e)
        {
            pnlAdd.Hide();
            toggleButtons();
        }

        private void btnCloseEditPanel_Click(object sender, EventArgs e)
        {
            pnlEdit.Hide();
            toggleButtons();
        }

        private void btnCloseAddPanel_MouseEnter(object sender, EventArgs e)
        {
            btnCloseAddPanel.Image = Properties.Resources.xH;
        }

        private void btnCloseAddPanel_MouseLeave(object sender, EventArgs e)
        {
            btnCloseAddPanel.Image = Properties.Resources.x;
        }

        private void btnCloseEditPanel_MouseEnter(object sender, EventArgs e)
        {
            btnCloseEditPanel.Image = Properties.Resources.xH;
        }

        private void btnCloseEditPanel_MouseLeave(object sender, EventArgs e)
        {
            btnCloseEditPanel.Image = Properties.Resources.x;
        }

        private void btnDoneAddPanel_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtLocation.Text == "")
            {
                MessageBox.Show("You left fields blank!");
            }
            else
            {
                //Update Arrays
                arrNameLocPic[0, pointerGames] = txtName.Text;
                arrNameLocPic[1, pointerGames] = txtLocation.Text;
                arrNameLocPic[2, pointerGames] = picAddPanel.ImageLocation;

                pointerGames++;

                //Update text files
                WriteTextFile();

                //'Update buttons
                flo.Controls.Clear();
                ReadTextFile();
                CallGenerate();

                //'Blank the textfields
                txtName.Text = "";
                txtLocation.Text = "";
                picAddPanel.Image = null;
                picAddPanel.ImageLocation = null;
            }
        }

        private void btnSaveEditPanel_Click(object sender, EventArgs e)
        {
            arrNameLocPic[0, cboSelectGame.SelectedIndex] = txtNameEdit.Text;
            arrNameLocPic[1, cboSelectGame.SelectedIndex] = txtLocEdit.Text;
            if (picEditPanel.ImageLocation != null)
            {
                arrNameLocPic[2, cboSelectGame.SelectedIndex] = picEditPanel.ImageLocation;
            }

            WriteTextFile();
            UpdateEditPanel();
            flo.Controls.Clear();
            ReadTextFile();
            CallGenerate();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            ofdAddImage.ShowDialog();
        }

        private void ofdAddImage_FileOk(object sender, CancelEventArgs e)
        {
            picAddPanel.ImageLocation = ofdAddImage.FileName;
        }

        private void btnLocationAdd_Click(object sender, EventArgs e)
        {
            ofdGameLocAdd.ShowDialog();
        }

        private void btnEditImage_Click(object sender, EventArgs e)
        {
            ofdEditImage.ShowDialog();
        }

        private void ofdGameLocEdit_FileOk(object sender, CancelEventArgs e)
        {
            txtLocEdit.Text = ofdGameLocEdit.FileName;
        }

        private void btnLocationEdit_Click(object sender, EventArgs e)
        {
            ofdGameLocEdit.ShowDialog();
        }

        private void ofdEditImage_FileOk(object sender, CancelEventArgs e)
        {
            picEditPanel.ImageLocation = ofdEditImage.FileName;
        }

        private void ofdGameLocAdd_FileOk(object sender, CancelEventArgs e)
        {
            txtLocation.Text = ofdGameLocAdd.FileName;
        }

        private void btnDeleteEditPanel_Click(object sender, EventArgs e)
        {
            if (cboSelectGame.SelectedIndex < pointerGames)
            {
                for (int i = cboSelectGame.SelectedIndex; i < pointerGames; i++)
                {
                    arrNameLocPic[0, i] = arrNameLocPic[0, i + 1];
                    arrNameLocPic[1, i] = arrNameLocPic[1, i + 1];
                    arrNameLocPic[2, i] = arrNameLocPic[2, i + 1];
                }

                pointerGames--;
                WriteTextFile();
                flo.Controls.Clear();
                ReadTextFile();
                CallGenerate();
            }

            UpdateEditPanel();
        }

        private void cboSelectGame_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtNameEdit.Text = arrNameLocPic[0, cboSelectGame.SelectedIndex];
            txtLocEdit.Text = arrNameLocPic[1, cboSelectGame.SelectedIndex];
            try
            {
                Image pic = Image.FromFile(arrNameLocPic[2, cboSelectGame.SelectedIndex]);
                picEditPanel.Image = pic;
                if (pic.Height > 32)
                {
                    picEditPanel.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    picEditPanel.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                pic = null;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                picEditPanel.Image = null;
            }
        }
        #endregion

        #region Unimportant Methods

        public static string[,] resizeArray(string[,] x)
        {
            MessageBox.Show("resizing");
            string[,] increase = new string[3, x.GetLength(1) + 50];
            string[,] backup = x;
            x = increase;
            Array.Copy(backup, x, backup.Length);
            return x;
        }

        private void frmGame_MouseEnter(object sender, EventArgs e)
        {
            flo.Focus();
        }

        private void flo_MouseEnter(object sender, EventArgs e)
        {
            flo.Focus();
        }

        public void centerComponents()
        {
            pnlAdd.Top = (this.Height - pnlAdd.Height) / 2;
            pnlAdd.Left = (this.Width - pnlAdd.Width) / 2;

            pnlEdit.Top = (this.Height - pnlEdit.Height) / 2;
            pnlEdit.Left = (this.Width - pnlEdit.Width) / 2;

            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;

            optionPanel.Top = (this.Height - optionPanel.Height) / 2;
            optionPanel.Left = (this.Width - optionPanel.Width) / 2;

            lblNumOfGames.Location = new Point((this.Width - lblNumOfGames.Width) / 2, lblNumOfGames.Location.Y);
        }

        public void printArray()
        {
            String name = "", loc = "", pic = "";

            for (int j = 0; j < arrNameLocPic.GetLength(1); j++) //collumn
            {
                for (int i = 0; i < arrNameLocPic.GetLength(0); i++)//row
                {
                    switch (i)
                    {
                        case 0:
                            name += arrNameLocPic[i, j] + "\r";
                            break;

                        case 1:
                            loc += arrNameLocPic[i, j] + "\r";
                            break;

                        case 2:
                            pic += arrNameLocPic[i, j] + "\r";
                            break;
                    }
                }
            }

            MessageBox.Show(name.Trim());
            MessageBox.Show(loc.Trim());
            MessageBox.Show(pic.Trim());
        }

        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void flo_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        public void UpdateEditPanel()
        {
            cboSelectGame.Items.Clear();
            cboSelectGame.Text = "...";
            txtNameEdit.Text = "...";
            txtLocEdit.Text = "...";
            picEditPanel.Image = null;
            picEditPanel.ImageLocation = null;

            for (int i = 0; i < pointerGames; i++)
            {
                cboSelectGame.Items.Add(arrNameLocPic[0, i]);
            }
        }

        #endregion

        private void btnMenuOptions(object sender, EventArgs e)
        {
            optionPanel.Show();
            toggleButtons();
        }

        private void cboOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboOption.Text)
            {
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

            optionPanel.Hide();
            toggleButtons();
        }

        private void frmGame_Click(object sender, EventArgs e)
        {
            frmMenu foo = new frmMenu();
            foo.Show();
            this.Hide();
        }

        private void btnCloseMenu_Click(object sender, EventArgs e)
        {
            optionPanel.Hide();
            toggleButtons();
        }

        private void btnCloseMenu_MouseEnter(object sender, EventArgs e)
        {
            btnCloseMenu.Image = Properties.Resources.xH;
        }

        private void btnCloseMenu_MouseLeave(object sender, EventArgs e)
        {
            btnCloseMenu.Image = Properties.Resources.x;
        }

    }
}
