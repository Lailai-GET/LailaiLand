using System.Security.Cryptography;

namespace LailaiLand.TreeCutter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rowTest = new Screen();
            rowTest.DrawScreen();
        }
    }
}
            //var keypress = new KeyPresser();

            //ConsoleKeyInfo keyInfo;
            //var path = "Assets\\Tree.Dude.txt";
            //var treeDude = File.ReadAllLines(path);
            //do
            //{
            //    keyInfo = keypress.Keypress();

            //    switch (keyInfo.Key)
            //    {
            //        case ConsoleKey.UpArrow:
            //            Console.WriteLine("Up arrow key pressed");
            //            break;
            //        case ConsoleKey.W:
            //            Console.WriteLine("W key pressed");
            //            break;
            //        case ConsoleKey.DownArrow:
            //            Console.WriteLine("Down arrow key pressed");
            //            break;
            //        case ConsoleKey.S:
            //            Console.WriteLine("S key pressed");
            //            break;
            //        case ConsoleKey.LeftArrow:
            //            Console.WriteLine("Left arrow key pressed");
            //            break;
            //        case ConsoleKey.A:
            //            Console.WriteLine("A key pressed");
            //            break;
            //        case ConsoleKey.RightArrow:
            //            Console.WriteLine("Right arrow key pressed");
            //            break;
            //        case ConsoleKey.D:
            //            Console.WriteLine("D key pressed");
            //            break;
            //        default:
            //            Console.WriteLine("Invalid key pressed");
            //            break;
            //    }

            //    foreach (var line in treeDude)
            //    {
            //        Console.WriteLine(line);
            //    }
            //} while (keyInfo.Key != ConsoleKey.Escape);