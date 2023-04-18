namespace LailaiLand.TreeCutter
{
    internal class ScreenSection
    {
        protected string[] _document;

        protected ScreenSection(string path)
        {
            _document = File.ReadAllLines(path);
        }

        public void DrawLine(int y)
        {
            Console.Write(_document[y]);
        }
    }
}
