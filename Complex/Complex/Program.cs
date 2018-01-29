using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {   
        public static Complex operator +(Complex c1, Complex c2)
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите комплексное число:");
            string a = Console.ReadLine();
            string[] numbers = a.Split(' ');
            string[] numbers1 = new string [4];
            int[] numbers2 = new int[4];
            for(int i = 0; i < 4; ++i)
            {
                numbers1 = numbers[i].Split('/');
                numbers2 = int.Parse(numbers1);
            }
        }
    }
}
