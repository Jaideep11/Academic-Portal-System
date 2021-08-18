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
    public partial class Marks : Form
    {
        public Marks()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "5el7PEgL8sOhY7uACJt9VRYHtaC1O3No9nLXE02z",
            BasePath = "https://flex-system-30389.firebaseio.com/",

        };
        IFirebaseClient client;
        private void Marks_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            comboMarks.Items.Add("Quiz");
            comboMarks.Items.Add("Assignment");
            comboMarks.Items.Add("Mid");
            comboMarks.Items.Add("Final");
            CourseDropDown.Items.Add("OOP");
            CourseDropDown.Items.Add("LA");
            CourseDropDown.Items.Add("COAL");
            DepartmentBox.ReadOnly = true;
            NameBox.ReadOnly = true;
            BatchBox.ReadOnly = true;
            this.comboMarks.DropDownStyle = ComboBoxStyle.DropDownList;
            addBtn.Enabled = false;
        }

        private void Markss_TextChanged(object sender, EventArgs e)
        {

        }
        Student student;
        private Teacher teacher;

        private void retrieveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDBox.Text))
            {
                MessageBox.Show("ID Required");
            }
            else
            {
                try
                {
                    FirebaseResponse firebaseResponse = client.Get(@"Information/student/" + IDBox.Text);
                    student = firebaseResponse.ResultAs<Student>();
                    NameBox.Text = student.Name;
                    BatchBox.Text = student.Batch;
                    DepartmentBox.Text = student.Ds;
                    addBtn.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(IDBox.Text) || string.IsNullOrWhiteSpace(MarksBox.Text))
            {
                MessageBox.Show("ID or Marks Not Provided");
            }
            else
            {
                student.Marks += Convert.ToInt32(MarksBox.Text);
                try
                {
                    FirebaseResponse firebaseResponse = client.Update(@"Information/student/" + IDBox.Text,student);
                    MessageBox.Show("Marks Uploaded");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homef m = new Homef(teacher);
            {
                m.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search m = new Search(teacher);
            {
                m.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            News m = new News(teacher);
            {
                m.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete m = new Delete(teacher);
            {
                m.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Attendance m = new Attendance();
            {
                m.Show();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
