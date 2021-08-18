using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace flex_system_last
{
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "5el7PEgL8sOhY7uACJt9VRYHtaC1O3No9nLXE02z",
            BasePath = "https://flex-system-30389.firebaseio.com/",

        };
        IFirebaseClient client;
        int limit;
        private void Attendance_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            client = new FireSharp.FirebaseClient(config);

            try
            {
                FirebaseResponse get = client.Get(@"Information/Counter/Students/count");
                Counter c1 = get.ResultAs<Counter>();
                Folder folder = new Folder();
                limit = c1.Count;
                for (int i=1;i<=c1.Count;i++)
                {
                    try
                    {
                        FirebaseResponse response = client.Get(@"Information/Counter/ID/" + i.ToString());
                        folder = response.ResultAs<Folder>();
                        try
                        {
                            FirebaseResponse res = client.Get(@"Information/student/" + folder.tempID);
                            Student s1 = res.ResultAs<Student>();
                            dataGridView1.Rows.Add();
                            dataGridView1[0, i - 1].Value = s1.Id;
                            dataGridView1[1, i - 1].Value = s1.Name;
                            dataGridView1[2, i - 1].Value = s1.Attendance.ToString();
                            if (i == 1)
                            {
                                textBox1.Text = s1.Id;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int n = 0;
        private Teacher teacher;

        private void OK_Click(object sender, EventArgs e)
        {
            //Student student;
            try
            {
                FirebaseResponse firebaseResponse = client.Get(@"Information/student/" + textBox1.Text);
                Student student = firebaseResponse.ResultAs<Student>();
                if (checkBox1.Checked == true)
                {
                    if(student.Attendance == 0.0 || student.Attendance == 100)
                    {
                        student.Attendance = 100;
                    }
                    else
                    {
                        student.Attendance += 1;
                    }
                   
                }
                else
                {
                    if (student.Attendance == 0.0)
                    {
                        student.Attendance = 0.0;
                    }
                    else
                    {
                        student.Attendance -= 1;
                    }
                }
                try
                {
                    FirebaseResponse response = client.Set(@"Information/student/" + textBox1.Text, student);
                    //student = response.ResultAs<Student>();
                    MessageBox.Show("Attendace Marked!");
                    dataGridView1[2, n].Value = student.Attendance.ToString();
                }
                catch
                {

                }
            }
            catch
            {

            }
        }

        private void NEXT_Click(object sender, EventArgs e)
        {
            n++;
            if (n >= limit)
            {
                MessageBox.Show("No More Student Remained");
            }
            else
            {
                textBox1.Text = dataGridView1[0, n].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homef at = new Homef(teacher);
            {
                at.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search at = new Search(teacher);
            {
                at.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            News at = new News(teacher);
            {
                at.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete at = new Delete(teacher);
            {
                at.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marks at = new Marks();
            {
                at.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logint f = new Logint();
            {
                f.Show();
            }
        }
    }
}
