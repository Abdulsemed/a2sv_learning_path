
using System;
class MainClass
{
    enum Category
    {
        Personal,
        Work,
        Errand
    }
    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public bool IsCompleted { get; set; }


    }

    class TaskManager
    {
        public List<Task> Tasks { get; set; }
        public void AddTask(Task task)
        {
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

        public void filtering(Category category)
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

        public void updating(Task task)
        {

        }
    }
}
