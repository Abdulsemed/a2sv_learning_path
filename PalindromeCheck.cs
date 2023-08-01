using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2sv_trials
{
    internal class wordCounter
    {
        public static bool checkPalindrome(string passedString)
        {
            int left = 0;
            int right = passedString.Length-1;
            bool Flag = true;
            while (left < right)
            {
                if (passedString[left] != passedString[right] )
                {
                    Flag = false;
                    break;
                }
                left++;
                right--;

            }
            return Flag;
        }
        public static void Main(string[] args)
        {
        y: Console.WriteLine("Enter the string input");
            string? current = Console.ReadLine();
            if (current == null)
            {
                goto y;
            }
            bool flag = checkPalindrome(current);
            if (flag)
            {
                Console.WriteLine("it is a palindrome");
            }
            else
            {
                Console.WriteLine("it is not a palindrome");
            }
           

        }
    }
}
