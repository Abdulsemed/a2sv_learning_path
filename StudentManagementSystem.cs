using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

class MainClass
{
    public class Student
    {
        public string Name ="";
        public readonly int RollNumber = 1;
        public int Age = 0;
        public double Grade = 0.0;
        [JsonConstructor]
        public Student(string Name,int RollNumber, int Age, double Grade) { 
            this.RollNumber = RollNumber;
            this.Name = Name;
            this.Age = Age;
            this.Grade = Grade;
        }
        public override string ToString()
        {
            return $"{RollNumber} \t {Name} \t {Age} \t {Grade}";
        }

    }
    // generic class to create diffrent types of list
    class StudentList<T>
    {
        protected List<T> students = new List<T>();
        //change access
        protected string FileName = "students.json";
        public List<T> GetStudents()
        {
            return students ;
        }
        public async void Init()
        {
            if(!File.Exists(FileName)) {
                File.Create(FileName).Close();
            }
            ReadFromJson();
        }
        // method to read from a json file 
        public void ReadFromJson()
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };
            string StringJson = File.ReadAllText(FileName);
            try
            {
                students = JsonSerializer.Deserialize<List<T>>(StringJson,options)!;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // method to write to a json file
        public void WriteToJson()
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };
            string jsonString = JsonSerializer.Serialize(students,options);
            File.WriteAllText(FileName, jsonString);
        }
        public void AddStudent(T student)
        {
            students.Add(student);
        }
        private void DisplayStudent(List<T> items)
        {
            Console.WriteLine("RollNumber \t Name \t Age \t Grade");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void ViewStudent()
        {
            DisplayStudent(students);
        }
        // to assign a unique roll number we get the size of the lists
        public int Count()
        {
            return students.Count-1;
        }

        public static void SearchStudentById(List<Student> studentList,int query)
        {

           IEnumerable<Student> result = from student in studentList where student.RollNumber == query select student;
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
    // method to accept string input from console and validate it
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
    // function to accept and validate double inputs returns a default 1 for both age and grade
    public static double ForDouble(string str)
    {
        double value;
        if (string.IsNullOrEmpty(str) || !double.TryParse(str, out value))
        {
            return 1.0;
        }
        else if (value < 0)
        {
            return 1.0;
        }
        return value;

    }

    public static void Main(string[] args)
    {
        StudentList<Student> students = new StudentList<Student>();
        bool flag = true;
        students.Init();
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
            // menu for the console app
            if (choice < 5 && choice > 0)
            {
                if (choice == 1)
                {
                    string name = inputAccepeter("name of student");
                    double grade = ForDouble(inputAccepeter("enter student grade"));
                    if (grade <0 || grade > 4)
                    {
                        grade = 1.0;
                    }
                    int age = (int)ForDouble(inputAccepeter("enter student age"));
                    Student student = new Student(name, students.Count()+1,  age, grade);
                    students.AddStudent(student);
                    students.WriteToJson();
                }
                else if (choice == 2)
                {
                    students.ViewStudent();
                }
                else if (choice == 3)
                {
                    StudentList<Student>.SearchStudentByName(students.GetStudents(),inputAccepeter("name of student to search"));

                }else if(choice == 4)
                {
                    StudentList<Student>.SearchStudentById(students.GetStudents(),(int)ForDouble(inputAccepeter("id of student to search")));
                }

            }
            else
            {
                flag = false;
            }
        } while (flag);
    }
}
