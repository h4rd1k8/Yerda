using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2_W3D1
{

    enum FarMode
    {
        Explorer,
        FileReader
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(45, 45);
            FAR far = new FAR(@"C:\");

            bool quit = false;

            while (!quit)
            {
                far.Draw();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Enter:
                        far.Process(pressedKey);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class Layer
    {
        public DirectoryInfo dirInfo;
        public string path;
        public int index;
        public List<FileSystemInfo> items;

        public Layer(string path, int index)
        {
            this.path = path;
            this.index = index;
            this.dirInfo = new DirectoryInfo(path);

            items = new List<FileSystemInfo>();
            items.AddRange(dirInfo.GetDirectories());
            items.AddRange(dirInfo.GetFiles());

        }

        public void Process(int v)
        {
            this.index += v;
            if (this.index < 0)
            {
                this.index = items.Count - 1;
            }
            if (this.index >= items.Count)
            {
                this.index = 0;
            }
        }

        public string GetSelectedItemInfo()
        {
            return this.items[index].FullName;
        }
    }

    class FAR
    {
        Stack<Layer> layerHistory = new Stack<Layer>();
        Layer activeLayer;
        FarMode mode = FarMode.Explorer;

        public FAR(string path)
        {
            this.activeLayer = new Layer(path, 0);
        }

        public void Draw()
        {
            switch (mode)
            {
                case FarMode.Explorer:

                    DrawExplorer();

                    break;
                case FarMode.FileReader:

                    DrawFileReader();

                    break;
                default:
                    break;
            }

            DrawStatusBar();
        }

        private void DrawStatusBar()
        {
            Console.SetCursorPosition(0, 43);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(mode);
            Console.WriteLine(activeLayer.path);
            Console.SetCursorPosition(10, 43);
            Console.WriteLine(activeLayer.items.Count);
        }

        private void DrawFileReader()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(activeLayer.GetSelectedItemInfo(), FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                Console.WriteLine(sr.ReadToEnd());

            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open file!");

            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void DrawExplorer()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            for (int i = 0; i < activeLayer.items.Count; ++i)
            {
                if (i == activeLayer.index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (activeLayer.items[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.Write   (activeLayer.items[i].Name);
                for (int j = 1; j <= 30 - activeLayer.items[i].Name.Length; ++j)
                {
                    Console.Write(' ');
                }
                Console.WriteLine('*');
            }
        }

        public void Process(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    activeLayer.Process(-1);
                    break;
                case ConsoleKey.DownArrow:
                    activeLayer.Process(1);
                    break;
                case ConsoleKey.Enter:
                    try
                    {
                        if (activeLayer.items[activeLayer.index].GetType() == typeof(DirectoryInfo))
                        {
                            mode = FarMode.Explorer;
                            layerHistory.Push(activeLayer);
                            activeLayer = new Layer(activeLayer.GetSelectedItemInfo(), 0);
                        }
                        else if (activeLayer.items[activeLayer.index].GetType() == typeof(FileInfo))
                        {
                            mode = FarMode.FileReader;


                        }
                    }
                    catch (Exception e)
                    {
                        activeLayer = layerHistory.Pop();
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (mode == FarMode.Explorer)
                    {
                        activeLayer = layerHistory.Pop();
                    }
                    else if (mode == FarMode.FileReader)
                    {
                        mode = FarMode.Explorer;
                    }

                    break;
                default:
                    break;
            }

        }
    }

}