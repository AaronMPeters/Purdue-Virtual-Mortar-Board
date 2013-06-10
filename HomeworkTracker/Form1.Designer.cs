namespace HomeworkTracker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnFortunesOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLastFidayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRepeatingAssignmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHelpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buildInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbHelp = new System.Windows.Forms.GroupBox();
            this.labFortunes = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.changeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1956, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turnFortunesOffToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // turnFortunesOffToolStripMenuItem
            // 
            this.turnFortunesOffToolStripMenuItem.Name = "turnFortunesOffToolStripMenuItem";
            this.turnFortunesOffToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.turnFortunesOffToolStripMenuItem.Text = "Turn Fortunes Off";
            this.turnFortunesOffToolStripMenuItem.Click += new System.EventHandler(this.turnFortunesOffToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLastFidayToolStripMenuItem,
            this.showRepeatingAssignmentsToolStripMenuItem});
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.changeToolStripMenuItem.Text = "View";
            // 
            // viewLastFidayToolStripMenuItem
            // 
            this.viewLastFidayToolStripMenuItem.Name = "viewLastFidayToolStripMenuItem";
            this.viewLastFidayToolStripMenuItem.Size = new System.Drawing.Size(273, 24);
            this.viewLastFidayToolStripMenuItem.Text = "Show Last Fiday";
            this.viewLastFidayToolStripMenuItem.Click += new System.EventHandler(this.viewLastFidayToolStripMenuItem_Click);
            // 
            // showRepeatingAssignmentsToolStripMenuItem
            // 
            this.showRepeatingAssignmentsToolStripMenuItem.Name = "showRepeatingAssignmentsToolStripMenuItem";
            this.showRepeatingAssignmentsToolStripMenuItem.Size = new System.Drawing.Size(273, 24);
            this.showRepeatingAssignmentsToolStripMenuItem.Text = "Show Repeating Assignments";
            this.showRepeatingAssignmentsToolStripMenuItem.Click += new System.EventHandler(this.showRepeatingAssignmentsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHelpToolStripMenuItem1,
            this.buildInformationToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // showHelpToolStripMenuItem1
            // 
            this.showHelpToolStripMenuItem1.Name = "showHelpToolStripMenuItem1";
            this.showHelpToolStripMenuItem1.Size = new System.Drawing.Size(194, 24);
            this.showHelpToolStripMenuItem1.Text = "Show Help";
            this.showHelpToolStripMenuItem1.Click += new System.EventHandler(this.showHelpToolStripMenuItem1_Click);
            // 
            // buildInformationToolStripMenuItem
            // 
            this.buildInformationToolStripMenuItem.Name = "buildInformationToolStripMenuItem";
            this.buildInformationToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.buildInformationToolStripMenuItem.Text = "Build Information";
            this.buildInformationToolStripMenuItem.Click += new System.EventHandler(this.buildInformationToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(902, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(911, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Program Created by Aaron Peters";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.Black;
            this.labelInfo.ForeColor = System.Drawing.Color.White;
            this.labelInfo.Location = new System.Drawing.Point(986, 151);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(80, 17);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = "Version 5.5";
            // 
            // gbMain
            // 
            this.gbMain.AutoSize = true;
            this.gbMain.BackColor = System.Drawing.Color.Transparent;
            this.gbMain.BackgroundImage = global::HomeworkTracker.Properties.Resources.purdue_p3;
            this.gbMain.Location = new System.Drawing.Point(12, 192);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(923, 293);
            this.gbMain.TabIndex = 5;
            this.gbMain.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell Extra Bold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1140, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(816, 56);
            this.label3.TabIndex = 8;
            this.label3.Text = "Thursday, November 1 2012";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DimGray;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(290, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 96);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(17, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Red means it\'s done";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "White means incomplete";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Location = new System.Drawing.Point(16, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 96);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Past Days";
            // 
            // groupBox3
            // 
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(575, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 96);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Future Dates";
            // 
            // gbHelp
            // 
            this.gbHelp.BackColor = System.Drawing.Color.Black;
            this.gbHelp.Controls.Add(this.groupBox3);
            this.gbHelp.Controls.Add(this.groupBox2);
            this.gbHelp.Controls.Add(this.groupBox1);
            this.gbHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHelp.ForeColor = System.Drawing.Color.White;
            this.gbHelp.Location = new System.Drawing.Point(27, 31);
            this.gbHelp.Name = "gbHelp";
            this.gbHelp.Size = new System.Drawing.Size(860, 155);
            this.gbHelp.TabIndex = 7;
            this.gbHelp.TabStop = false;
            this.gbHelp.Text = "Help";
            this.gbHelp.Visible = false;
            // 
            // labFortunes
            // 
            this.labFortunes.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFortunes.Location = new System.Drawing.Point(20, 40);
            this.labFortunes.Name = "labFortunes";
            this.labFortunes.Size = new System.Drawing.Size(867, 152);
            this.labFortunes.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(1354, 680);
            this.Controls.Add(this.labFortunes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbHelp);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purdue Virtual Mortar Board";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbHelp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ToolStripMenuItem viewLastFidayToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem showRepeatingAssignmentsToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHelpToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbHelp;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label labFortunes;
        private System.Windows.Forms.ToolStripMenuItem turnFortunesOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildInformationToolStripMenuItem;

    }
}

