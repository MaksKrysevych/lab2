using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            bool WorkingOfMainMenu = true;
            bool WorkingOfFirstMenu = true;
            bool WorkingOfSecondMenu = true;
            Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>();
            BinaryTree<int> binarytree = new BinaryTree<int>();
            while (WorkingOfMainMenu)
            {
                PointOfReturn:
                MainMenu();
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            while (WorkingOfFirstMenu)
                            {


                                FristMenu();
                                int option1 = Convert.ToInt32(Console.ReadLine());
                                switch (option1)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Count of persons: ");
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 0; i < count; i++)
                                            {
                                                Console.WriteLine("Lastname");
                                                string lastname = Console.ReadLine();
                                                Console.WriteLine("Name:");
                                                string name = Console.ReadLine();
                                                Console.WriteLine("ID:");
                                                int id = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Birthday:");
                                                string birthday = Console.ReadLine();
                                                Console.WriteLine("Course:");
                                                int course = Convert.ToInt32(Console.ReadLine());

                                                DateTime birth = DateTime.Parse(birthday);
                                                DateTime today = DateTime.Today;
                                                int age = today.Year - birth.Year;

                                                studentDictionary.Add(id, new Student()
                                                {
                                                    ID = id,
                                                    FirstName = name,
                                                    LastName = lastname,
                                                    Birthday = birthday,
                                                    Age = age,
                                                    Course = course
                                                });
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("ID of student:");
                                            var key = int.Parse(Console.ReadLine());
                                            studentDictionary.Remove(key);
                                            break;
                                        }
                                    case 3:
                                        {
                                            foreach (var key in studentDictionary.Keys)
                                            {
                                                Console.WriteLine("ID: " + studentDictionary[key].ID);
                                                Console.WriteLine("Lastname: " + studentDictionary[key].LastName);
                                                Console.WriteLine("Firstname: " + studentDictionary[key].FirstName);
                                                Console.WriteLine("Birthday: " + studentDictionary[key].Birthday);
                                                Console.WriteLine("Age: " + studentDictionary[key].Age);
                                                Console.WriteLine("Course: " + studentDictionary[key].Course);
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("ID of student:");
                                            var key = int.Parse(Console.ReadLine());
                                            if (studentDictionary.ContainsKey(key))
                                            {
                                                UpdateMenu();
                                                int change = int.Parse(Console.ReadLine());

                                                switch (change)
                                                {
                                                    case 1:
                                                        {
                                                            Console.WriteLine("New id:");
                                                            int NewID = int.Parse(Console.ReadLine());
                                                            studentDictionary[key].ID = NewID;
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("New last name:");
                                                            var NewLastName = Console.ReadLine();
                                                            Console.WriteLine("New first name:");
                                                            var NewFirstName = Console.ReadLine();

                                                            studentDictionary[key].LastName = NewLastName;
                                                            studentDictionary[key].FirstName = NewFirstName;
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.WriteLine("New birthday:");
                                                            var NewBirthday = Console.ReadLine();
                                                            studentDictionary[key].Birthday = NewBirthday;

                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Console.WriteLine("New course:");
                                                            var NewCourse = int.Parse(Console.ReadLine());
                                                            studentDictionary[key].Course = NewCourse;
                                                            break;
                                                        }
                                                    case 5:
                                                        {
                                                            Console.WriteLine("New id:");
                                                            int NewID = int.Parse(Console.ReadLine());
                                                            Console.WriteLine("New last name:");
                                                            var NewLastName = Console.ReadLine();
                                                            Console.WriteLine("New first name:");
                                                            var NewFirstName = Console.ReadLine();
                                                            Console.WriteLine("New birthday:");
                                                            var NewBirthday = Console.ReadLine();
                                                            Console.WriteLine("New course:");
                                                            var NewCourse = int.Parse(Console.ReadLine());
                                                            studentDictionary[key].ID = NewID;
                                                            studentDictionary[key].LastName = NewLastName;
                                                            studentDictionary[key].FirstName = NewFirstName;
                                                            studentDictionary[key].Course = NewCourse;
                                                            studentDictionary[key].Birthday = NewBirthday;

                                                            break;
                                                        }


                                                    default:
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Not exist");
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.WriteLine("ID of student:");
                                            var key = int.Parse(Console.ReadLine());
                                            if (studentDictionary.ContainsKey(key))
                                            {
                                                Console.WriteLine("ID:" + studentDictionary[key].ID);
                                                Console.WriteLine("Lastname:" + studentDictionary[key].LastName);
                                                Console.WriteLine("Firstname:" + studentDictionary[key].FirstName);
                                                Console.WriteLine("Birthday:" + studentDictionary[key].Birthday);
                                                Console.WriteLine("Age: " + studentDictionary[key].Age);
                                                Console.WriteLine("Course:" + studentDictionary[key].Course);
                                            }

                                            break;
                                        }
                                    case 6:
                                        {
                                            goto PointOfReturn;
                                        }

                                    default:
                                        Console.WriteLine("Not exist!");
                                        break;
                                }
                            }
                                break;
                            
                        }
                    case 2:
                        {
                            while (WorkingOfSecondMenu)
                            {
                                SecondMenu();
                                int option2 = Convert.ToInt32(Console.ReadLine());
                                switch (option2)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Count of values:");
                                            int count = Convert.ToInt32(Console.ReadLine());

                                            for (int i = 0; i < count; i++)
                                            {
                                                var item = Convert.ToInt32(Console.ReadLine());

                                                binarytree.Add(item);
                                            }

                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Value:");
                                            var item = Convert.ToInt32(Console.ReadLine());
                                            binarytree.Remove(item);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            binarytree.PrintTree(Console.WindowWidth / 2);
                                            break;
                                        }
                                    case 4:
                                        {
                                            binarytree.Clear();
                                            break;
                                        }
                                    case 5:
                                        {
                                            goto PointOfReturn;
                                        }
                                    default:
                                        Console.WriteLine("Not exist!");
                                        break;
                                }
                            }

                            break;
                        }
                    case 3:
                        {
                            WorkingOfMainMenu = false;
                            break;
                        }
                    default:
                        Console.WriteLine("Not exist!");
                        break;
                }
            }
        
        }
        static void MainMenu()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Data base of students");
            Console.WriteLine("2. Binary tree");
            Console.WriteLine("3. Close app");
        }
        static void FristMenu()
        {
            Console.WriteLine("Operations:");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Delete student");
            Console.WriteLine("3. Show students");
            Console.WriteLine("4. Update database of student");
            Console.WriteLine("5. Show data of student");
            Console.WriteLine("6. Close menu");
        }
        static void SecondMenu()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Add element");
            Console.WriteLine("2. Delete element");
            Console.WriteLine("3. Show elements");
            Console.WriteLine("4. Clear list");
            Console.WriteLine("5. Close menu");
        }
        static void UpdateMenu()
            {
                Console.WriteLine("Update:");
                Console.WriteLine("1. ID");
                Console.WriteLine("2. Name");
                Console.WriteLine("3. Birthday");
                Console.WriteLine("4. Course");
                Console.WriteLine("5. All information");
            }
    }
}