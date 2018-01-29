using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR
{
    class Print
    {
        public static void Active(int index, FileSystemInfo[] arr)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                if (index == i)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write(arr[i].Name);
                for (int j = 1; j <= 30 - arr[i].Name.Length; ++j)
                {
                    Console.Write(' ');
                }
                Console.WriteLine('*');
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack<FileSystemInfo[]> NActive = new Stack<FileSystemInfo[]>();
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            FileSystemInfo[] arr = dir.GetFileSystemInfos();
            int index = 0;
            bool quit = false;
            while (!quit)
            {
                Print.Active(index, arr);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0) index = arr.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        index = (index + 1)%arr.Length;
                        break;
                    case ConsoleKey.Enter:
                        DirectoryInfo newActive = new DirectoryInfo(arr[index].FullName);
                        FileSystemInfo[] newarr = newActive.GetFileSystemInfos();
                        index = 0;
                        Print.Active(index, newarr);
                        NActive.Push(arr);
                        arr = newarr;
                        break;
                    case ConsoleKey.Backspace:
                        arr = NActive.Pop();
                        index = 0;
                        Print.Active(index, arr);
                        break;
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
