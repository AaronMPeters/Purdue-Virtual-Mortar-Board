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
        private string myInfo;

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
            if (myNumber < 20)
                gb.Location = new Point(gbX, 30);
            else
                gb.Location = new Point(gbX, 30 + CHANGE_Y);

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
            newInformation.Size = new System.Drawing.Size(270, 30);
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
            if (Convert.ToInt32(myDate.CompareTo(DateTime.Today)) < 0)
            {
                gb.BackColor = Color.LightGray;
                gb.ForeColor = Color.Black;
            }
            else if (Convert.ToInt32(myDate.CompareTo(DateTime.Today)) == 0)
                gb.BackColor = Color.DimGray;


            gb.Text = myDate.DayOfWeek.ToString();
            if (myNumber < 20)   //Not a repeating day\
                gb.Text += "    (" + myDate.ToShortDateString() + ")";
            else
                gb.Text += "s";


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

                //temp.Click += new EventHandler(DELETE_CLICK);
                temp.MouseClick += new MouseEventHandler(changeStatus_Click);
                temp.MouseDoubleClick += new MouseEventHandler(movePriorityUp_DoubleClick);

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

        private void changeStatus_Click(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;

            if (e.Button == MouseButtons.Left && e.Button == MouseButtons.Right)
                MessageBox.Show("Congrats");
            else if (e.Button == MouseButtons.Left)
            {
                int num = Convert.ToInt32(label.Tag);

                List<string> info = new List<string>();

                StreamReader reader = new StreamReader(filePath + myNumber + ".txt");
                string test = reader.ReadLine();
                while (!test.Equals(label.Text))
                {
                    info.Add(test);
                    test = reader.ReadLine();
                }
                //info.add(test);
                reader.ReadLine(); //Reading the old 0 or 1

                if (label.ForeColor == Color.White)
                {
                    DialogResult ans2 = DialogResult.Abort;

                    if (myNumber >= 20)
                    {
                        ans2 = MessageBox.Show("By continuing, your new repeating assignments will not take effect until the next week. Is that what you are trying to do?", "Wait to Take Effect?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                    }
                    if (ans2 == DialogResult.Yes || myNumber < 20)
                    {
                        label.ForeColor = Color.Red;
                        info.Add(test);
                        info.Add("1");
                    }
                    else if (ans2 == DialogResult.No)
                    {
                        DialogResult ans = MessageBox.Show("Are you trying to delete this assignment?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.No)
                        {
                            info.Add(test);
                            info.Add("0");
                        }
                    }
                }
                else
                {
                    DialogResult ans = MessageBox.Show("Are you trying to delete this assignment?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.No)
                    {
                        if (myNumber < 20)
                        {
                            info.Add(test);
                            label.ForeColor = Color.White;
                            info.Add("0");
                        }
                        else
                        {
                            info.Add(test);
                            info.Add("1");
                        }
                    }
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
            else if (e.Button == MouseButtons.Right)
                changeOrderDown(label.Text);
        }

        private void changeOrderDown(string text)
        {
            List<string> beforeInfo = new List<string>();
            List<string> afterInfo = new List<string>();

            StreamReader reader = new StreamReader(filePath + myNumber + ".txt");
            string test = reader.ReadLine();
            while (!test.Equals(text))
            {
                beforeInfo.Add(test);
                test = reader.ReadLine();
            }
            afterInfo.Add(test);
            afterInfo.Add(reader.ReadLine());

            string tester = reader.ReadLine();
            if (tester == null)
            {
                reader.Close();
                MessageBox.Show("You cannot move this item any further down. It is already at the end of the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            beforeInfo.Add(tester);
            beforeInfo.Add(reader.ReadLine());

            while (!reader.EndOfStream)
                afterInfo.Add(reader.ReadLine());

            reader.Close();

            StreamWriter write = new StreamWriter(filePath + myNumber + ".txt");
            foreach (string item in beforeInfo)
                write.WriteLine(item);
            foreach (string item in afterInfo)
                write.WriteLine(item);

            write.Close();

            reset();
            go();
        }

        private void movePriorityUp_DoubleClick(object sender, MouseEventArgs e)
        {
            changeOrderUp(((Label)sender).Text);
            changeOrderUp(((Label)sender).Text);
        }

        private void changeOrderUp(string text)
        {
            List<string> beforeInfo = new List<string>();
            List<string> afterInfo = new List<string>();

            StreamReader reader = new StreamReader(filePath + myNumber + ".txt");
            string test = reader.ReadLine();
            while (!test.Equals(text))
            {
                beforeInfo.Add(test);
                test = reader.ReadLine();
            }

            if (beforeInfo.Count == 1)
            {
                reader.Close();
                MessageBox.Show("You cannot move this item any further up. It is already at the top of the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            afterInfo.Add(beforeInfo[beforeInfo.Count - 2]);
            afterInfo.Add(beforeInfo[beforeInfo.Count - 1]);
            beforeInfo[beforeInfo.Count - 2] = test;
            beforeInfo[beforeInfo.Count - 1] = reader.ReadLine();

            while (!reader.EndOfStream)
                afterInfo.Add(reader.ReadLine());

            reader.Close();

            StreamWriter write = new StreamWriter(filePath + myNumber + ".txt");
            foreach (string item in beforeInfo)
                write.WriteLine(item);
            foreach (string item in afterInfo)
                write.WriteLine(item);

            write.Close();

            reset();
            go();
        }

        private void select_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                changeOrderUp(myInfo);
            else if (e.KeyData == Keys.Down)
                changeOrderDown(myInfo);
        }
    }
}