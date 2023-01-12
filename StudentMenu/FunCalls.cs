using Students;
using Teachers;
using Admin;
using System;

namespace FunctionCalls
{
    public class FunCalls
    {
        public static void stuFunCalls()
        {
            Student stu = new Student();
            int stuChoice = 0;
            while (stuChoice!=4)
            {
                stu.DisplayStudentMenu();
                Console.Write("Enter Choice: ");
                stuChoice = int.Parse(Console.ReadLine());
                if (stuChoice <= 0 || stuChoice > 4)
                {
                    Console.WriteLine("INVALID INPUT");
                    continue;
                }

                    switch (stuChoice)
                    {
                        case 1://Pay Semester Dues
                            {
                           stu.PaySemesterDues();
                                break;
                            }
                        case 2://view enrolled courses
                            {
                            stu.ViewCoursesEnrolled();
                                break;
                            }
                        case 3://View Assignments
                        {
                            stu.ViewAssignments();
                                break;
                            }
                        case 4://exit
                            {
                                break;
                            }
                    }
            }
        }




        public static void admFunCalls()//to call admin class functions according to choices
        {
            Admin_ adm = new Admin_();
            int admChoice = 0;//what admin chooses to do

            while (admChoice != 4)//(display admin menu and calls the functions accordingly again n again) )what admin chooses to manage
            {
                adm.DisplayAdminMenu();
                Console.Write("Enter Choice: ");
                admChoice = int.Parse(Console.ReadLine());
                if (admChoice <= 0 || admChoice > 4)
                {
                    Console.WriteLine("INVALID INPUT");
                    continue;
                }

                switch (admChoice)//to switch b/w diff admin choices either to manage stu, teachres or courses or exit
                {
                    case 1://Mange Students
                        {
                            adm.ManageStudent();
                            break;
                        }
                    case 2://Manage Teachers
                        {
                            adm.ManageTeacher();
                            break;
                        }
                    case 3://Manage Courses
                        {
                            adm.ManageCourses();
                            break;
                        }
                    case 4://exit
                        {
                            break;
                        }
                }
            }
        }









        public static void teacherFunCalls()//to call admin class functions according to choices
        {
            Teacher t = new Teacher();
            int tChoice = 0;//what admin chooses to do

            while (tChoice != 4)//(display admin menu and calls the functions accordingly again n again) )what admin chooses to manage
            {
                t.DisplayTeacherMenu();
                Console.Write("Enter Choice: ");
                tChoice = int.Parse(Console.ReadLine());
                if (tChoice <= 0 || tChoice > 4)
                {
                    Console.WriteLine("INVALID INPUT");
                    continue;
                }

                switch (tChoice)
                {
                    case 1://Mark attendance
                        {
                            t.MarkAttendance();
                            break;
                        }
                    case 2://Post Assignment
                        {
                            t.PostAssignment();
                            break;
                        }
                    case 3://View Assigned Courses
                        {
                            t.ViewAssignedCourses();
                            break;
                        }
                    case 4://exit
                        {
                            break;
                        }
                }
            }
        }
    }
}
