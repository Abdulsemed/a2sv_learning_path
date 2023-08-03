using System;
class MainClass
{
    public enum Category
    {
        Personal,
        Work,
        Errand,
        unknown
    }
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public bool IsCompleted { get; set; }


    }

    public class TaskManager
    {
        public List<Task> Tasks { get; set; }
        public TaskManager()
        {
            //file open and write to Tasks
        }
        public void AddTask(Task task)
        {
            // file read and write here
            Tasks.Add(task);
        }
        private void Display(List<Task> param)
        {
            Console.WriteLine("Name \t description \t category \t isCompleted");
            foreach (var task in param)
            {
                Console.WriteLine($"{task.Name} \t {task.Description} \t {task.Category} \t {task.IsCompleted}");
            }
        }
        public void view()
        {
            Display(Tasks);
        }

        public void Filtering(Category category)
        {
            var filtered = Tasks.Where(task => task.Category == category);
            if (filtered != null)
            {
                Display((List<Task>)filtered);
            }
            else
            {
                Console.WriteLine("no match");
            }

        }
        public Task Search(string query)
        {
            Task? task = Tasks.Find(task => task.Name == query);
            return task;
        }

        public void Updating(Task task, string name, string description, Category category, bool complete)
        {
            task.Name = name;
            task.Description = description;
            task.Category = category;
            task.IsCompleted = complete;
            // file read, delete and update here

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
    public static Task addTaskParams()
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
        Task task = new Task() { Name = name, Category = category, Description = description, IsCompleted = complete };
        return task;
    }
    public static void Main(string[] args)
    {
        TaskManager manager = new TaskManager();
        bool flag = true;
        do
        {
            Console.WriteLine("enter your choice");
            Console.WriteLine(" 1. add a Task  \n 2. view Tasks \n 3. filter tasks \n 4. update a task \n other. exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice < 5 && choice > 0)
            {
                if (choice == 1)
                {
                    

                }
                else if (choice == 2)
                {
                }
                else if (choice == 3)
                {
                }
                else if (choice == 4)
                {
                }

            }
            else
            {
                flag = false;
            }
        } while (flag);
    }
}
