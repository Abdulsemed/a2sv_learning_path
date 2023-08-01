using System;
class Student
{

    public static float Average(List<float> list)
    {
        float sums = 0;
        foreach (var item in list)
        {
            sums += item;
        }
        float average = sums / list.Count;
        return average;
    }

    public static void Main(string[] args)
    {
        Dictionary<string, float> subjects = new Dictionary<string, float>();

        Console.WriteLine("enter your name");
        string name = Console.ReadLine();
        Console.WriteLine("enter the number of Subjects");
        int subjectSize = Convert.ToInt32(Console.ReadLine());
        for (int index = 0; index < subjectSize; index++)
        {
            y: Console.WriteLine("enter the name of the subject");
            string? v = Console.ReadLine();
            if (v == null)
            {
                goto y;
            }
            string subjectName = v;
            z: Console.WriteLine($"enter the grade");
            float subjectGrade = Convert.ToInt32(Console.ReadLine());
            if (subjectGrade < 0 && subjectGrade > 100) {
                goto z;
            }
            subjects[subjectName] = subjectGrade;
        }
        float average = Student.Average(new List<float>(subjects.Values));
        Console.WriteLine($"the student {name} took the following: ");

        foreach (var item in subjects)
        {
            Console.WriteLine("{0} with grade {1}", item.Key, item.Value);
        }
        Console.WriteLine(name+" has average of " + average);

    }



}
