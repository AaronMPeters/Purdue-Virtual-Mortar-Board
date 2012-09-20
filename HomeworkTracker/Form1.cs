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
        private AssignmentDay friday;
        private Controller myControl;
        private bool isNextWeek = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myControl = new Controller(groupBox1);            
        }

        private void lastWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isNextWeek)
            {
                isNextWeek = true;
                lastWeekToolStripMenuItem.Text = "Last Week";

                myControl.reset();
                myControl.goNext();
            }
            else
            {
                isNextWeek = false;
                lastWeekToolStripMenuItem.Text = "Next Week";

                myControl.reset();
                myControl.go();
            }
        }

        private void viewLastFidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gbLastFriday.Visible)
            {
                gbLastFriday.Visible = true;
                viewLastFidayToolStripMenuItem.Text = "Hide Last Friday";
                if (friday != null)
                    friday.reset();
                friday = new AssignmentDay(gbLastFriday, 10, 20);
                friday.go();
            }
            else
            {
                gbLastFriday.Visible = false;
                viewLastFidayToolStripMenuItem.Text = "View Last Friday";
            }
        }
    }
}
