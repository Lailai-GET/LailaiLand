namespace LailaiLand.TreeCutter
{
    internal class KeyPresser
    {
        private ConsoleKeyInfo _keyInfo;
        private bool _run = true;
        public int Points { get; private set; }
        private Screen _screen;

        public KeyPresser(Screen screen)
        {
            Points = -1;
            _screen = screen;
        }

        public void RunGame()
        {
            _screen.DrawScreen(this);
            do
            {
                _keyInfo = Console.ReadKey(true);


                if (_keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    _screen.Move("left", this);
                }
                else if (_keyInfo.Key == ConsoleKey.RightArrow)
                {
                    _screen.Move("right", this);
                }

            } while (_run);

            if (!_run) PressEsc();
        }

        private void PressEsc()
        {
            Points = -1;
            do
            {
                _keyInfo = Console.ReadKey(true);
                if (_keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
            } while (!_run);
            Over();
            Console.Clear();
            RunGame();
        }

        public void Over()
        {
            _run = !_run;
        }

        public void AddPoints()
        {
            Points++;
        }
    }
}
//https://learn.microsoft.com/en-us/dotnet/standard/events/
