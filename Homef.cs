using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flex_system_last
{
    public partial class Homef : Form
    {
        Teacher teacher;
        public Homef(Teacher teacher)
        {
            this.teacher = teacher;
            InitializeComponent();
        }

        private void Homef_Load(object sender, EventArgs e)
        {
            Namet.Text  = teacher.Name;
            Gendert.Text = teacher.Gender;
            DOBt.Text = teacher.DOB;
            Departmentt.Text = teacher.Department;
            CNICt.Text = teacher.CNIC;
            Namet.Enabled = false;
            Gendert.Enabled = false;
            DOBt.Enabled = false;
            Departmentt.Enabled = false;
            CNICt.Enabled = false;
        }

        private void Searchb_Click(object sender, EventArgs e)
        {
            Search search = new Search(teacher);
            this.Hide();
            search.Show();
        }

        private void News_Click(object sender, EventArgs e)
        {
            News news = new News(teacher);
            this.Hide();
            news.Show();
        }

        private void deleteb_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete(teacher);
            this.Hide();
            delete.Show();
        }

        private void marksb_Click(object sender, EventArgs e)
        {
            Marks mark = new Marks();
            this.Hide();
            mark.Show();               
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            this.Hide();
            attendance.Show();
        }

        private void Homeb_Click(object sender, EventArgs e)
        {

        }

        private void Namet_TextChanged(object sender, EventArgs e)
        {

        }

        private void Editb_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logint f = new Logint();
            {
                f.Show();
            }
        }
    }
}
