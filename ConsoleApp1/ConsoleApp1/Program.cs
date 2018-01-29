using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        string firstName = "Yerdaulet";
        string lastName = "Alipbayev";
        double gpa = 2.43;
        public override string ToString(string firstName, string lastName, double gpa)
        {
            return this.firstName + ' ' + this.lastName + ' ' + this.gpa;
        }
        static void Main(string[] args)
        {
            Student a;
            Console.WriteLine(ToString(a.firstName, a.lastName, a.gpa));
        }
    }
}
