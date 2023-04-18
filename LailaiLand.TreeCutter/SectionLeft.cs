namespace LailaiLand.TreeCutter
{
    internal class SectionLeft : ScreenSection
    {
        public SectionLeft(string path) : base(path)
        {
            var newStringArray = new string[7];
            for (var i = 0; i < _document.Length; i++)
            {
                var line = _document[i];
                if (line.Length == 10)
                {

                    newStringArray[i] = line.PadLeft(20, ' ');
                    
                }
                else { newStringArray[i] = line; }
            }
            _document = newStringArray;
        }
    }
}
