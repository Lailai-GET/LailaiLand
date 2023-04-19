namespace LailaiLand.TreeCutter
{
    internal class SectionRow
    {
        public List<ScreenSection> Row { get; }

        public SectionRow(string leftPath, bool leftBranch, bool leftDude, string centerPath, string rightPath, bool rightBranch, bool rightDude)
        {
            Row = new List<ScreenSection>
            {
                new SectionLeft(leftPath, leftBranch, leftDude),
                new SectionCenter(centerPath),
                new SectionRight(rightPath, rightBranch, rightDude)
            };
        }

        public void WriteRow()
        {
            for (int i = 0; i < 7; i++)
            {
                foreach (var section in Row)
                { 
                    section.DrawLine(i);
                }
                Console.WriteLine();
            }
        }
        
    }
}
