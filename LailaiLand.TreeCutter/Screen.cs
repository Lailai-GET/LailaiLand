namespace LailaiLand.TreeCutter
{
    internal class Screen
    {
        private List<SectionRow> _rows;
        public string Trunk = "Assets\\Tree.Trunk.txt";
        public string Dude = "Assets\\Tree.Dude.txt";
        public string Empty = "Assets\\Empty.txt";
        public string[] Branches = new[]
        {
            "Assets\\Tree.Left.txt",
            "Assets\\Tree.Right.txt"
        };

        public Screen()
        {
            _rows = new List<SectionRow>();
            GenerateRandomRow();
            _rows.Add(new SectionRow(Empty, Trunk, Empty, false, false, false, false, false));
            _rows.Add(new SectionRow(Empty, Trunk, Dude, false, false, false, true, false));
        }

        private void GenerateRandomRow()
        {
            var random = new Random();
            var branchSide = random.Next(0, 3);
            switch (branchSide)
            {
                case 0:
                    _rows.Add(new SectionRow(Branches[branchSide], Trunk, Empty, true, false, false, false, false));
                    break;
                case 1:
                    _rows.Add(new SectionRow(Empty, Trunk, Branches[branchSide], false, true, false, false, false));
                    break;
                default:
                    _rows.Add(new SectionRow(Empty, Trunk, Empty, false, false, false, false, false));
                    break;
            }
        }

        public void DrawScreen()
        {
            foreach (var row in _rows)
            {
                row.WriteRow();
            }
        }

        //public void MoveLeft()
        //{
            
        //    _rows[2] = new SectionRow(/*lag fin en her hvor en hugger til høyre*/)
        //}
    }
}
