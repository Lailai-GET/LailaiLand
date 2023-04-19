using System.Security.Cryptography;

namespace LailaiLand.TreeCutter
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var rowTest = new Screen();

            var runTest = new KeyPresser(rowTest);
            runTest.RunGame();
        }
    }
}
