using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace HomeworkTracker
{
    class AssignmentDay
    {
        private string filePath = "C:\\Users\\" + Environment.UserName + "\\Documents\\Data\\Homework\\";
        private const int CHANGE_Y = 30;
        private const int MY_X = 10;

        private DateTime myDate;
        private List<Label> labels;
        private TextBox newInformation;
        private Button newInformationGo;
        public GroupBox gb, parent;
        private int myNumber, gbX;

        public AssignmentDay(GroupBox par, int num, int x)
        {
            gbX = x;
            myNumber = num;
            parent = par;
            labels = new List<Label>();
        }

        public void go()
        {
            buildBoxes();
        }

        public void reset()
        {
            gb.Controls.Remove(newInformation);
            gb.Controls.Remove(newInformationGo);
            newInformation.Visible = false;
            newInformationGo.Visible = false;
            foreach (Label item in labels)
            {
                item.Visible = false;
                gb.Controls.Remove(item);
            }

            parent.Controls.Remove(gb);
            gb.Visible = false;

            labels = new List<Label>();
            newInformationGo = new Button();
            newInformation = new TextBox();
            gb = new GroupBox();
        }

        private void buildBoxes()
        {
            gb = new GroupBox();
            gb.Location = new Point(gbX, 30);
            gb.Name = "groupBox1";
            gb.Size = new System.Drawing.Size(100, 100);
            gb.ForeColor = Color.White;
            gb.AutoSize = true;
            gb.TabStop = false;
            parent.Controls.Add(gb);

            int myY = 30;
            newInformation = new TextBox();
            newInformation.Location = new System.Drawing.Point(MY_X, myY);
            newInformation.Name = "textBox1"; 
            newInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newInformation.Size = new System.Drawing.Size(300, 30);
            newInformation.TabIndex = myNumber;
            gb.Controls.Add(newInformation);

            newInformationGo = new Button();
            newInformationGo.Location = new Point(newInformation.Location.X + newInformation.Width + 10, myY);
            newInformationGo.Name = "add";
            newInformationGo.Size = new System.Drawing.Size(50, 23);
            newInformationGo.Text = "Add";
            newInformationGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newInformationGo.BackColor = Color.Black;
            newInformationGo.ForeColor = Color.White;
            newInformationGo.AutoSize = true;
            gb.Controls.Add(newInformationGo);
            newInformationGo.Click += new EventHandler(add_Click);

            myY += CHANGE_Y;

            StreamReader sr = new StreamReader(filePath + myNumber + ".txt");
            myDate = Convert.ToDateTime(sr.ReadLine());
            gb.Text = myDate.DayOfWeek.ToString() + "    (" + myDate.ToShortDateString() + ")";

            int i = 0;
            while (!sr.EndOfStream)
            {
                Label temp = new Label();
                temp.AutoSize = true;
                temp.Location = new System.Drawing.Point(MY_X, myY);
                temp.ForeColor = Color.White;
                temp.Name = "labelTemp";
                temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                temp.Size = new System.Drawing.Size(46, 17);
                temp.Tag = i;
                temp.Text = sr.ReadLine();

                if (sr.ReadLine().Equals("1"))
                    temp.ForeColor = Color.Red;

                temp.Click += new EventHandler(DELETE_CLICK);

                gb.Controls.Add(temp);
                labels.Add(temp);

                i++;
                myY += CHANGE_Y;
            }
            sr.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(filePath + myNumber + ".txt", true);
            if (newInformation.Text.Equals(""))
            {
                MessageBox.Show("Please enter something first");
                return;
            }
            sw.WriteLine(newInformation.Text);
            sw.WriteLine("0");
            sw.Close();

            newInformation.Clear();
            reset();
            go();
        }

        private void DELETE_CLICK(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            int num = Convert.ToInt32(label.Tag);


            List<string> info = new List<string>();

            StreamReader reader = new StreamReader(filePath + myNumber + ".txt");
            string test = reader.ReadLine();
            while (!test.Equals(label.Text))
            {
                info.Add(test);
                test = reader.ReadLine();
            }
            info.Add(test);
            reader.ReadLine(); //Reading the old 0 or 1

            if (label.ForeColor == Color.White)
            {
                label.ForeColor = Color.Red;
                info.Add("1");
            }
            else
            {
                label.ForeColor = Color.White;
                info.Add("0");
            }

            while (!reader.EndOfStream)
                info.Add(reader.ReadLine());

            reader.Close();
            StreamWriter write = new StreamWriter(filePath + myNumber + ".txt");
            foreach (string item in info)
                write.WriteLine(item);
            write.Close();

            reset();
            go();
        }
    }
}
