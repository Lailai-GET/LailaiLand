namespace LailaiLand.TreeCutter
{
    internal class SectionRight : ScreenSection
    {

        public SectionRight(string path, bool branch, bool dude) : base(path)
        {
            var newStringArray = new string[7];
            for (var i = 0; i < Document.Length; i++)
            {
                var line = Document[i];
                if (line.Length == 13)
                {

                    newStringArray[i] = line.PadRight(26, ' ');

                }
                else { newStringArray[i] = line; }
            }
            Document = newStringArray;
            Branch = branch;
            Dude = dude;
        }
    }
}
