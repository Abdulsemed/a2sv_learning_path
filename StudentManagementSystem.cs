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
        public override string ToString()
        {
            return $"{Rollnumber} \t {Name} \t {Age} \t {Grade}";
        }
    }
    class StudentList<T>
    {
        public List<T> students = new List<T>();

        public void AddStudent(T student)
        {
            students.Add(student);
        }
        private void DisplayStudent(List<T> item)
        {
            Console.WriteLine("RollNumber \t Name \t Age \t Grade");
            foreach (var student in item)
            {
                Console.WriteLine(student.ToString());
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

        public static void SearchStudentById(List<Student> studentList,int query)
        {

           IEnumerable<Student> result = from student in studentList where student.Rollnumber == query select student;
           if(result.Count() == 1)
            {
                Console.WriteLine(result.ElementAt(0).ToString());
            }
            else
            {
                Console.WriteLine($"{query} was not found");
            }

        }

        public static void SearchStudentByName(List<Student> studentList,string name)
        {
            IEnumerable<Student> result = from student in studentList where student.Name == name select student;
            if (result.Count() == 1)
            {
                Console.WriteLine(result.ElementAt(0).ToString());
            }
            else
            {
                Console.WriteLine($"{name} was not found");
            }
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
        else if (value < 0 && value > 4.0)
        {
            return 1.0;
        }
        return value;

    }

    public static void Main(string[] args)
    {
        StudentList<Student> students = new StudentList<Student>();
        bool flag = true;
        int choice = 0;
        do
        {
            Console.WriteLine("enter your choice");
            Console.WriteLine(" 1. add a student  \n 2. view added students \n 3. search students by name \n 4. search students by id \n other. exit");
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
                    Student student = new Student(students.Count()+1, name, age, grade);
                    students.AddStudent(student);
                }
                else if (choice == 2)
                {
                    students.ViewStudent();
                }
                else if (choice == 3)
                {
                    StudentList<Student>.SearchStudentByName(students.students,inputAccepeter("name of student to search"));

                }else if(choice == 4)
                {
                    StudentList<Student>.SearchStudentById(students.students,(int)ForDouble(inputAccepeter("id of student to search")));
                }

            }
            else
            {
                flag = false;
            }
        } while (flag);
    }
}
