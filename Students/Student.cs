using Microsoft.Data.SqlClient;
using System;

namespace Students
{
    public class Student
    {
        //Id
        public int Id { get; set; }
        //Name
        public string Name { get; set; }
        //Roll no
        public string RollNum { get; set; }
        //Batch
        public string Batch { get; set; }
        //SemesterDues
        public int SemDues { get; set; }
        //CurrentSemester
        public int CurrSem { get; set; }


        SqlConnection con;

        //constructor
        public Student()
        {
            con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public Student(string name,string rollNum,string batch,int semDues,int currSem)
        {
            Name = name;
            RollNum = rollNum;
            Batch = batch;
            SemDues = semDues;
            CurrSem = currSem;
        }

        public bool StudentLogin(string name, string pwd)
        {
            //open connection
            con.Open();
            //query
            string query = $"Select * from StudentAccounts where userName=@u and password=@p";
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

        public void DisplayStudentMenu()
        {
            Console.Write("\n*********************Student Login*********************\n\n" +
                "Press 1 to Pay Semester Dues\n" +
                "Press 2 to view enrolled courses\n" +
                "Press 3 to view Assignments\n" +
                "Press 4 to Exit\n");
        }


        public void PaySemesterDues()
        {
            Console.WriteLine("pay sem dues");
            //int amountToPay, remainingDues;
            //Console.WriteLine("Enter amount to pay: ");
            //amountToPay = int.Parse(Console.ReadLine());
            ////  string query = $"Select semDues from Student where Id='{sID}'";
            //SqlCommand cmd = new SqlCommand(query, con);
            //con.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{

            //}
            //con.Close();
        }





        public void ViewCoursesEnrolled()
        {
            Console.WriteLine("View Courses Enrolled");
        }




        public void ViewAssignments()
        {
            Console.WriteLine("View Assignments");
        }
        
    }
}
