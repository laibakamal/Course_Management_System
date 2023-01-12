using System;
using Microsoft.Data.SqlClient;

namespace Teachers
{
    public class Teacher
    {
            //Id
            public int Id { get; set; }
            //Name
            public string Name { get; set; }
            //Roll no
            public int Salary { get; set; }
            //Experience
            public string Experience { get; set; }
            //NoOfCoursesAssigned
            public int NoOfCoursesAssigned { get; set; }

            SqlConnection con;

            //constructor
            public Teacher()
            {
                con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }


        public Teacher(string name, int salary, string experience, int numOfCourses)
        {
            Name = name;
            Salary = salary;
            Experience = experience;
            NoOfCoursesAssigned = numOfCourses;
        }

        public bool TeacherLogin(string name, string pwd)
        {
            //open connection
            con.Open();
            //query
            string query = $"Select * from TeacherAccounts where userName=@u and password=@p";
            //sql parameters
            SqlParameter p1 = new SqlParameter("u", name);
            SqlParameter p2 = new SqlParameter("p", pwd);
            //command
            SqlCommand cmd = new SqlCommand(query, con);
            //add parameters
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            //data reader
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }



        public void DisplayTeacherMenu()
        {
            Console.Write("\n*********************Teacher Login*********************\n\n" +
                "Enter 1 to Mark attendance\n" +
                "Enter 2 to post assignment\n" +
                "Enter 3 to View Assigned Courses\n" +
                "Enter 4 to Exit\n\n");
        }



        public void MarkAttendance()
        {
            Console.WriteLine("mark attendance");
        }


        public void PostAssignment()
        {
            Console.WriteLine("post assign");
        }



        public void ViewAssignedCourses()
        {
            Console.WriteLine("view assigned courses");
        }

    }
}
