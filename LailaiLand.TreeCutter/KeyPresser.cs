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
                if (_keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    _screen.MoveLeft();
                }
                else if (_keyInfo.Key == ConsoleKey.RightArrow)
                {
                    _screen.MoveRight();
                }
            } while (true);
        }
    }
}
//https://learn.microsoft.com/en-us/dotnet/standard/events/
