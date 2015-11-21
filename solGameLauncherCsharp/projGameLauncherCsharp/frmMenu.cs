using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projGameLauncherCsharp
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(39, 40, 34);
            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.SetDesktopLocation(x,0);
            this.Size = new Size(200,12);
        }

        private void frmMenu_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            frmGame foo = new frmGame();
            foo.Show();
        }
    }
}
