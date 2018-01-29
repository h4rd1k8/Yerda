using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Rectangle
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Width:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Height:");
            int b = int.Parse(Console.ReadLine());
            int findArea(int x, int y)
            {
                return x * y;
            }
            int findPerimetr(int x, int y)
            {
                return x + y;
            }
            Console.WriteLine("Area:");
            Console.WriteLine(findArea(a, b));
            Console.WriteLine("Perimetr:");
            Console.WriteLine(findPerimetr(a, b));
        }
    }

}