using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace projGameLauncherCsharp
{
    public partial class frmGameDatabaseMiner : Form
    {
        public frmGameDatabaseMiner()
        {
            InitializeComponent();
        }

        static List<string> strID = new List<string>();
        static List<string> strName = new List<string>();
        static List<string> strPic = new List<string>();
        int pointer = 0;

        public void GrabID()
        {
            string databaseURL = "http://thegamesdb.net/browse/1/?sortBy=g.GameTitle&limit=100&searchview=table&page=2";

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load(databaseURL);
            string outputID = "", outputName = "";
            HtmlNodeCollection ID = doc.DocumentNode.SelectNodes("//*[@id=\"listtable\"]/tr/td[1]");
            HtmlNodeCollection Name = doc.DocumentNode.SelectNodes("//*[@id=\"listtable\"]/tr/td[2]");

            foreach (HtmlNode e in ID)
            {
                strID.Add(e.InnerText);
                pointer++;
                outputID += e.InnerText + Environment.NewLine;
            }

            pointer = 0;

            foreach (HtmlNode e in Name)
            {
                strName.Add(e.InnerText);
                pointer++;
                outputName += e.InnerText + Environment.NewLine;
            }

            txtOutput.Text = outputID;
            txtXML.Text = outputName;
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            GrabID();
        }

        private void btnContains_Click(object sender, EventArgs e)
        {
            string s1 = "fanart/thumb/101-2.jpg";
            string s2 = "thumb";
            bool b;
            b = s1.Contains(s2);
            MessageBox.Show(b.ToString());
        }

        private void btnGetID_Click(object sender, EventArgs e)
        {
            //Generate search URL based on user input
            string databaseURL = "http://thegamesdb.net/search/?searchview=table&string="
                + txtSearch.Text
                + "&function=Search&sortBy=&limit=20&page=1&updateview=yes&stringPlatform=";

            //Create an HTMLWeb object and use it to load the URL
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load(databaseURL);

            try
            {
                //search for ID within database table and display it
                HtmlNode link = doc.DocumentNode.SelectNodes("//*[@id=\"listtable\"]/tr[2]/td[1]").First<HtmlNode>();
                txtSearch.Text = link.InnerHtml;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Game not found");
            }
        }

        private void btnPrintXml_Click(object sender, EventArgs e)
        {
            //string URL = "http://thegamesdb.net/api/GetArt.php?id=" + ID;
            ////Process.Start(URL);

            //XmlTextReader reader = new XmlTextReader(URL);

            //// Skip non-significant whitespace  
            //reader.WhitespaceHandling = WhitespaceHandling.Significant;
            //txtXML.Clear();
            //// Read nodes one at a time  
            //while (reader.Read())
            //{
            //    // Print out info on node  
            //    if(reader.NodeType == XmlNodeType.Text)
            //    {
            //        txtXML.AppendText(reader.Value + Environment.NewLine);
            //        WebClient webClient = new WebClient();
            //        webClient.DownloadFile("http://thegamesdb.net/banners/boxart/original/front/26198-1.jpg", "war.jpg");
            //    }
            //}
            
            txtXML.Clear();

            foreach (string i in strID)
            {
                string URL = "http://thegamesdb.net/api/GetArt.php?id=" + i;
                pointer++;

                XmlTextReader reader = new XmlTextReader(URL);

                reader.WhitespaceHandling = WhitespaceHandling.Significant;


                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        if (reader.Value.Contains("graphical"))
                        {
                            strPic.Add(reader.Value);
                            txtXML.AppendText(reader.Value + Environment.NewLine);
                        }
                        else if (reader.Value.Contains("clearlogo"))
                        {
                            strPic.Add(reader.Value);
                            txtXML.AppendText(reader.Value + Environment.NewLine);
                        }
                    }//if
                }//while
            }//for
            MessageBox.Show("Time to download pics...");
            pointer = 0;

            WebClient webClient = new WebClient();

            string destinationFile;
            foreach (string i in strPic)
            {
                destinationFile = "E:\\" + pointer++ + ".jpg";
                webClient.DownloadFile("http://thegamesdb.net/banners/" + i, destinationFile);
            }
        }
    }
}
