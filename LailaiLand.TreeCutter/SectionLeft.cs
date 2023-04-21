namespace LailaiLand.TreeCutter
{
    internal class SectionLeft : ScreenSection
    {
        
        public SectionLeft(string path, bool branch, bool dude) : base(path)
        {
            var newStringArray = new string[7];
            for (var i = 0; i < Document.Length; i++)
            {
                var line = Document[i];
                if (line.Length == 13)
                {

                    newStringArray[i] = line.PadLeft(26, ' ');

                }
                else { newStringArray[i] = line; }
            }
            Document = newStringArray;
            Branch = branch;
            Dude = dude;
        }
    }
}
