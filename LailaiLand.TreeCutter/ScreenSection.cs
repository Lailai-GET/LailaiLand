namespace LailaiLand.TreeCutter
{
    internal class ScreenSection
    {
        protected string[] Document;
        public bool Branch { get; protected set; }
        public bool Dude { get; protected set; }

        protected ScreenSection(string path)
        {
            Document = File.ReadAllLines(path);

        }

        public void DrawLine(int y)
        {
            Console.Write(Document[y]);
        }
    }
}
