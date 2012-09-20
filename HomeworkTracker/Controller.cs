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

        private List<AssignmentDay> days;
        private GroupBox box;

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

            box = b;
            days = new List<AssignmentDay>();
            go();
        }

        public void go()
        {
            check();

            for (int i = 0; i < 5; i++)
            {
                int anX = 0;
                if (i == 0)
                    anX = 10;
                else
                    anX = 10 + days[i - 1].gb.Location.X + days[i - 1].gb.Width + 20;

                AssignmentDay temp = new AssignmentDay(box, i, anX);
                temp.go();
                days.Add(temp);
            }
        }

        public void goNext()
        {
            for (int i = 5; i < 10; i++)
            {
                int anX = 0;
                if (i == 5)
                    anX = 10;
                else
                    anX = 10 + days[i - 6].gb.Location.X + days[i - 6].gb.Width + 20;

                AssignmentDay temp = new AssignmentDay(box, i, anX);
                temp.go();
                days.Add(temp);
            }
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
            start.AddDays(3);
            for (int i = 5; i < 10; i++)
            {
                StreamWriter writer = new StreamWriter(filePath + i + ".txt");
                writer.WriteLine(start.ToShortDateString());
                writer.Close();
                start = start.AddDays(1);
            }
        }
        
        public void reset()
        {
            foreach (AssignmentDay item in days)
            {
                item.reset();
            }
            days = new List<AssignmentDay>();
        }

    }
}
