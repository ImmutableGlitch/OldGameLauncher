namespace projGameLauncherCsharp
{
    partial class frmGameDatabaseMiner
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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnGetID = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtXML = new System.Windows.Forms.TextBox();
            this.btnPrintXml = new System.Windows.Forms.Button();
            this.btnGrab = new System.Windows.Forms.Button();
            this.btnContains = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(265, 32);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(65, 445);
            this.txtOutput.TabIndex = 0;
            // 
            // btnGetID
            // 
            this.btnGetID.Location = new System.Drawing.Point(335, 187);
            this.btnGetID.Name = "btnGetID";
            this.btnGetID.Size = new System.Drawing.Size(75, 23);
            this.btnGetID.TabIndex = 1;
            this.btnGetID.Text = "Get ID";
            this.btnGetID.UseVisualStyleBackColor = true;
            this.btnGetID.Click += new System.EventHandler(this.btnGetID_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(416, 188);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(125, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Enter game to search";
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(2, 32);
            this.txtXML.Multiline = true;
            this.txtXML.Name = "txtXML";
            this.txtXML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXML.Size = new System.Drawing.Size(263, 445);
            this.txtXML.TabIndex = 3;
            // 
            // btnPrintXml
            // 
            this.btnPrintXml.Location = new System.Drawing.Point(2, 483);
            this.btnPrintXml.Name = "btnPrintXml";
            this.btnPrintXml.Size = new System.Drawing.Size(214, 23);
            this.btnPrintXml.TabIndex = 4;
            this.btnPrintXml.Text = "Print XML for images then download them";
            this.btnPrintXml.UseVisualStyleBackColor = true;
            this.btnPrintXml.Click += new System.EventHandler(this.btnPrintXml_Click);
            // 
            // btnGrab
            // 
            this.btnGrab.Location = new System.Drawing.Point(2, 3);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(172, 23);
            this.btnGrab.TabIndex = 5;
            this.btnGrab.Text = "ID and Names";
            this.btnGrab.UseVisualStyleBackColor = true;
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // btnContains
            // 
            this.btnContains.Location = new System.Drawing.Point(335, 256);
            this.btnContains.Name = "btnContains";
            this.btnContains.Size = new System.Drawing.Size(121, 23);
            this.btnContains.TabIndex = 6;
            this.btnContains.Text = "Test string contains";
            this.btnContains.UseVisualStyleBackColor = true;
            this.btnContains.Click += new System.EventHandler(this.btnContains_Click);
            // 
            // frmGameDatabaseMiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 511);
            this.Controls.Add(this.btnContains);
            this.Controls.Add(this.btnGrab);
            this.Controls.Add(this.btnPrintXml);
            this.Controls.Add(this.txtXML);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnGetID);
            this.Controls.Add(this.txtOutput);
            this.Name = "frmGameDatabaseMiner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game image Grabber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnGetID;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.Button btnPrintXml;
        private System.Windows.Forms.Button btnGrab;
        private System.Windows.Forms.Button btnContains;
    }
}