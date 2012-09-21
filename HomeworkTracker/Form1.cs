using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml.Serialization;

namespace HomeworkTracker
{
    public partial class Form1 : Form
    {
        private Controller myControl;
        private bool lastFridayVisible = false;
        private bool isHelping = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gbMain.Height = this.Height - gbMain.Location.Y;
            gbMain.Width = this.Width - gbMain.Location.X;
            myControl = new Controller(gbMain);
        }

        private void viewLastFidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!lastFridayVisible)
            {
                lastFridayVisible = true;
                viewLastFidayToolStripMenuItem.Text = "Hide Last Friday";
                myControl.lastFriday(false);
            }
            else
            {
                lastFridayVisible = false;
                viewLastFidayToolStripMenuItem.Text = "View Last Friday";
                myControl.lastFriday(true);
            }
        }

        private void shoeHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gbHelp.Visible == false)
            {
                gbHelp.Visible = true;
                shoeHelpToolStripMenuItem.Text = "Hide Help";
            }
            else
            {
                shoeHelpToolStripMenuItem.Text = "Show Help";
                gbHelp.Visible = false;
            }
        }
    }
}