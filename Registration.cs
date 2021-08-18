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
    public partial class Registration : Form
    {
        public IFirebaseClient client;
        public Registration()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
        }
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "5el7PEgL8sOhY7uACJt9VRYHtaC1O3No9nLXE02z",
            BasePath = "https://flex-system-30389.firebaseio.com/"
        };
        private async void Signup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Namet.Text) || string.IsNullOrWhiteSpace(Gendert.Text) || string.IsNullOrWhiteSpace(Departmentt.Text) || string.IsNullOrWhiteSpace(passwordt.Text) || string.IsNullOrWhiteSpace(CNICt.Text))
            {
                MessageBox.Show("Please Fill the Fields Required!");
                return;
            }
            string name = Namet.Text;
            string Gender = Gendert.Text;
            string DOB = DOBt.Text;
            string Department = Departmentt.Text;
            string CNIC = CNICt.Text;
            string password = passwordt.Text;
            Teacher teacher = new Teacher(name, Gender, DOB, Department, CNIC, password);
            try
            {
                FirebaseResponse firebaseResponse = await client.GetTaskAsync(@"Information/Teacher/" + teacher.Name);
                MessageBox.Show(name + " already work here!");
            }
            catch
            {
                try
                {
                    SetResponse setResponse = await client.SetTaskAsync(@"Information/Teacher/" + teacher.Name, teacher);
                    MessageBox.Show("Welcome " + teacher.Name);
                    Homef home = new Homef(teacher);
                    this.Hide();
                    home.Show();
                }
                catch
                {
                    MessageBox.Show("Internet Not Working");
                }
            }
        }

        private void Namet_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            Departmentt.Items.Add("BBA");
            Departmentt.Items.Add("CS");
            Departmentt.Items.Add("EE");
            Gendert.Items.Add("Male");
            Gendert.Items.Add("Female");
            //Namet.Text = DOBt.Text;
            //DOBt.Items.Add("");
        }
    }
}
