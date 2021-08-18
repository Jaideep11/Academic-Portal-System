using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flex_system_last
{
    public class Student
    {
        string name;
        string id;
        string batch;
        string ds;
        int marks;
        string phone;
        string address;
        string link;
        double Atten;
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string Batch { get => batch; set => batch = value; }
        public string Ds { get => ds; set => ds = value; }
        public int Marks { get => marks; set => marks = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Link { get => link; set => link = value; }
        public double Attendance { get => Atten; set => Atten = value; }

        public Student() {
            Marks = 0;
            Atten = 0.0;
        }
       public Student( string name,string id,string batch,string department ,string phone,string address)
        {
            this.Name = name;
            this.id=id;
            this.batch = batch;
            this.ds = department;
            this.phone = phone;
            Marks = 0;
            Atten = 0.0;
            this.address = address;





        }

    }
}
