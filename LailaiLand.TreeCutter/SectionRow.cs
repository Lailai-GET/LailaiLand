namespace LailaiLand.TreeCutter
{
    internal class SectionRow
    {
        private List<ScreenSection> _row;

        public SectionRow(string leftPath, string centerPath, string rightPath, bool branch, bool dude)
        {
            _row = new List<ScreenSection>
            {
                new SectionLeft(leftPath, branch, dude),
                new SectionCenter(centerPath, branch, dude),
                new SectionRight(rightPath, branch, dude),
            };
        }

        public void WriteRow()
        {
            for (int i = 0; i < 7; i++)
            {
                foreach (var section in _row)
                { 
                    section.DrawLine(i);
                }
                Console.WriteLine();
            }
        }
        
    }
}
