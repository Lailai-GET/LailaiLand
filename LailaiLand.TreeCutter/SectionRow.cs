namespace LailaiLand.TreeCutter
{
    internal class SectionRow
    {
        private List<ScreenSection> _row;

        public SectionRow(string leftPath, string centerPath, string rightPath)
        {
            _row = new List<ScreenSection>
            {
                new SectionLeft(leftPath),
                new SectionCenter(centerPath),
                new SectionRight(rightPath),
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
