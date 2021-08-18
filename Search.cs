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
using FireSharp.Response;
using FireSharp.Interfaces;
namespace flex_system_last
{
    public partial class Search : Form
    {
        Teacher teacher;
        IFirebaseClient client;
        public Search(Teacher teacher)
        {
            this.teacher = teacher;
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "5el7PEgL8sOhY7uACJt9VRYHtaC1O3No9nLXE02z",
            BasePath = "https://flex-system-30389.firebaseio.com/"
        };
        private void SerachBtn_Click(object sender, EventArgs e)
        {
            var id = IDs.Text;
            if (string.IsNullOrWhiteSpace(IDs.Text))
            {
                MessageBox.Show("Please Provide ID to Search");
            }
            else
            {
                try
                {
                    FirebaseResponse firebaseResponse = client.Get(@"Information/student/" + id);
                    Student student = firebaseResponse.ResultAs<Student>();
                    Names.Text = student.Name;
                    Address.Text = student.Address;
                    Batchs.Text = student.Batch;
                    Phones.Text = student.Phone;
                    Markss.Text = student.Marks.ToString();
                    Departments.Text = student.Ds;
                }
                catch
                {
                    MessageBox.Show("ID not Found - Please Check Your Internet Connection");
                }
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client == null)
            {
                MessageBox.Show("server not Responding");
            }
        }

        private void Searchb_Click(object sender, EventArgs e)
        {

        }

        private void Markss_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homef h = new Homef(teacher);
            {
                h.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            News h = new News(teacher);
            {
                h.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete h = new Delete(teacher);
            {
                h.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marks h = new Marks();
            {
                h.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Attendance h = new Attendance();
            {
                h.Show();
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
