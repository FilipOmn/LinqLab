using LinqLab_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLab_
{
    class Program
    {
        static void Main(string[] args)
        {
            using Context context = new Context();

            List<Teacher> TeacherList = new List<Teacher>();
            List<Student> StudentList = new List<Student>();
            List<Course> CourseList = new List<Course>();
            List<Class> ClassList = new List<Class>();

            foreach (var item in context.Teachers)
            {
                TeacherList.Add(item);
            }

            foreach (var item in context.Students)
            {
                StudentList.Add(item);
            }

            foreach (var item in context.Courses)
            {
                CourseList.Add(item);
            }

            foreach (var item in context.Classes)
            {
                ClassList.Add(item);
            }

            foreach(var item in context.CourseStudents)
            {

            }

            SelectionMenu();

            void SelectionMenu()
            {
                Console.Clear();
                Console.WriteLine("Enter number of option with matching number \n------------------------------------------- \n1: Get all Teachers for course programming 1 \n2: Get all Students and their teachers \n3: Get all students in course programming 1 and their teacher \n4: Edit course programming 2 to OOP \n5: Change teacher for programming 1 from anas to reidar \n");

                try
                {
                    int UserInput = Convert.ToInt32(Console.ReadLine());

                    switch (UserInput)
                    {
                        case 1:
                            var option_1 = from c
                                           in context.Courses
                                           where c.CourseName == "Programming 1"
                                           select c.Teacher;

                            foreach (var item in option_1)
                            {
                                Console.WriteLine(item.TeacherName);
                            }

                            Console.ReadKey();
                            SelectionMenu();
                            break;
                        case 2:
                            var option_2 = from s
                                           in context.Students
                                           select s;

                            foreach(var item_a  in option_2)
                            {
                                Console.WriteLine($"Student: {item_a.StudentName} \n--------------");
                                Console.WriteLine("Courses: ");

                                foreach(var item_b in item_a.CourseStudents)
                                {
                                    Console.WriteLine($"        {item_b.Course.CourseName} \n        Teacher: {item_b.Course.Teacher.TeacherName} \n");
                                }
                            }

                            Console.ReadKey();
                            SelectionMenu();
                            break;
                        case 3:
                            var option_3 = from c
                                           in context.CourseStudents
                                           where c.Course == CourseList[2]
                                           select c;

                            foreach(var item in option_3)
                            {
                                Console.WriteLine(item.Student.StudentName);
                                Console.WriteLine(item.Course.Teacher.TeacherName);
                                Console.WriteLine("------------");
                            }

                            Console.ReadKey();
                            SelectionMenu();
                            break;
                        case 4:
                            var option_4 = (from c
                                            in context.Courses
                                            where c.CourseName == "Programming 2"
                                            select c).FirstOrDefault();

                            option_4.CourseName = "OOP";
                            context.SaveChanges();

                            Console.WriteLine("Done!");
                            Console.ReadKey();
                            SelectionMenu();
                            break;
                        case 5:
                            var option_5 = (from c
                                            in context.Courses
                                            where c.CourseName == "Programming 1"
                                            select c).FirstOrDefault();
                            var reidar = (from t
                                          in context.Teachers
                                          where t.TeacherName == "Reidar"
                                          select t).FirstOrDefault();

                            option_5.Teacher = reidar;
                            context.SaveChanges();

                            Console.WriteLine("Done!");
                            Console.ReadKey();
                            SelectionMenu();
                            break;
                        default:
                            Console.WriteLine("Error, invalid option");
                            Console.ReadKey();
                            SelectionMenu();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Error, press any key to return to retry");
                    Console.ReadKey();
                    SelectionMenu();
                }
            }

            Console.ReadKey();
        }
    }
}
