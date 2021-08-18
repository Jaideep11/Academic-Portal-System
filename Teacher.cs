using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
namespace flex_system_last
{
    public class Teacher
    {
        string name;
        string gender;
        string Dob;
        string department;
        string Cnic;
        string password;
        IFirebaseClient client;
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string DOB { get => Dob; set => Dob = value; }
        public string Department { get => department; set => department = value; }
        public string CNIC { get => Cnic; set => Cnic = value; }
        public string Password { get => password; set => password = value; }
        public Teacher() { }
        public Teacher (string name, string Gender, string DOB,string Department, string CNIC,string password)
        {
            this.name = name;
            this.password = password;
            this.gender = Gender;
            this.Dob = DOB;
            this.department = Department;
            this.Cnic = CNIC;

            client = new FireSharp.FirebaseClient(config);
            if (client == null)
            {
               
            }

        }
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "5el7PEgL8sOhY7uACJt9VRYHtaC1O3No9nLXE02z",
            BasePath = "https://flex-system-30389.firebaseio.com/"
        };
        //ya kasa aya

        public  Student SearchStudent(string id)
        {
            try
            {
                FirebaseResponse firebaseResponse = client.Get(@"Information/student/" + id);
                Student student = firebaseResponse.ResultAs<Student>();
                return student;
            }
            catch
            {
                return null;
            }
            
        }
        public bool DeleteStudent( string id)
        {
            try
            {
                FirebaseResponse firebaseResponse = client.Delete(@"Information/Student/" + id);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool UpdateStudent(Student student)
        {
            try
            {
                FirebaseResponse setResponse = client.Update(@"Information/Student/" + student.Id,student);
                return true;
            }
            catch
            {
                return false;
            }
        }
         
        public bool AddStudent(Student student)
        {
            try
            {
                SetResponse set = client.Set(@"WebUsers/Customers/" + student.Id, student);
                //SetResponse setResponse = client.Set(@"Information/student/" + student.Id, student);
                //student = setResponse.ResultAs<Student>();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool valid_username(string name)
        {
            if (name == this.name)
            {
                return true;
            }
            return false;
        }
        public bool valid_password(string password)
        {
            if (password == this.password)
            {
                return true;
            }
            return false;
        }
    }
}
