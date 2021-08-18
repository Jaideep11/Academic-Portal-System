using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace flex_system_last
{
    public partial class Logint : Form
    {
        IFirebaseClient client;
        public Logint()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "5el7PEgL8sOhY7uACJt9VRYHtaC1O3No9nLXE02z",
            BasePath = "https://flex-system-30389.firebaseio.com/"
        };
        private void Logint_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }
        public static bool CheckInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http:/google.com/generate_204"))
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void Login_Click(object sender, EventArgs e)
        {
            //FirebaseResponse firebaseResponse = client.Get(@"Information/Teacher/" + userbox.Text);
            //Teacher teacher = firebaseResponse.ResultAs<Teacher>();
            Teacher temp = new Teacher()
            {
                Name = userbox.Text,
                Password = passwordbox.Text,
            };
            try
            {
                FirebaseResponse firebaseResponse = client.Get(@"Information/Teacher/" + userbox.Text);
                Teacher teacher = firebaseResponse.ResultAs<Teacher>();
                if (teacher.valid_username(temp.Name))
                {
                    if (teacher.valid_password(temp.Password))
                    {
                        MessageBox.Show("Login Successfully");
                        Homef home = new Homef(teacher);
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password!");
                    }
                }
            }
            catch
            {
                if (!CheckInternet())
                {
                    MessageBox.Show("Username Not Found");

                }
                else
                {
                    MessageBox.Show("Internet Connection Lost");
                }
            }
        }
        private void Signup_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            this.Hide();
            reg.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
