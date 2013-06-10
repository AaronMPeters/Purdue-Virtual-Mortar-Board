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
using System.IO;

namespace HomeworkTracker
{
    public partial class Form1 : Form
    {
        private string filePath = "C:\\Users\\" + Environment.UserName + "\\Documents\\Data\\Homework\\";

        private Controller myControl;
        private bool lastFridayVisible = false;
        private bool isHelping = false;
        private bool fortunesOn = true;
        private bool repeatVisible = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getFortune();
            gbMain.Height = this.Height - gbMain.Location.Y;
            gbMain.Width = this.Width - gbMain.Location.X;
            myControl = new Controller(gbMain, label3);
        }

        public float f(int x) { return x * 4; }

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

        private void showHelpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gbHelp.Visible == false)
            {
                labFortunes.Visible = false; //Hidiing fortune
                gbHelp.Visible = true;
                MessageBox.Show("Adding New Assignment:\r\n" +
                     "To add a new assignment, type in its name an click 'add'.\r\n" +
                     "NOTE: DO NOT NAME TWO ASSIGNMENTS WITH THE EXACT SAME NAME! If you need to, add an underscore. Ex: 'Assignment1' and 'Assignment_1' is an acceptable combination.\r\n" +
                     "\r\nMarking an Assignment Complete:\r\n" +
                     "By default, incomplete assignments are white. To mark an assignment as completed, simply left-click on the assignment to change its status. It will then turn red.\r\n" +
                     "\r\nChanging Priorities:\r\n" +
                     "To move an assignment down on the list, right click on the assignment." +
                     "\r\n\r\nDeleting an Assignment:\r\n" +
                     "To delete an assignment, first mark the item as complete by left-clicking on it. Then, left-click it again and you will be prompted on whether or not you would like to delete that assignment. " +
                     "Click 'yes'.\r\n" +
                     "\r\nPast, Current, and Future Days:\r\n" +
                     "Past days are highlighted in light grey; current date in dark grey; and future dates in black"
                     , "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Repeating Assignments:\r\n" +
                    "You have the option to add repeating assignments. These assignments will always be added every week unless you delete them. This makes it so you don't have to manually enter in repeating assignments." +
                    "\r\n\r\nViewing/Hiding Repeating Assignments:\r\n" +
                    "Click 'View Repeating Assignments' under the 'View' item on the menu bar. Then, you can add repeating assignments just as you would normal assignments. They will initially show up white. Now click 'Hide Repeating Assignments' under 'View' to let the changes take effect." +
                    " When you open Repeating Assignments in the future, they will be highlighted red." +
                    "\r\n\r\nChanging when the Assignment Takes Effect:\r\n" +
                    "By default, your new repeating assignment will take effect immediately and will be added once you click 'Hide Repeating Assignments'. You can change this so that it won't take effect until next week. To do this, simply left-click on the assignment when it is white (first created)." +
                    "\r\n\r\nDeleting Repeating Assignment:\r\n" +
                    "You can delete a repeating assignment at any time by left-clicking on it when it is red. (If you just created it and it is white, you will have to click on the assignment, answer 'no' when prompted on the effect option, and finally left-click on it again.) From then on, it will no longer be added to future weeks.",
                    "Repeating Assignments Help",
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
                showHelpToolStripMenuItem1.Text = "Hide Help";
            }
            else
            {
                labFortunes.Visible = true; //Show fortune
                showHelpToolStripMenuItem1.Text = "Show Help";
                gbHelp.Visible = false;
            }
        }

        private void getFortune()
        {
            StreamReader reader = new StreamReader(filePath + "Fortunes.txt");
            if (reader.ReadLine().ToUpper().Equals("OFF"))
            {
                fortunesOn = false;
                turnFortunesOffToolStripMenuItem.Text = "Turn Fortunes On";

                labFortunes.Visible = false;
                reader.Close();
                return;
            }
            else
            {
                fortunesOn = true;
                turnFortunesOffToolStripMenuItem.Text = "Turn Fortunes Off";
                labFortunes.Visible = true;
            }

            Random gen = new Random();
            int max = gen.Next(291);
            for (int i = 0; i < max; i++)
            {
                reader.ReadLine();
            }
            labFortunes.Text = "Your Fortune Cookie of the Day:\r\n" + reader.ReadLine();
            
            reader.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void turnFortunesOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(filePath + "Fortunes.txt");
            reader.ReadLine();

            List<string> info = new List<string>();
            while (!reader.EndOfStream)
                info.Add(reader.ReadLine());
            reader.Close();

            StreamWriter writer = new StreamWriter(filePath + "Fortunes.txt");

            if (!fortunesOn)
            {
                writer.WriteLine("On");
                foreach (string item in info)
                    writer.WriteLine(item);
            }
            else
            {
                writer.WriteLine("Off");
                foreach (string item in info)
                    writer.WriteLine(item);
            }
            writer.Close();
            getFortune();
        }

        private void showRepeatingAssignmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myControl.buildRepeating(repeatVisible);

            if (repeatVisible)
                showRepeatingAssignmentsToolStripMenuItem.Text = "Show Repeating Assignments";
            else
                showRepeatingAssignmentsToolStripMenuItem.Text = "Hide Repeating Assignments";

            repeatVisible = !repeatVisible;
        }

        private void buildInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(labelInfo.Text + "\r\nProgram Created by Aaron Peters" +
                "\r\n\r\nChanges for this build: " +
                "Repeating Assignments error fixed, Repeating Wipe out Assignments error fixed",
                "Build Information",
                MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}