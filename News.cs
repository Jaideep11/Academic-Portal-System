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
using Firebase.Storage;
using System.IO;
namespace flex_system_last
{
    public partial class News : Form
    {
        Teacher teacher;
        IFirebaseClient client;
        IFirebaseClient FirebaseClient;
        Counter count;
        public News(Teacher teacher)
        {
            this.teacher = teacher;
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "5el7PEgL8sOhY7uACJt9VRYHtaC1O3No9nLXE02z",
            BasePath = "https://flex-system-30389.firebaseio.com/",
            
        };
        IFirebaseConfig firebaseConfig = new FirebaseConfig
        {
            AuthSecret = "5el7PEgL8sOhY7uACJt9VRYHtaC1O3No9nLXE02z",
            BasePath = "https://console.firebase.google.com/project/flex-system-30389/storage/flex-system-30389.appspot.com/files",
        };

        private async void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Names.Text) || string.IsNullOrWhiteSpace(IDs.Text) || string.IsNullOrWhiteSpace(Departments.Text) || string.IsNullOrWhiteSpace(Phones.Text) || string.IsNullOrWhiteSpace(Address.Text) || string.IsNullOrWhiteSpace(Batchs.Text))
            {
                MessageBox.Show("Please Fill the Fields Required!");
                return;
            }
            string name = Names.Text;
            string id = IDs.Text;
            string batch = Batchs.Text;
            string department = Departments.Text;
            string phone = Phones.Text;
            string address = Address.Text;
            Student student = new Student()
            {
                Name = name,
                Id = id,
                Address = address,
                Batch = batch,
                Ds = department,
                Phone = phone
            };
            try
            {

                FirebaseResponse counter =  client.Get("Information/Counter/Students/count");
                count = counter.ResultAs<Counter>();
                MessageBox.Show(count.Count.ToString());
                // why loop is being used

                for (int i = 1; i <= count.Count; i++)
                {
                    FirebaseResponse response = client.Get("Information/Counter/ID/" + i.ToString());
                    Folder folder = response.ResultAs<Folder>();
                    //MessageBox.Show(tempID);
                    if (folder.tempID == id)
                    {
                        IDs.Text = "";
                        break;
                    }
                }
                if (IDs.Text == "")
                {
                    MessageBox.Show("ID Taken Already");
                }
                else
                {
                    FirebaseResponse get = client.Get("Information/Counter/Students/count");
                    count = get.ResultAs<Counter>();
                    int xount = count.Count++;
                    count.Id = id;
                    MessageBox.Show("value of X: " + xount.ToString());
                    xount++;
                    setStudents(xount, id);
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                    pictureBox1 = null;
                    try
                    {
                        Stream stream = File.Open(@imagePath, FileMode.Open);
                        FirebaseStorageTask task = new FirebaseStorage("flex-system-30389.appspot.com")
                            // no explaination for next step

                            .Child("Student").Child(student.Id + ".jpg").PutAsync(stream);
                        MessageBox.Show("Image Upload");
                        try
                        {
                            SetResponse setResponse = client.Set(@"Information/student/" + student.Id, student);
                            MessageBox.Show("Student Added");
                            student.Link = await task;
                            News news = new News(teacher);
                            this.Hide();
                            news.Show();
                            this.Dispose();
                        }
                        catch (Exception ex)
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
        private void setStudents(int xount,string id)
        {
                try
                {
                    FirebaseResponse set =  client.Set("Information/Counter/Students/count", count);
                    MessageBox.Show("updated");
                Folder folder = new Folder();
                folder.tempID = count.Id;
                    try
                    {
                        SetResponse setRes =  client.Set("Information/Counter/ID/" + xount.ToString(), folder);
                        MessageBox.Show("ID added");
                    }
                    catch
                    {
                        MessageBox.Show("ID not added");
                    }
                }
                catch
                {
                    MessageBox.Show("not updated");
                }
        }
        private void News_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseClient = new FireSharp.FirebaseClient(firebaseConfig);
            if (client == null)
            {
                MessageBox.Show("server not Responding");
            }
            FirebaseResponse firebaseresponce = client.Get(@"Information/Counter");
            count = firebaseresponce.ResultAs<Counter>();
            Departments.Items.Add("CS");
            Departments.Items.Add("EE");
            Departments.Items.Add("BBA");
        }

        private void deleteb_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete(teacher);
            this.Hide();
            delete.Show();
        }
        string imagePath;
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {

                    pictureBox1.Image = new Bitmap(open.FileName);
                    imagePath = open.FileName;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homef n = new Homef(teacher);
            {
                n.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search n = new Search(teacher);
            {
                n.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete n = new Delete(teacher);
            {
                n.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marks n = new Marks();
            {
                n.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Attendance n = new Attendance();
            {
                n.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logint f = new Logint();
            {
                f.Show();
            }
        }
    }
}
