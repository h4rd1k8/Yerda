using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public int a;
        public int b;
        public Complex(int x, int y)
        {
            this.a = x;
            this.b = y;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            int a = c1.a + c2.a;
            int b = c2.b + c2.b;
            return new Complex(a,b);
        }
        public override string ToString()
        {
            return a + " " + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(2, 7);
            Complex c2 = new Complex(3, 7);
            Complex c3 = c1 + c2;
            Console.WriteLine(c3);
        }
    }
}