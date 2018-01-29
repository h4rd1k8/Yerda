using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{
    class Program
    {
        static void PrintState(int index, FileSystemInfo[] arr)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (index == i)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write(arr[i].Name);

                for (int j = 1; j <= 20 - arr[i].Name.Length; ++j)
                {
                    Console.Write(' ');
                }

                Console.WriteLine('|');
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\");
            FileSystemInfo[] arr = di.GetFileSystemInfos();
            int index = 0;
            bool quit = false;

            while (!quit)
            {
                PrintState(index, arr);

                ConsoleKeyInfo pressedKey = Console.ReadKey();


                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0) index = arr.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        index = (index + 1) % arr.Length;
                        break;
                    case ConsoleKey.Enter:
                        if (arr[index].GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = arr[index] as DirectoryInfo;
                            arr = d.GetFileSystemInfos();
                            index = 0;
                        }
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