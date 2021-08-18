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
using System.Threading;

namespace flex_system_last
{
    public partial class Delete : Form
    {
        Teacher teacher;
        Student student;
        public Delete(Teacher teacher)
        {
            student = new Student();
            this.teacher = teacher;
            
            InitializeComponent();
        }
        IFirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "5el7PEgL8sOhY7uACJt9VRYHtaC1O3No9nLXE02z",
            BasePath = "https://flex-system-30389.firebaseio.com/"
        };
        private void Delete_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client == null)
            {
                MessageBox.Show("server not Responding");
            }
            Names.Enabled = false;
            Address.Enabled = false;
            Batchs.Enabled = false;
            Phones.Enabled = false;
            Departments.Enabled = false;
        }

        private async void deletes_Click(object sender, EventArgs e)
        {
            var id = IDs.Text;
            if (string.IsNullOrWhiteSpace(IDs.Text))
            {
                MessageBox.Show("Please Provide ID to Search");
            }
            
            try
            {
                FirebaseResponse firebaseResponse = await client.GetTaskAsync(@"Information/student/" + id);
                student = firebaseResponse.ResultAs<Student>();
                Names.Text = student.Name;
                Address.Text = student.Address;
                Batchs.Text = student.Batch;
                Phones.Text = student.Phone;
                Departments.Text = student.Ds;
                try
                {
                    FirebaseResponse deleteResponse = await client.DeleteTaskAsync("Information/student/" + id);
                    
                    try
                    {
                        FirebaseResponse response = await client.GetTaskAsync("Information/Counter/Students/count");
                        Counter counter = response.ResultAs<Counter>();
                        for(int i = 1; i <= counter.Count; i++)
                        {
                            try
                            {
                                FirebaseResponse res = await client.GetTaskAsync("Information/Counter/ID/" + i.ToString());
                                Folder folder = res.ResultAs<Folder>();
                                if(folder.tempID == id)
                                {
                                    FirebaseResponse delete = await client.DeleteTaskAsync("Information/Counter/ID/" + i.ToString());
                                    for (; i < counter.Count; i++)
                                    {
                                        try
                                        {
                                            FirebaseResponse re = await client.GetTaskAsync("Information/Counter/ID/" + (i+1).ToString());
                                            Folder fold = re.ResultAs<Folder>();
                                            try
                                            {
                                                FirebaseResponse change = await client.UpdateTaskAsync("Information/Counter/ID/" + i.ToString(),fold);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }
                                            if((i+1 == counter.Count)){
                                                FirebaseResponse del = await client.DeleteTaskAsync("Information/Counter/ID/" + (i+1).ToString());
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        counter.Count--;
                        try
                        {
                            FirebaseResponse firebase = await client.UpdateTaskAsync(@"Information/Counter/Students/count",counter);
                            MessageBox.Show("Student Deleted!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch
                {
                    MessageBox.Show("Student Not Deleted!");
                }
                undo.Enabled = true;
            }
            catch
            {
                MessageBox.Show("ID not Found - Please Check Your Internet Connection");
            }
        }
        Counter count;
        private async void undo_Click(object sender, EventArgs e)
        {
            try
            {
                var id = IDs.Text;
                Student student = new Student();
                student.Id = id;
                student.Name = Names.Text;
                student.Address = Address.Text;
                student.Batch = Batchs.Text;
                student.Phone = Phones.Text;
                student.Ds = Departments.Text;
                FirebaseResponse counter = client.Get("Information/Counter/Students/count");
                count = counter.ResultAs<Counter>();
                if(true)
                {
                    FirebaseResponse get = client.Get("Information/Counter/Students/count");
                    count = get.ResultAs<Counter>();
                    int xount = count.Count++;
                    count.Id = id;
                    xount++;
                    setStudents(xount, id);
                    try
                    {
                        SetResponse setResponse = client.Set(@"Information/student/" + student.Id, student);
                        MessageBox.Show("Student Added");
                        undo.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        undo.Enabled = false;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                undo.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }
        private void setStudents(int xount, string id)
        {
            try
            {
                FirebaseResponse set = client.Set("Information/Counter/Students/count", count);
                Folder folder = new Folder();
                folder.tempID = count.Id;
                try
                {
                    SetResponse setRes = client.Set("Information/Counter/ID/" + xount.ToString(), folder);
                }
                catch (Exception ex)
                {
                    undo.Enabled = false;
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                undo.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homef d = new Homef(teacher);
            {
                d.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search d = new Search(teacher);
            {
                d.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            News d = new News(teacher);
            {
                d.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marks d = new Marks();
            {
                d.Show();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Attendance d = new Attendance();
            {
                d.Show();
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
