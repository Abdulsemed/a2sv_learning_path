using System;
using System.Threading.Tasks;

class MainClass
{
    class Student
    {
        //protected int Id { get; set; }
        public string Name ="";
        public readonly int Rollnumber = 1;
        public int Age = 0;
        public double Grade = 0.0;
        public Student(int roll, string name, int age, double grade) { 
            Rollnumber = roll;
            Name = name;
            Age = age;
            Grade = grade;
        }

    }
    class StudentList<T>
    {
        List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        private void DisplayStudent(List<Student> item)
        {
            Console.WriteLine("Name \t description \t category \t isCompleted");
            foreach (var student in item)
            {
                Console.WriteLine($"{student.Rollnumber} \t {student.Name} \t {student.Age} \t {student.Grade}");
            }
        }
        public void ViewStudent()
        {
            DisplayStudent(students);
        }
        public int Count()
        {
            return students.Count-1;
        }

        public static void SearchStudent(string query)
        {
            //handle cases
        }
    }
    public static string inputAccepeter(string param)
    {
        string input = "";
        do
        {
            try
            {
                Console.WriteLine($"enter the {param}");
                input = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("incorrect format");
            }

        } while (string.IsNullOrEmpty(input));
        return input;
    }
    // function to accept and validate integer inputs returns a default 3
    public static double ForDouble(string str)
    {
        double value;
        if (string.IsNullOrEmpty(str) || !double.TryParse(str, out value))
        {
            return 1.0;
        }
        else if (value < 0 && value < 3)
        {
            return 3;
        }
        return value;

    }

    public static void Main(string[] args)
    {
        StudentList<List<Student>> studentList = new StudentList<List<Student>>();
        bool flag = true;
        int choice = 0;
        do
        {
            Console.WriteLine("enter your choice");
            Console.WriteLine(" 1. add a student  \n 2. view added students \n 3. search students by id or name \n other. exit");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " message end");
            }

            if (choice < 5 && choice > 0)
            {
                if (choice == 1)
                {
                    string name = inputAccepeter("name of student");
                    double grade = ForDouble(inputAccepeter("enter student grade"));
                    int age = (int)ForDouble(inputAccepeter("enter student age"));
                    Student student = new Student(studentList.Count()+1, name, age, grade);
                    studentList.AddStudent(student);
                }
                else if (choice == 2)
                {
                    studentList.ViewStudent();
                }
                else if (choice == 3)
                {
                    StudentList<Student>.SearchStudent(inputAccepeter("name or id to search for"));

                }

            }
            else
            {
                flag = false;
            }
        } while (flag);
    }
}
