using System;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

class MainClass
{
    public enum Category
    {
        Personal,
        Work,
        Errand,
        unknown
    }
    public class Tasks
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Category Category { get; set; }
        public bool IsCompleted { get; set; }


    }
    // class for manipulating files
    public class FileManager
    {
        public async Task WriteToFile(FileStream fs, List<Tasks> tasks)
        {
            //file open and write to Tasks
            foreach (Tasks task in tasks)
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(task.Name + " " + task.Description + " " + task.Category + " " + task.IsCompleted+"\n");
                await fs.WriteAsync(encodedText);
            }

            
        }
        // method read tasks from txt and append the to taks list
        public async Task ReadFile(FileStream fs, List<Tasks> tasks)
        {
            string text;
            var streamReader = new StreamReader(fs);
            string name;
            string description;
            Category category;
            bool isCompleted = false;
            while((text = await streamReader.ReadLineAsync()) != null)
            {
                string[] lists = text.Split(" ");
                name = lists[0];
                description = lists[1];
                category =(Category) Enum.Parse(typeof(Category), lists[2]);
                if (lists[3] == "true")
                {
                    isCompleted = true;
                }
                Tasks task = new Tasks() { Name = name, Category = category, Description = description, IsCompleted = isCompleted };
                tasks.Add(task);
            }

        }
    }
    // class to manage the tasks

    public class TaskManager
    {
        public List<Tasks> Tasks = new List<Tasks>();
        private string nameOfFile = "tasks.txt";
        FileManager fileManager = new FileManager();
        public TaskManager()
        {
            if (!File.Exists(nameOfFile))
            {
                File.Create(nameOfFile).Close();
            }
        }
        // an initial function to read tasks from file
        public async void Init()
        {
            try
            {
                FileStream fs = File.Open(nameOfFile, FileMode.Open, FileAccess.ReadWrite);
                await fileManager.ReadFile(fs, Tasks);
                fs.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
        public async void AddTask(Tasks task)
        {
            try
            {
                FileStream fs = File.Open(nameOfFile, FileMode.Open, FileAccess.ReadWrite);
                Tasks.Add(task);
                await fileManager.WriteToFile(fs, Tasks);
                fs.Close();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            // file read and write here
            
        }
        private void Display(List<Tasks> param)
        {
            Console.WriteLine("Name \t description \t category \t isCompleted");
            foreach (var task in param)
            {
                Console.WriteLine($"{task.Name} \t {task.Description} \t {task.Category} \t {task.IsCompleted}");
            }
        }
        public void View()
        {
            Display(Tasks);
        }
        // function to filter tasks based on the category
        public void Filtering(Category category)
        {
            var filtered = Tasks.Where(task => task.Category == category).ToList();
            if (filtered != null)
            {
                Display(filtered);
            }
            else
            {
                Console.WriteLine("no match");
            }

        }
        public Tasks Search(string query)
        {
            Tasks? task = Tasks.Find(task => task.Name == query);
            return task;
        }

        public async void Updating(Tasks oldTask, Tasks updatedTask)
        {
            Tasks[Tasks.IndexOf(oldTask)] = updatedTask;
            FileStream fs = File.Open(nameOfFile, FileMode.Open, FileAccess.ReadWrite);
            // file read and write here
            await fileManager.WriteToFile(fs, Tasks);
            fs.Close();
        }
    }
    // function to accept and validate string inputs
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
    public static int forInt(string str)
    {
        int value;
        if (string.IsNullOrEmpty(str) || !int.TryParse(str, out value))
        {
            return 3;
        }
        else if(value < 0 && value > 3)
        {
            return 3;
        }
        return value;

    }
    //method to create tasks
    public static Tasks addTaskParams()
    {
        string name;
        string description;
        int choice;
        bool complete = false;
        name = inputAccepeter("task name");
        description = inputAccepeter("task description");
        choice = forInt(inputAccepeter(" category, 0. personal 1. work 2. errand"));
        Category category = (Category)choice;
        if (inputAccepeter("status, Yes. completed other not completed").ToLower() == "yes")
        {
            complete = true;
        }
        Tasks task = new Tasks() { Name = name, Category = category, Description = description, IsCompleted = complete };
        return task;
    }
    public static void Main(string[] args)
    {
        TaskManager manager = new TaskManager();
        manager.Init();
        bool flag = true;
        int choice = 0;
        do
        {
            Console.WriteLine("enter your choice");
            Console.WriteLine(" 1. add a Task  \n 2. view Tasks \n 3. filter tasks \n 4. update a task \n other. exit");
            try
            {
               choice = Convert.ToInt32(Console.ReadLine());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message +" message end");
            }
            
            if (choice < 5 && choice > 0)
            {
                if (choice == 1)
                {
                    Tasks task = addTaskParams();
                    manager.AddTask(task);

                }
                else if (choice == 2)
                {
                    manager.View();
                }
                else if (choice == 3)
                {
                    int value = forInt(inputAccepeter(" category, 0. personal 1. work 2. errand"));
                    manager.Filtering((Category)value);

                }
                else if (choice == 4)
                {
                    Tasks task = manager.Search(inputAccepeter("name of task to search"));
                    if (task != null)
                    {
                        manager.Updating(task, addTaskParams());
                    }
                    else
                    {
                        Console.WriteLine("task not found");
                    }
                }

            }
            else
            {
                flag = false;
            }
        } while (flag);
    }
}
