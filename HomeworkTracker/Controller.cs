using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HomeworkTracker
{
    class Controller
    {
        private string filePath = "C:\\Users\\" + Environment.UserName + "\\Documents\\Data\\Homework\\";
        private const int CHANGE_Y = 30;
        private bool isRepeatingVisible, isFridayVisible;

        private List<AssignmentDay> days, repeatingDays;
        private GroupBox parent, firstWeek, secondWeek, friday, repeating;
        private AssignmentDay lstFriday;
        private Controller toPass;
        private Label date, labDirections;

        public Controller(GroupBox b, Label date)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\Documents\\Data\\Homework\\");
                for (int i = 0; i < 10; i++)
                {
                    StreamWriter sw = new StreamWriter(filePath + i + ".txt");
                    sw.Close();
                }

                //Writing for last friday:
                DateTime start = DateTime.Now;
                while (!start.DayOfWeek.ToString().Equals("Monday"))
                    start = start.AddDays(-1);

                start = start.AddDays(-3);
                StreamWriter sw2 = new StreamWriter(filePath + "10.txt");
                sw2.WriteLine(start.ToShortDateString());
                sw2.Close();
            }

            this.date = date;
            parent = b;
            days = new List<AssignmentDay>();
            repeatingDays = new List<AssignmentDay>();
            go();
        }

        public void go()
        {
            check();

            readRepeating();

            buildFirstWeek();
            buildSecondWeek();

            date.Text = DateTime.Now.ToString("dddd, MMMM") + " " + DateTime.Now.Day + "\r\n" + DateTime.Now.Year;
            date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
                lastFriday(false);
        }
        
        private void buildFirstWeek()
        {
            firstWeek = new GroupBox();
            firstWeek.AutoSize = true;
            firstWeek.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            firstWeek.BackColor = System.Drawing.Color.Black;
            firstWeek.Location = new System.Drawing.Point(10, 10);
            firstWeek.Name = "gbWeek1";
            firstWeek.Size = new System.Drawing.Size(1810, 280);
            parent.Controls.Add(firstWeek);

            //firstWeek.SizeChanged += new EventHandler(changeSize);

            for (int i = 0; i < 5; i++)
            {
                int anX = 0;
                if (i == 0)
                    anX = 10;
                else
                    anX = 10 + days[i - 1].gb.Location.X + days[i - 1].gb.Width + 20;

                AssignmentDay temp = new AssignmentDay(firstWeek, i, anX);
                temp.go();
                days.Add(temp);
            }
        }

        public void buildRepeating(bool hide)
        {
            isRepeatingVisible = !hide;

            if (!hide)
            {
                repeating = new GroupBox();
                repeating.AutoSize = true;
                repeating.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                repeating.BackColor = System.Drawing.Color.Black;
                repeating.ForeColor = System.Drawing.Color.White;
                
                if (isFridayVisible)
                    repeating.Location = new System.Drawing.Point(friday.Location.X, friday.Location.Y + friday.Height + CHANGE_Y);
                else
                    repeating.Location = new System.Drawing.Point(secondWeek.Location.X, secondWeek.Location.Y + secondWeek.Height + CHANGE_Y * 4);

                repeating.Text = "Repeating Assignments";
                repeating.Name = "gbWeek2";
                repeating.Size = new System.Drawing.Size(1810, 280);
                parent.Controls.Add(repeating);

                labDirections = new Label();
                labDirections.AutoSize = true;
                labDirections.ForeColor = System.Drawing.Color.DarkGoldenrod;
                labDirections.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labDirections.Location = new System.Drawing.Point(20, 20);
                labDirections.Name = "labDirections";
                labDirections.Size = new System.Drawing.Size(1379, 33);
                labDirections.TabIndex = 9;
                labDirections.Text = "If you don\'t want your repeating assignment (when you first create it) to take effect until the next week, l" +
                    "eft-click on it once";
                repeating.Controls.Add(labDirections);

                for (int i = 20; i < 25; i++)
                {
                    int anX = 0;
                    if (i == 20)
                        anX = 10;
                    else
                        anX = 10 + days[i - 21].gb.Location.X + days[i - 21].gb.Width + 20;

                    AssignmentDay temp = new AssignmentDay(repeating, i, anX);

                    temp.go();
                    repeatingDays.Add(temp);
                }
            }
            else
            {
                reset();
                go();
            }
        }

        private void buildSecondWeek()
        {
            secondWeek = new GroupBox();
            secondWeek.AutoSize = true;
            secondWeek.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            secondWeek.BackColor = System.Drawing.Color.Black;
            secondWeek.Location = new System.Drawing.Point(firstWeek.Location.X, firstWeek.Location.Y + firstWeek.Height + CHANGE_Y * 4);
            secondWeek.Name = "gbWeek2";
            secondWeek.Size = new System.Drawing.Size(1810, 280);
            parent.Controls.Add(secondWeek);

            for (int i = 5; i < 10; i++)
            {
                int anX = 0;
                if (i == 5)
                    anX = 10;
                else
                    anX = 10 + days[i - 6].gb.Location.X + days[i - 6].gb.Width + 20;

                AssignmentDay temp = new AssignmentDay(secondWeek, i, anX);


                temp.go();
                days.Add(temp);
            }
        }

        private void changeSize(object sender, EventArgs e)
        {
            secondWeek.Location = secondWeek.Location = new System.Drawing.Point(firstWeek.Location.X, firstWeek.Location.Y + firstWeek.Height + CHANGE_Y);
        }

        /// <summary>
        /// Checks to see if the program needs to call replace() or replaceWipeOut() or neither depending on how long it has 
        /// been since the user last opened the program.
        /// </summary>
        private void check()
        {
            StreamReader sr = new StreamReader(filePath + "0.txt");
            DateTime read = Convert.ToDateTime(sr.ReadLine());
            sr.Close();

            if (Convert.ToInt32((DateTime.Now - read).Days) >= 5)
            {
                if (Convert.ToInt32((DateTime.Now - read).Days) >= 12)
                    replaceWipeOut();
                else
                    replace();
            }
        }

        /// <summary>
        /// Called when the program is normally replacing tasks
        /// </summary>
        private void replace()
        {
            File.Delete(filePath + "10.txt"); //Deleting old 'last friday'
            File.Copy(filePath + "4.txt", filePath + "10.txt"); //Copy new friday to 'last friday'

            for (int i = 0; i < 5; i++) //Deletes the old week
                File.Delete(filePath + i + ".txt");

            for (int i = 5; i < 10; i++) //Copies the new 2nd week to the 1st week
                File.Copy(filePath + i + ".txt", filePath + (i - 5) + ".txt");

            for (int i = 5; i < 10; i++) //Deletes the old 1st week
                File.Delete(filePath + i + ".txt");

            DateTime start = DateTime.Now.AddDays(7); //The start day needs to be at least 7 days in advance

            //Adding days until it was Monday:
            if (start.DayOfWeek.ToString().Equals("Saturday")) 
                   start = start.AddDays(2);
            else if (start.DayOfWeek.ToString().Equals("Sunday"))
                start = start.AddDays(1);
            else
            {
                while (!start.DayOfWeek.ToString().Equals("Monday"))
                    start = start.AddDays(-1);
            }

            for (int i = 5; i < 10; i++)
            {
                StreamReader repeatingReader = new StreamReader(filePath + (i + 15) + ".txt"); //Adding and reading repeating tasks
                List<string> info = new List<string>();
                repeatingReader.ReadLine();

                while (!repeatingReader.EndOfStream)
                {
                    info.Add(repeatingReader.ReadLine());
                    repeatingReader.ReadLine();
                    info.Add("0");
                }
                repeatingReader.Close();

                StreamWriter writer = new StreamWriter(filePath + i + ".txt");
                writer.WriteLine(start.ToShortDateString());

                foreach (string item in info)
                {
                    writer.WriteLine(item); //Writes the repeating asignments
                }

                writer.Close();
                start = start.AddDays(1);
            }
        }

        /// <summary>
        /// Called when the program has not been updated for >= 2 weeks and every file needs to be wiped out
        /// </summary>
        private void replaceWipeOut()
        {
            for (int i = 0; i < 11; i++)
                File.Delete(filePath + i + ".txt");

            DateTime start = DateTime.Now;

            if (start.DayOfWeek.ToString().Equals("Saturday"))
                start = start.AddDays(2);
            else if (start.DayOfWeek.ToString().Equals("Sunday"))
                start = start.AddDays(1);
            else
            {
                while (!start.DayOfWeek.ToString().Equals("Monday"))
                    start = start.AddDays(-1);
            }

            //Adding the file for last friday
            start = start.AddDays(-3);
            StreamWriter lastFriday = new StreamWriter(filePath + "10.txt");
            lastFriday.WriteLine(start.ToShortDateString());
            lastFriday.Close();
            start = start.AddDays(3);

            for (int i = 0; i < 5; i++)
            {
                StreamReader repeatingReader = new StreamReader(filePath + (i + 20) + ".txt"); //Repeating tasks
                List<string> info = new List<string>();
                repeatingReader.ReadLine();

                while (!repeatingReader.EndOfStream)
                {
                    info.Add(repeatingReader.ReadLine());
                    repeatingReader.ReadLine();
                    info.Add("0");
                }
                repeatingReader.Close();

                StreamWriter writer = new StreamWriter(filePath + i + ".txt");
                writer.WriteLine(start.ToShortDateString());

                foreach (string item in info)
                {
                    writer.WriteLine(item);
                }
                
                writer.Close();
                start = start.AddDays(1);
            }
            start = start.AddDays(2);
            for (int i = 5; i < 10; i++)
            {
                StreamReader repeatingReader = new StreamReader(filePath + (i + 15) + ".txt"); //Repeating tasks
                List<string> info = new List<string>();
                repeatingReader.ReadLine();

                while (!repeatingReader.EndOfStream)
                {
                    info.Add(repeatingReader.ReadLine());
                    repeatingReader.ReadLine();
                    info.Add("0");
                }
                repeatingReader.Close();

                StreamWriter writer = new StreamWriter(filePath + i + ".txt");
                writer.WriteLine(start.ToShortDateString());

                foreach (string item in info)
                {
                    writer.WriteLine(item);
                }

                writer.Close();

                start = start.AddDays(1);
            }
        }

        public void lastFriday(bool hide)
        {
            isFridayVisible = !hide;

            if (!hide)
            {
                friday = new GroupBox();
                friday.AutoSize = true;
                friday.BackColor = System.Drawing.Color.DarkGoldenrod;
                friday.ForeColor = System.Drawing.Color.White;

                if (isRepeatingVisible)
                    friday.Location = new System.Drawing.Point(repeating.Location.X, repeating.Location.Y + repeating.Height + CHANGE_Y);
                else
                    friday.Location = new System.Drawing.Point(secondWeek.Location.X, secondWeek.Location.Y + secondWeek.Height + CHANGE_Y);

                friday.Name = "gbLastFriday";
                friday.Size = new System.Drawing.Size(403, 140);
                friday.Text = "Last";
                parent.Controls.Add(friday);

                lstFriday = new AssignmentDay(friday, 10, 20);
                lstFriday.go();
            }
            else
            {
                lstFriday.reset();
                friday.Visible = false;
                parent.Controls.Remove(friday);
            }
        }

        public void reset()
        {
            secondWeek.Location = new System.Drawing.Point(firstWeek.Location.X, firstWeek.Location.Y + firstWeek.Height + CHANGE_Y);
            firstWeek.Visible = false;
            secondWeek.Visible = false;
            repeating.Visible = false;
            labDirections.Visible = false;
            parent.Controls.Remove(firstWeek);
            parent.Controls.Remove(secondWeek);
            parent.Controls.Remove(repeating);
            repeating.Controls.Remove(labDirections);
        }

        private void readRepeating()
        {
            for (int i = 20; i < 25; i++)
            {
                StreamReader sr = new StreamReader(filePath + i + ".txt");
                string date = sr.ReadLine();
                List<string> info = new List<string>();
                while (!sr.EndOfStream)
                {
                    info.Add(sr.ReadLine());
                }
                sr.Close();

                StreamWriter writerBack = new StreamWriter(filePath + i + ".txt");
                writerBack.WriteLine(date);

                StreamWriter sw = new StreamWriter(filePath + (i - 15) + ".txt", true);
                for (int x = 0; x < info.Count; x += 2)
                {
                    string assignment = info[x];
                    int num = Convert.ToInt32(info[x + 1]);

                    if (num == 0)
                    {
                        sw.WriteLine(assignment);
                        sw.WriteLine("0");

                        writerBack.WriteLine(assignment);
                        writerBack.WriteLine("1");
                    }
                    else
                    {
                        writerBack.WriteLine(assignment);
                        writerBack.WriteLine("1");
                    }
                }
                sw.Close();
                writerBack.Close();

                StreamWriter sw2 = new StreamWriter(filePath + (i - 20) + ".txt", true);
                for (int x = 0; x < info.Count; x += 2)
                {
                    string assignment = info[x];
                    int num = Convert.ToInt32(info[x + 1]);

                    if (num == 0)
                    {
                        sw2.WriteLine(assignment);
                        sw2.WriteLine("0");
                    }
                }
                sw2.Close();
            }
        }
    }
}
