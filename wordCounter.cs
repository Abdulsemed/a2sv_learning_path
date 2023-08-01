using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2sv_trials
{
    internal class wordCounter
    {
        public static Dictionary<string, int> count(string passedString)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            string[] words = passedString.Split(" ");
            foreach (var word in words)
            {
                if (counter.ContainsKey(word))
                {
                    counter[word]++;

                }
                else
                {
                    counter[word] = 1;
                }
            }
            return counter;
        }
        public static void Main(string[] args)
        {
        y: Console.WriteLine("Enter the string input");
            string? current = Console.ReadLine();
            if (current == null)
            {
                goto y;
            }
            count(current);

        }
    }
}
