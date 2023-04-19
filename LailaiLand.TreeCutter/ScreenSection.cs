namespace LailaiLand.TreeCutter
{
    internal class ScreenSection
    {
        protected string[] Document;
        protected bool Branch = false;
        protected bool Dude = false;

        protected ScreenSection(string path, bool branch, bool dude)
        {
            Document = File.ReadAllLines(path);
            Branch = branch;
            Dude = dude;
        }

        public void DrawLine(int y)
        {
            Console.Write(Document[y]);
        }
    }
}
