using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Complex
    {
        public int a;
        public int b;
        public Complex(int x, int y)
        {
            a = x;
            b = y;
        }
        public Complex() { }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c3 = new Complex();
            c3.a = c1.a + c2.a;
            c3.b = c2.b + c2.b;
            return c3;
        }
        public override string ToString()
        {
            return a + " " + b;
        }
    }
    class Program
    {
        static void serialization()
        {
            FileStream fs = new FileStream(@"data.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex c4 = new Complex(3, 4);
            xs.Serialize(fs, c4);
            fs.Close();
        }
        static Complex deserialization()
        {
            FileStream fs = new FileStream(@"data.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex c3 = xs.Deserialize(fs) as Complex;
            fs.Close();
            return c3;
        }
        static void Main(string[] args)
        {
            serialization();
            Console.WriteLine(deserialization());
        }
    }
}