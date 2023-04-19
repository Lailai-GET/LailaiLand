namespace LailaiLand.TreeCutter
{
    internal class KeyPresser
    {
        private ConsoleKeyInfo _keyInfo;
        private Screen _screen;

        public KeyPresser(Screen screen)
        {
            _screen = screen;
        }

        public void RunGame()
        {
            _screen.DrawScreen();
            do
            {
                _keyInfo = Console.ReadKey(true);

                if (_keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (_keyInfo.Key == ConsoleKey.UpArrow)
                {
                    Console.WriteLine("Up arrow key pressed");
                }
                else if (_keyInfo.Key == ConsoleKey.DownArrow)
                {
                    Console.WriteLine("Down arrow key pressed");
                }
                else if (_keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine("Left arrow key pressed");
                }
                else if (_keyInfo.Key == ConsoleKey.RightArrow)
                {
                    Console.WriteLine("Right arrow key pressed");
                }
            } while (true);
        }
    }
}
//https://learn.microsoft.com/en-us/dotnet/standard/events/
