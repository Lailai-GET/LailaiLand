namespace LailaiLand.TreeCutter
{
    internal class KeyPresser
    {
        private ConsoleKeyInfo _key;

        public ConsoleKeyInfo Keypress()
        {
            ConsoleKeyInfo keyInfo;

            keyInfo = Console.ReadKey(true);
            _key = keyInfo;
            return _key;
        }
    }
}
