using System;
using Students;
using Teachers;
using Admin;
using FunctionCalls;
namespace MainMenu
{
    public class Menu
    {
        public static void displayMainMenu()
        {
            int choice = 0;
            bool login;

            Student stu = new Student();
            Teacher t = new Teacher();
            Admin_ adm = new Admin_();

            Console.Write("\n*********************Course Management System*********************");
            while (choice != 4)//loop to print main menu again n again
            {
                Console.Write("\n\nPress 1 to Login as Student.\n" +
                "Press 2 to Login as Instructor.\n" +
                "Press 3 to Login as Admin.\n" +
                 "Press 4 to Exit.\n\n"+
                "Enter choice: ");

                choice = int.Parse(Console.ReadLine());//choice of main menu
                if (choice <= 0 || choice > 4)
                {
                    Console.WriteLine("INVALID INPUT");
                    continue;
                }

                switch (choice)//main switch b/w student , teacher and admin
                {
                    case 1://student
                        {
                            while (true)
                            {
                                //Console.WriteLine("\n\n*********************** Student Login ***********************");
                                //take input from user
                                string name, pwd;
                                Console.Write("\nEnter Student Username: ");
                                name = Console.ReadLine();
                                Console.Write("Enter Student Password: ");
                                pwd = Console.ReadLine();
                                Console.WriteLine();
                                login = stu.StudentLogin(name,pwd);
                                if (login == true)
                                {
                                    FunCalls.stuFunCalls();
                                    break;
                                }
                                else
                                    Console.WriteLine("Invalid Username or Password!\n");
                            }
                            break;
                        }







                    case 2://teacher
                        {
                            while (true)
                            {
                                //Console.WriteLine("\n\n*********************** Student Login ***********************");
                                //take input from user
                                string name, pwd;
                                Console.Write("\nEnter Instructor Username: ");
                                name = Console.ReadLine();
                                Console.Write("Enter Instructor Password: ");
                                pwd = Console.ReadLine();
                                Console.WriteLine();
                                login = t.TeacherLogin(name, pwd);
                                if (login == true)
                                {
                                    FunCalls.teacherFunCalls();
                                    break;
                                }
                                else
                                    Console.WriteLine("Invalid Username or Password!\n");
                            }
                            break;
                        }










                    case 3://admin
                        {
                            Console.Write("\n\n********************* Admin Login *********************\n\n");
                            while (true)//loop to login 
                            {
                                login = adm.AdminLogin();
                                if (login == true)
                                {
                                    FunCalls.admFunCalls();
                                    break;
                                }
                                else
                                    Console.WriteLine("Invalid Username or Password!\n");
                            }
                            break;
                        }









                    case 4:
                        {
                            break;
                        }
                }
            }
        }
    }
}
