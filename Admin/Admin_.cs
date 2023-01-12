using System;
using Students;
using Teachers;
using Microsoft.Data.SqlClient;
namespace Admin
{
    public class Admin_
    {

        SqlConnection con;

        //constructor
        public Admin_()
        {
            con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public bool AdminLogin()
        {
            //take input from user
            string name, pwd;
            Console.Write("\nEnter Admin Username: ");
            name = Console.ReadLine();
            Console.Write("Enter Admin Password: ");
            pwd = Console.ReadLine();

            //open connection
            con.Open();
            //query
            string query = $"Select * from Admin where userName=@u and password=@p";
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

        public void DisplayAdminMenu()
        {
            Console.Write("\nPress 1 to Manage Students.\n" +
                "Press 2 to Manage Teachers.\n" +
                "Press 3 to Manage Courses.\n" +
                "Press 4 to Exit\n\n");
        }


        public void ManageStudent()
        {
            int choice = 0;//what admin chooses to do
            string name, roll, batch;
            int semDues, currSem, id;
            string username, pwd;

            while (choice != 7)//(display admin menu and calls the functions accordingly again n again) )what admin chooses to manage
            {
                Console.Write("\n\nEnter 1 to Add Student\n" +
                    "Enter 2 to Update Student\n" +
                    "Enter 3 to Delete Student\n" +
                    "Enter 4 to View All Students\n" +
                    "Enter 5 to Display Outstanding Semester Dues\n" +
                    "Enter 6 to Assign Course to Student\n" +
                    "Enter 7 to  Exit\n\n" +
                    "Enter choice: ");

                choice = int.Parse(Console.ReadLine());
                if (choice <= 0 || choice > 7)
                {
                    Console.WriteLine("INVALID INPUT");
                    continue;
                }

                switch (choice)//to switch b/w diff admin choices either to manage stu, teachres or courses or exit
                {
                    case 1://Add Student
                        {
                            Console.Write("\nEnter data of student to add:\n");
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("Roll Number: ");
                            roll = Console.ReadLine();
                            Console.Write("Batch: ");
                            batch = Console.ReadLine();
                            Console.Write("Semester Dues: ");
                            semDues = int.Parse(Console.ReadLine());
                            Console.Write("Current Semester: ");
                            currSem = int.Parse(Console.ReadLine());
                            Console.Write("Username: ");
                            username =Console.ReadLine();
                            Console.Write("Password: ");
                            pwd = Console.ReadLine();

                            Student st = new Student(name, roll, batch, semDues, currSem);

                            string query = $"INSERT INTO Student(name, rollNum, batch, semDues, currSem) " +
           $"VALUES('{st.Name}', '{st.RollNum}', '{st.Batch}', '{st.SemDues}', '{st.CurrSem}')";
                            SqlCommand cmd = new SqlCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 2://Update Student
                        {
                            Console.Write("Enter Id of student whose data is to be updated: ");
                            id = int.Parse(Console.ReadLine());
                            Console.Write("\nEnter data of student to update:\n");
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("Roll Number: ");
                            roll = Console.ReadLine();
                            Console.Write("Batch: ");
                            batch = Console.ReadLine();
                            Console.Write("Semester Dues: ");
                            semDues = int.Parse(Console.ReadLine());
                            Console.Write("Current Semester: ");
                            currSem = int.Parse(Console.ReadLine());

                            Student st = new Student(name, roll, batch, semDues, currSem);

                            string query = $"Update Student set name ='{st.Name}',rollNum ='{st.RollNum}',batch ='{st.Batch}',semDues ='{st.SemDues}',currSem ='{st.CurrSem}' where Id='{id}'";
                            SqlCommand cmd = new SqlCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 3://Delete Student
                        {
                            Console.Write("Id: ");
                            id = int.Parse(Console.ReadLine());
                            string query = $"DELETE FROM StudentAccounts where sID  = '{id}'";
                            SqlCommand cmd = new SqlCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            query = $"DELETE FROM Student where Id  = '{id}'";
                            cmd = new SqlCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 4://View All Students
                        {
                            string query = $"Select * from Student";
                            SqlCommand cmd = new SqlCommand(query, con);
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            Console.WriteLine("_____________________________________________________________________________________________________________________________________________________________");
                            Console.WriteLine("\n{0,30}{1,20}{2,20}{3,20}{4,20}", "Name", "Roll Number", "Batch", "Semester Dues", "Current Semester");
                            Console.WriteLine();
                            while (dr.Read())
                            {
                                Console.WriteLine("{0,30}{1,20}{2,20}{3,20}{4,20}",
                                    dr[1], dr[2], dr[3], dr[4], dr[5]);
                            }
                            Console.WriteLine("_____________________________________________________________________________________________________________________________________________________________");
                            con.Close();
                            break;
                        }
                    case 5://Display Outstanding Semester Dues
                        {
                            string query = $"Select rollNum from Student where semDues!='{0}'";
                            SqlCommand cmd = new SqlCommand(query, con);
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            Console.WriteLine("Roll Numbers of students having outstanding dues are:\n");
                            while(dr.Read())
                            {
                                Console.WriteLine(dr[0]);
                            }    
                            con.Close();
                            break;
                        }
                    case 6://Assign Course to Student
                        {
                            
                            break;
                        }
                    case 7://exit
                        {
                            break;
                        }
                }
            }

        }


        public void ManageTeacher()
        {
            int choice = 0;//what admin chooses to do
            string name, experience;
            int salary, numOfCourses,id;
            while (choice != 6)//(display admin menu and calls the functions accordingly again n again) )what admin chooses to manage
            {
                Console.Write("\n\nEnter 1 to Add Teacher\n" +
                    "Enter 2 to Update Teacher\n" +
                    "Enter 3 to Delete Teacher\n" +
                    "Enter 4 to View All Teachers\n" +
                    "Enter 5 to Assign Course to Teacher\n" +
                    "Enter 6 Exit\n\n" +
                    "Enter choice: ");

                choice = int.Parse(Console.ReadLine());
                if (choice <= 0 || choice > 7)
                {
                    Console.WriteLine("INVALID INPUT");
                    continue;
                }

                switch (choice)//to switch b/w diff admin choices either to manage stu, teachres or courses or exit
                {
                    case 1://Add Teacher
                        {
                            Console.Write("\nEnter data of teacher to add:\n");
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("Salary: ");
                            salary = int.Parse(Console.ReadLine());
                            Console.Write("Experience: ");
                            experience = Console.ReadLine();
                            Console.Write("Number of courses assigned: ");
                            numOfCourses = int.Parse(Console.ReadLine());

                            Teacher t = new Teacher(name, salary, experience, numOfCourses);

                            string query = $"INSERT INTO Teacher(Name, Salary, Experience, NoOfCoursesAssigned) " +
           $"VALUES('{t.Name}', '{t.Salary}', '{t.Experience}', '{t.NoOfCoursesAssigned}')";
                            SqlCommand cmd = new SqlCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 2://Update Teacher
                        {
                            Console.Write("Enter Id of teacher whose data is to be updated: ");
                            id = int.Parse(Console.ReadLine());
                            Console.Write("\nEnter data of teacher to update:\n");
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("Salary: ");
                            salary = int.Parse(Console.ReadLine());
                            Console.Write("Experience: ");
                            experience = Console.ReadLine();
                            Console.Write("Number of courses assigned: ");
                            numOfCourses = int.Parse(Console.ReadLine());

                            Teacher t = new Teacher(name, salary, experience, numOfCourses);

                            string query = $"Update Teacher set Name ='{t.Name}',Salary ='{t.Salary}',Experience ='{t.Experience}',NoOfCoursesAssigned ='{t.NoOfCoursesAssigned}'";
                            SqlCommand cmd = new SqlCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 3://Delete Teacher
                        {
                            Console.Write("Id: ");
                            id = int.Parse(Console.ReadLine());
                            string query = $"DELETE FROM TeacherAccounts where tID  = '{id}'";
                            SqlCommand cmd = new SqlCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            query = $"DELETE FROM Teacher where Id  = '{id}'";
                            cmd = new SqlCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            break;
                        }
                    case 4://View All Teachers
                        {
                            Console.WriteLine("View All Teachers");
                            break;
                        }
                    case 5://Assign Course to Teacher
                        {
                            Console.WriteLine("Assign Course to Teacher");
                            break;
                        }
                    case 6://Exit
                        {
                            break;
                        }
                }
            }

        }

        public void ManageCourses()
        {
            int choice = 0;//what admin chooses to do

            while (choice != 5)//(display admin menu and calls the functions accordingly again n again) )what admin chooses to manage
            {
                Console.Write("\n\nEnter 1 to Add Courses\n" +
                    "Enter 2 to Update Courses\n" +
                    "Enter 3 to Delete Courses\n" +
                    "Enter 4 to View All Courses\n" +
                    "Enter 5 Exit\n\n" +
                    "Enter choice: ");

                choice = int.Parse(Console.ReadLine());
                if (choice <= 0 || choice > 5)
                {
                    Console.WriteLine("INVALID INPUT");
                    continue;
                }

                switch (choice)//to switch b/w diff admin choices either to manage stu, teachres or courses or exit
                {
                    case 1://Add Courses
                        {
                            Console.WriteLine("Add Courses");
                            break;
                        }
                    case 2://Update Courses
                        {
                            Console.WriteLine("Update Courses");
                            break;
                        }
                    case 3://Delete Courses
                        {
                            Console.WriteLine("Delete Courses");
                            break;
                        }
                    case 4://View All Courses
                        {
                            Console.WriteLine("View All Courses");
                            break;
                        }
                    case 5://Exit
                        {
                            break;
                        }
                }
            }
        }

    }
}
