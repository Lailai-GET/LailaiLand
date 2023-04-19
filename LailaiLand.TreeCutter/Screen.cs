namespace LailaiLand.TreeCutter
{
    internal class Screen
    {
        private List<SectionRow> _rows;
        public string Trunk = "Assets\\Tree.Trunk.txt";
        public string Dude = "Assets\\Tree.Dude.txt";
        public string DudeJmp = "Assets\\Tree.DudeJmp.txt";
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
            _rows.Add(new SectionRow(Empty, false, false, Trunk, Empty, false, false));
            _rows.Add(new SectionRow(Empty, false, false, Trunk, Dude, false, true));
        }

        private void GenerateRandomRow()
        {
            var random = new Random();
            var branchSide = random.Next(0, 3);
            switch (branchSide)
            {
                case 0:
                    _rows.Add(new SectionRow(Branches[branchSide], true, false, Trunk, Empty, false, false));
                    break;
                case 1:
                    _rows.Add(new SectionRow(Empty, false, false, Trunk, Branches[branchSide], true, false));
                    break;
                default:
                    _rows.Add(new SectionRow(Empty, false, false, Trunk, Empty, false, false));
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

        public void MoveLeft()
        {
            var lastRow = _rows.Last();
            _rows.Remove(lastRow);
            _rows.Add(new SectionRow(DudeJmp, false, true, Empty, Trunk, false, false));
            Console.Clear();
            DrawScreen();
            Progression();
        }
        public void MoveRight()
        {
            var lastRow = _rows.Last();
            _rows.Remove(lastRow);
            _rows.Add(new SectionRow(Trunk, false, false, Empty, DudeJmp, false, true));
            Console.Clear();
            DrawScreen();
            Progression();
        }

        private void Progression()
        {
            //Kopier _rows[0] til _rows[1], generer ny random _rows[0], se med bool hvor dude og branch er, lag siste rad manuelt.
            var secondRow = _rows[0];
            if (_rows[1].Row[0].Branch && _rows[2].Row[0].Dude)
            {
                GameOver();
                return;
            }
            if (_rows[1].Row[2].Branch && _rows[2].Row[2].Dude)
            {
                GameOver();
                return;
            }
            var thirdRow = _rows[2].Row[0].Dude
                ? new SectionRow(Dude, false, true, Trunk, Empty, false, false)
                : new SectionRow(Empty, false, false, Trunk, Dude, false, true);
            _rows.Clear();
            _rows = new List<SectionRow>();
            GenerateRandomRow();
            _rows.Add(secondRow);
            _rows.Add(thirdRow);
            Thread.Sleep(100);
            Console.Clear();
            DrawScreen();
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
        }
    }
}
