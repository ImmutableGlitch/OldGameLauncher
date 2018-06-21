using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace projGameLauncherCsharp
{
    public partial class frmIconExtract : Form
    {
        static string path = @"E:\Hobbies\Games\Game Shorts";
        string[] maybeDeleteMe = new string[100];
        int pointer = 0;
        public frmIconExtract()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirSearch(path);
        }

        public void DirSearch(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            int total = 0;
            try
            {
                    foreach (System.IO.FileInfo f in dir.GetFiles())
                    {
                    maybeDeleteMe[pointer++] = f.FullName.ToString();
                    textBox1.AppendText(Path.GetFileNameWithoutExtension(f.Name) + total + "\r\n");
                    total++;
                    }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Dir Search Method: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExtractAssociatedIconEx();
        }

        ListView listView1;
        ImageList imageList1;

        public void ExtractAssociatedIconEx()
        {
            // Initialize the ListView, ImageList and Form.
            listView1 = new ListView();
            imageList1 = new ImageList();
            listView1.Location = new Point(374, 37);
            listView1.Size = new Size(283, 407);
            listView1.SmallImageList = imageList1;
            listView1.View = View.SmallIcon;
            //this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.listView1);
            this.Text = "Form1";

            // Get the c:\ directory.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);

            ListViewItem item;
            listView1.BeginUpdate();

            // For each file in the c:\ directory, create a ListViewItem 
            // and set the icon to the icon extracted from the file. 
            foreach (System.IO.FileInfo file in dir.GetFiles())
            {
                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                item = new ListViewItem(file.Name, 1);
                iconForFile = Icon.ExtractAssociatedIcon(file.FullName);

                // Check to see if the image collection contains an image 
                // for this extension, using the extension as a key. 
                if (!imageList1.Images.ContainsKey(file.Extension))
                {
                    // If not, add the image to the image list.
                    iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                    imageList1.Images.Add(file.Extension, iconForFile);
                }
                item.ImageKey = file.Extension;
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void frmIconExtract_DoubleClick(object sender, EventArgs e)
        {
            RecursiveSearch.RunMe(maybeDeleteMe);
        }
    }
}
