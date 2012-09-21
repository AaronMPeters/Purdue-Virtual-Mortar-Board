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

        private List<AssignmentDay> days;
        private GroupBox parent, firstWeek, secondWeek, friday;
        private AssignmentDay lstFriday;
        private Controller toPass;

        public Controller(GroupBox b)
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

            parent = b;
            days = new List<AssignmentDay>();
            go();
        }

        public void go()
        {
            check();
            buildFirstWeek();
            buildSecondWeek();
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

        private void replace()
        {
            File.Delete(filePath + "10.txt");
            File.Copy(filePath + "4.txt", filePath + "10.txt");

            for (int i = 0; i < 5; i++)
                File.Delete(filePath + i + ".txt");

            for (int i = 5; i < 10; i++)
                File.Copy(filePath + i + ".txt", filePath + (i - 5) + ".txt");

            for (int i = 5; i < 10; i++)
                File.Delete(filePath + i + ".txt");

            DateTime start = DateTime.Now.AddDays(7);

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
                StreamWriter writer = new StreamWriter(filePath + i + ".txt");
                writer.WriteLine(start.ToShortDateString());
                writer.Close();
                start = start.AddDays(1);
            }
        }

        private void replaceWipeOut()
        {
            for (int i = 0; i < 10; i++)
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

            for (int i = 0; i < 5; i++)
            {
                StreamWriter writer = new StreamWriter(filePath + i + ".txt");
                writer.WriteLine(start.ToShortDateString());
                writer.Close();
                start = start.AddDays(1);
            }
            start = start.AddDays(2);
            for (int i = 5; i < 10; i++)
            {
                StreamWriter writer = new StreamWriter(filePath + i + ".txt");
                writer.WriteLine(start.ToShortDateString());
                writer.Close();
                start = start.AddDays(1);
            }
        }

        public void lastFriday(bool hide)
        {
            if (!hide)
            {
                friday = new GroupBox();
                friday.AutoSize = true;
                friday.BackColor = System.Drawing.Color.DarkGoldenrod;
                friday.ForeColor = System.Drawing.Color.White;
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
            parent.Controls.Remove(firstWeek);
            parent.Controls.Remove(secondWeek);
        }

    }
}
