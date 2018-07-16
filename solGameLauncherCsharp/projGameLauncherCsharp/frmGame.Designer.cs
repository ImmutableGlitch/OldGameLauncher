namespace projGameLauncherCsharp
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGame));
            this.Label2 = new System.Windows.Forms.Label();
            this.panelEditGame = new System.Windows.Forms.Panel();
            this.btnCloseEditPanel = new System.Windows.Forms.PictureBox();
            this.panelEditGameImage = new System.Windows.Forms.PictureBox();
            this.btnEditImage = new System.Windows.Forms.Button();
            this.btnLocationEdit = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.cboSelectGame = new System.Windows.Forms.ComboBox();
            this.txtLocEdit = new System.Windows.Forms.TextBox();
            this.txtNameEdit = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnSaveEditPanel = new System.Windows.Forms.Button();
            this.btnDeleteEditPanel = new System.Windows.Forms.Button();
            this.btnLocationAdd = new System.Windows.Forms.Button();
            this.btnDoneAddPanel = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.panelAddGame = new System.Windows.Forms.Panel();
            this.btnCloseAddPanel = new System.Windows.Forms.PictureBox();
            this.panelAddGameImage = new System.Windows.Forms.PictureBox();
            this.ofdEditImage = new System.Windows.Forms.OpenFileDialog();
            this.ofdGameLocAdd = new System.Windows.Forms.OpenFileDialog();
            this.ofdGameLocEdit = new System.Windows.Forms.OpenFileDialog();
            this.ofdAddImage = new System.Windows.Forms.OpenFileDialog();
            this.panelGames = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNumOfGames = new System.Windows.Forms.Label();
            this.btnGameDir = new System.Windows.Forms.PictureBox();
            this.btnEnlarge = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.btnAddGame = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelOptions = new System.Windows.Forms.Panel();
            this.btnCloseMenu = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboOption = new System.Windows.Forms.ComboBox();
            this.cboColour = new System.Windows.Forms.ComboBox();
            this.panelEditGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseEditPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEditGameImage)).BeginInit();
            this.panelAddGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAddPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelAddGameImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGameDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnlarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGame)).BeginInit();
            this.panelOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Label2.Location = new System.Drawing.Point(12, 35);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(81, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Name of Game:";
            // 
            // panelEditGame
            // 
            this.panelEditGame.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelEditGame.Controls.Add(this.btnCloseEditPanel);
            this.panelEditGame.Controls.Add(this.panelEditGameImage);
            this.panelEditGame.Controls.Add(this.btnEditImage);
            this.panelEditGame.Controls.Add(this.btnLocationEdit);
            this.panelEditGame.Controls.Add(this.Label6);
            this.panelEditGame.Controls.Add(this.cboSelectGame);
            this.panelEditGame.Controls.Add(this.txtLocEdit);
            this.panelEditGame.Controls.Add(this.txtNameEdit);
            this.panelEditGame.Controls.Add(this.Label4);
            this.panelEditGame.Controls.Add(this.Label5);
            this.panelEditGame.Controls.Add(this.btnSaveEditPanel);
            this.panelEditGame.Controls.Add(this.btnDeleteEditPanel);
            this.panelEditGame.Location = new System.Drawing.Point(373, 72);
            this.panelEditGame.Name = "panelEditGame";
            this.panelEditGame.Size = new System.Drawing.Size(388, 374);
            this.panelEditGame.TabIndex = 29;
            this.panelEditGame.Visible = false;
            // 
            // btnCloseEditPanel
            // 
            this.btnCloseEditPanel.Image = global::projGameLauncherCsharp.Properties.Resources.x;
            this.btnCloseEditPanel.Location = new System.Drawing.Point(368, 3);
            this.btnCloseEditPanel.Name = "btnCloseEditPanel";
            this.btnCloseEditPanel.Size = new System.Drawing.Size(17, 17);
            this.btnCloseEditPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCloseEditPanel.TabIndex = 18;
            this.btnCloseEditPanel.TabStop = false;
            this.btnCloseEditPanel.Click += new System.EventHandler(this.BtnCloseEditPanel_Click);
            this.btnCloseEditPanel.MouseEnter += new System.EventHandler(this.BtnCloseEditPanel_MouseEnter);
            this.btnCloseEditPanel.MouseLeave += new System.EventHandler(this.BtnCloseEditPanel_MouseLeave);
            // 
            // panelEditGameImage
            // 
            this.panelEditGameImage.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelEditGameImage.ImageLocation = "";
            this.panelEditGameImage.Location = new System.Drawing.Point(74, 227);
            this.panelEditGameImage.Name = "panelEditGameImage";
            this.panelEditGameImage.Size = new System.Drawing.Size(230, 108);
            this.panelEditGameImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.panelEditGameImage.TabIndex = 17;
            this.panelEditGameImage.TabStop = false;
            // 
            // btnEditImage
            // 
            this.btnEditImage.Location = new System.Drawing.Point(153, 198);
            this.btnEditImage.Name = "btnEditImage";
            this.btnEditImage.Size = new System.Drawing.Size(75, 23);
            this.btnEditImage.TabIndex = 16;
            this.btnEditImage.Text = "Edit Image";
            this.btnEditImage.UseVisualStyleBackColor = true;
            this.btnEditImage.Click += new System.EventHandler(this.BtnEditImage_Click);
            // 
            // btnLocationEdit
            // 
            this.btnLocationEdit.Location = new System.Drawing.Point(310, 162);
            this.btnLocationEdit.Name = "btnLocationEdit";
            this.btnLocationEdit.Size = new System.Drawing.Size(58, 20);
            this.btnLocationEdit.TabIndex = 15;
            this.btnLocationEdit.Text = "Browse";
            this.btnLocationEdit.UseVisualStyleBackColor = true;
            this.btnLocationEdit.Click += new System.EventHandler(this.BtnLocationEdit_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Label6.Location = new System.Drawing.Point(12, 30);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(71, 13);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Select Game:";
            // 
            // cboSelectGame
            // 
            this.cboSelectGame.FormattingEnabled = true;
            this.cboSelectGame.Location = new System.Drawing.Point(15, 45);
            this.cboSelectGame.Name = "cboSelectGame";
            this.cboSelectGame.Size = new System.Drawing.Size(354, 21);
            this.cboSelectGame.TabIndex = 13;
            this.cboSelectGame.SelectedIndexChanged += new System.EventHandler(this.CboSelectGame_SelectedIndexChanged);
            // 
            // txtLocEdit
            // 
            this.txtLocEdit.Location = new System.Drawing.Point(15, 162);
            this.txtLocEdit.Name = "txtLocEdit";
            this.txtLocEdit.Size = new System.Drawing.Size(288, 20);
            this.txtLocEdit.TabIndex = 12;
            // 
            // txtNameEdit
            // 
            this.txtNameEdit.Location = new System.Drawing.Point(15, 107);
            this.txtNameEdit.Name = "txtNameEdit";
            this.txtNameEdit.Size = new System.Drawing.Size(354, 20);
            this.txtNameEdit.TabIndex = 11;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Label4.Location = new System.Drawing.Point(12, 147);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(48, 13);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Location";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Label5.Location = new System.Drawing.Point(12, 92);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(81, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Name of Game:";
            // 
            // btnSaveEditPanel
            // 
            this.btnSaveEditPanel.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSaveEditPanel.Location = new System.Drawing.Point(132, 344);
            this.btnSaveEditPanel.Name = "btnSaveEditPanel";
            this.btnSaveEditPanel.Size = new System.Drawing.Size(46, 23);
            this.btnSaveEditPanel.TabIndex = 8;
            this.btnSaveEditPanel.Text = "Save";
            this.btnSaveEditPanel.UseVisualStyleBackColor = false;
            this.btnSaveEditPanel.Click += new System.EventHandler(this.BtnSaveEditPanel_Click);
            // 
            // btnDeleteEditPanel
            // 
            this.btnDeleteEditPanel.Location = new System.Drawing.Point(194, 344);
            this.btnDeleteEditPanel.Name = "btnDeleteEditPanel";
            this.btnDeleteEditPanel.Size = new System.Drawing.Size(48, 23);
            this.btnDeleteEditPanel.TabIndex = 7;
            this.btnDeleteEditPanel.Text = "Delete";
            this.btnDeleteEditPanel.UseVisualStyleBackColor = true;
            this.btnDeleteEditPanel.Click += new System.EventHandler(this.BtnDeleteEditPanel_Click);
            // 
            // btnLocationAdd
            // 
            this.btnLocationAdd.Location = new System.Drawing.Point(306, 104);
            this.btnLocationAdd.Name = "btnLocationAdd";
            this.btnLocationAdd.Size = new System.Drawing.Size(58, 20);
            this.btnLocationAdd.TabIndex = 16;
            this.btnLocationAdd.Text = "Browse";
            this.btnLocationAdd.UseVisualStyleBackColor = true;
            this.btnLocationAdd.Click += new System.EventHandler(this.BtnLocationAdd_Click);
            // 
            // btnDoneAddPanel
            // 
            this.btnDoneAddPanel.BackColor = System.Drawing.Color.PaleGreen;
            this.btnDoneAddPanel.Location = new System.Drawing.Point(152, 292);
            this.btnDoneAddPanel.Name = "btnDoneAddPanel";
            this.btnDoneAddPanel.Size = new System.Drawing.Size(75, 23);
            this.btnDoneAddPanel.TabIndex = 6;
            this.btnDoneAddPanel.Text = "Done";
            this.btnDoneAddPanel.UseVisualStyleBackColor = false;
            this.btnDoneAddPanel.Click += new System.EventHandler(this.BtnDoneAddPanel_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(15, 105);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(288, 20);
            this.txtLocation.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(350, 20);
            this.txtName.TabIndex = 3;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(152, 148);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(75, 23);
            this.btnAddImage.TabIndex = 2;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Label3.Location = new System.Drawing.Point(12, 90);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(48, 13);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Location";
            // 
            // panelAddGame
            // 
            this.panelAddGame.BackColor = System.Drawing.Color.SteelBlue;
            this.panelAddGame.Controls.Add(this.btnCloseAddPanel);
            this.panelAddGame.Controls.Add(this.btnLocationAdd);
            this.panelAddGame.Controls.Add(this.panelAddGameImage);
            this.panelAddGame.Controls.Add(this.btnDoneAddPanel);
            this.panelAddGame.Controls.Add(this.txtLocation);
            this.panelAddGame.Controls.Add(this.txtName);
            this.panelAddGame.Controls.Add(this.btnAddImage);
            this.panelAddGame.Controls.Add(this.Label3);
            this.panelAddGame.Controls.Add(this.Label2);
            this.panelAddGame.Location = new System.Drawing.Point(4, 42);
            this.panelAddGame.Name = "panelAddGame";
            this.panelAddGame.Size = new System.Drawing.Size(388, 317);
            this.panelAddGame.TabIndex = 28;
            this.panelAddGame.Visible = false;
            // 
            // btnCloseAddPanel
            // 
            this.btnCloseAddPanel.Image = global::projGameLauncherCsharp.Properties.Resources.x;
            this.btnCloseAddPanel.Location = new System.Drawing.Point(368, 3);
            this.btnCloseAddPanel.Name = "btnCloseAddPanel";
            this.btnCloseAddPanel.Size = new System.Drawing.Size(17, 17);
            this.btnCloseAddPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCloseAddPanel.TabIndex = 17;
            this.btnCloseAddPanel.TabStop = false;
            this.btnCloseAddPanel.Click += new System.EventHandler(this.BtnCloseAddPanel_Click);
            this.btnCloseAddPanel.MouseEnter += new System.EventHandler(this.BtnCloseAddPanel_MouseEnter);
            this.btnCloseAddPanel.MouseLeave += new System.EventHandler(this.BtnCloseAddPanel_MouseLeave);
            // 
            // panelAddGameImage
            // 
            this.panelAddGameImage.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelAddGameImage.ImageLocation = "E:\\Programming\\Git\\repos\\solBetterExplorer\\projBetterExplorer\\bin\\Debug\\folder.pn" +
    "g";
            this.panelAddGameImage.Location = new System.Drawing.Point(74, 178);
            this.panelAddGameImage.Name = "panelAddGameImage";
            this.panelAddGameImage.Size = new System.Drawing.Size(230, 108);
            this.panelAddGameImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.panelAddGameImage.TabIndex = 7;
            this.panelAddGameImage.TabStop = false;
            // 
            // ofdEditImage
            // 
            this.ofdEditImage.InitialDirectory = "\\";
            this.ofdEditImage.FileOk += new System.ComponentModel.CancelEventHandler(this.OfdEditImage_FileOk);
            // 
            // ofdGameLocAdd
            // 
            this.ofdGameLocAdd.InitialDirectory = "C:\\";
            this.ofdGameLocAdd.FileOk += new System.ComponentModel.CancelEventHandler(this.OfdGameLocAdd_FileOk);
            // 
            // ofdGameLocEdit
            // 
            this.ofdGameLocEdit.InitialDirectory = "C:\\";
            this.ofdGameLocEdit.FileOk += new System.ComponentModel.CancelEventHandler(this.OfdGameLocEdit_FileOk);
            // 
            // ofdAddImage
            // 
            this.ofdAddImage.InitialDirectory = "\\";
            this.ofdAddImage.FileOk += new System.ComponentModel.CancelEventHandler(this.OfdAddImage_FileOk);
            // 
            // panelGames
            // 
            this.panelGames.AllowDrop = true;
            this.panelGames.AutoScroll = true;
            this.panelGames.BackColor = System.Drawing.Color.Lavender;
            this.panelGames.Location = new System.Drawing.Point(12, 49);
            this.panelGames.Name = "panelGames";
            this.panelGames.Size = new System.Drawing.Size(826, 419);
            this.panelGames.TabIndex = 31;
            this.panelGames.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanelGames_DragDrop);
            this.panelGames.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanelGames_DragEnter);
            this.panelGames.MouseEnter += new System.EventHandler(this.PanelGames_MouseEnter);
            // 
            // lblNumOfGames
            // 
            this.lblNumOfGames.AutoSize = true;
            this.lblNumOfGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfGames.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblNumOfGames.Location = new System.Drawing.Point(529, 19);
            this.lblNumOfGames.Name = "lblNumOfGames";
            this.lblNumOfGames.Size = new System.Drawing.Size(136, 24);
            this.lblNumOfGames.TabIndex = 30;
            this.lblNumOfGames.Text = "Game Count: 0";
            this.lblNumOfGames.Visible = false;
            // 
            // btnGameDir
            // 
            this.btnGameDir.Image = ((System.Drawing.Image)(resources.GetObject("btnGameDir.Image")));
            this.btnGameDir.Location = new System.Drawing.Point(119, 5);
            this.btnGameDir.Name = "btnGameDir";
            this.btnGameDir.Size = new System.Drawing.Size(33, 33);
            this.btnGameDir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnGameDir.TabIndex = 36;
            this.btnGameDir.TabStop = false;
            this.btnGameDir.Visible = false;
            this.btnGameDir.Click += new System.EventHandler(this.BtnGameDir_Click);
            this.btnGameDir.MouseEnter += new System.EventHandler(this.BtnGameDir_MouseEnter);
            this.btnGameDir.MouseLeave += new System.EventHandler(this.BtnGameDir_MouseLeave);
            // 
            // btnEnlarge
            // 
            this.btnEnlarge.Image = global::projGameLauncherCsharp.Properties.Resources.enlarge;
            this.btnEnlarge.Location = new System.Drawing.Point(766, 10);
            this.btnEnlarge.Name = "btnEnlarge";
            this.btnEnlarge.Size = new System.Drawing.Size(33, 33);
            this.btnEnlarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEnlarge.TabIndex = 35;
            this.btnEnlarge.TabStop = false;
            this.btnEnlarge.Click += new System.EventHandler(this.BtnEnlarge_Click);
            this.btnEnlarge.MouseEnter += new System.EventHandler(this.BtnEnlarge_MouseEnter);
            this.btnEnlarge.MouseLeave += new System.EventHandler(this.BtnEnlarge_MouseLeave);
            // 
            // btnMenu
            // 
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(806, 10);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(33, 33);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMenu.TabIndex = 34;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.BtnMenuOptions);
            this.btnMenu.MouseEnter += new System.EventHandler(this.BtnMenu_MouseEnter);
            this.btnMenu.MouseLeave += new System.EventHandler(this.BtnMenu_MouseLeave);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(51, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(33, 33);
            this.btnEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEdit.TabIndex = 33;
            this.btnEdit.TabStop = false;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            this.btnEdit.MouseEnter += new System.EventHandler(this.BtnEdit_MouseEnter);
            this.btnEdit.MouseLeave += new System.EventHandler(this.BtnEdit_MouseLeave);
            // 
            // btnAddGame
            // 
            this.btnAddGame.Image = global::projGameLauncherCsharp.Properties.Resources.add;
            this.btnAddGame.Location = new System.Drawing.Point(12, 5);
            this.btnAddGame.Name = "btnAddGame";
            this.btnAddGame.Size = new System.Drawing.Size(33, 33);
            this.btnAddGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddGame.TabIndex = 32;
            this.btnAddGame.TabStop = false;
            this.btnAddGame.Click += new System.EventHandler(this.BtnAddGame_Click);
            this.btnAddGame.MouseEnter += new System.EventHandler(this.BtnAddGame_MouseEnter);
            this.btnAddGame.MouseLeave += new System.EventHandler(this.BtnAddGame_MouseLeave);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelOptions
            // 
            this.panelOptions.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelOptions.Controls.Add(this.btnCloseMenu);
            this.panelOptions.Controls.Add(this.label1);
            this.panelOptions.Controls.Add(this.cboOption);
            this.panelOptions.Location = new System.Drawing.Point(497, 348);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(351, 130);
            this.panelOptions.TabIndex = 37;
            this.panelOptions.Visible = false;
            // 
            // btnCloseMenu
            // 
            this.btnCloseMenu.Image = global::projGameLauncherCsharp.Properties.Resources.x;
            this.btnCloseMenu.Location = new System.Drawing.Point(331, 3);
            this.btnCloseMenu.Name = "btnCloseMenu";
            this.btnCloseMenu.Size = new System.Drawing.Size(17, 17);
            this.btnCloseMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCloseMenu.TabIndex = 19;
            this.btnCloseMenu.TabStop = false;
            this.btnCloseMenu.Click += new System.EventHandler(this.BtnCloseMenu_Click);
            this.btnCloseMenu.MouseEnter += new System.EventHandler(this.BtnCloseMenu_MouseEnter);
            this.btnCloseMenu.MouseLeave += new System.EventHandler(this.BtnCloseMenu_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Location = new System.Drawing.Point(59, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 30);
            this.label1.TabIndex = 38;
            this.label1.Text = "Select an option below:";
            // 
            // cboOption
            // 
            this.cboOption.FormattingEnabled = true;
            this.cboOption.Items.AddRange(new object[] {
            "Games",
            "Programs",
            "Other"});
            this.cboOption.Location = new System.Drawing.Point(19, 69);
            this.cboOption.Name = "cboOption";
            this.cboOption.Size = new System.Drawing.Size(310, 21);
            this.cboOption.TabIndex = 0;
            this.cboOption.SelectedIndexChanged += new System.EventHandler(this.CboOption_SelectedIndexChanged);
            // 
            // cboColour
            // 
            this.cboColour.FormattingEnabled = true;
            this.cboColour.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "Gray"});
            this.cboColour.Location = new System.Drawing.Point(158, 12);
            this.cboColour.Name = "cboColour";
            this.cboColour.Size = new System.Drawing.Size(121, 21);
            this.cboColour.TabIndex = 38;
            this.cboColour.SelectedIndexChanged += new System.EventHandler(this.CboColour_SelectedIndexChanged);
            // 
            // frmGame
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(849, 478);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.cboColour);
            this.Controls.Add(this.btnGameDir);
            this.Controls.Add(this.btnEnlarge);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddGame);
            this.Controls.Add(this.panelEditGame);
            this.Controls.Add(this.panelAddGame);
            this.Controls.Add(this.panelGames);
            this.Controls.Add(this.lblNumOfGames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGame_FormClosing);
            this.Load += new System.EventHandler(this.FrmGame_Load);
            this.DoubleClick += new System.EventHandler(this.FrmGame_Click);
            this.MouseEnter += new System.EventHandler(this.FrmGame_MouseEnter);
            this.panelEditGame.ResumeLayout(false);
            this.panelEditGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseEditPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEditGameImage)).EndInit();
            this.panelAddGame.ResumeLayout(false);
            this.panelAddGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAddPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelAddGameImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGameDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnlarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGame)).EndInit();
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox btnEnlarge;
        internal System.Windows.Forms.PictureBox btnMenu;
        internal System.Windows.Forms.PictureBox btnEdit;
        internal System.Windows.Forms.PictureBox btnAddGame;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel panelEditGame;
        internal System.Windows.Forms.PictureBox panelEditGameImage;
        internal System.Windows.Forms.Button btnEditImage;
        internal System.Windows.Forms.Button btnLocationEdit;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cboSelectGame;
        internal System.Windows.Forms.TextBox txtLocEdit;
        internal System.Windows.Forms.TextBox txtNameEdit;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnSaveEditPanel;
        internal System.Windows.Forms.Button btnDeleteEditPanel;
        internal System.Windows.Forms.Button btnLocationAdd;
        internal System.Windows.Forms.PictureBox panelAddGameImage;
        internal System.Windows.Forms.Button btnDoneAddPanel;
        internal System.Windows.Forms.TextBox txtLocation;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Button btnAddImage;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel panelAddGame;
        internal System.Windows.Forms.OpenFileDialog ofdEditImage;
        internal System.Windows.Forms.OpenFileDialog ofdGameLocAdd;
        internal System.Windows.Forms.OpenFileDialog ofdGameLocEdit;
        internal System.Windows.Forms.OpenFileDialog ofdAddImage;
        internal System.Windows.Forms.FlowLayoutPanel panelGames;
        internal System.Windows.Forms.Label lblNumOfGames;
        internal System.Windows.Forms.PictureBox btnGameDir;
        private System.Windows.Forms.PictureBox btnCloseAddPanel;
        private System.Windows.Forms.PictureBox btnCloseEditPanel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOption;
        private System.Windows.Forms.PictureBox btnCloseMenu;
        private System.Windows.Forms.ComboBox cboColour;
    }
}