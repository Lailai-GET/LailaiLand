namespace LailaiLand.TreeCutter
{
    internal class Screen
    {
        private List<SectionRow> _rows;
        public string Trunk = "Assets\\Tree.Trunk.txt";
        public string TrunkL = "Assets\\Tree.TrunkL.txt";
        public string TrunkR = "Assets\\Tree.TrunkR.txt";
        public string DudeL = "Assets\\Tree.DudeL.txt";
        public string DudeR = "Assets\\Tree.DudeR.txt";
        public string DudeJmpL = "Assets\\Tree.DudeJmpL.txt";
        public string DudeJmpR = "Assets\\Tree.DudeJmpR.txt";
        public string DeathL = "Assets\\Tree.DeathL.txt";
        public string DeathR = "Assets\\Tree.DeathR.txt";
        public string DeadL = "Assets\\Tree.DeadL.txt";
        public string DeadR = "Assets\\Tree.DeadR.txt";
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
            _rows.Add(new SectionRow(Empty,
                false,
                false,
                Trunk,
                Empty,
                false,
                false));
            _rows.Add(new SectionRow(Empty,
                false,
                false,
                Trunk,
                DudeR,
                false,
                true));
        }

        private void GenerateRandomRow()
        {
            var random = new Random();
            var branchSide = random.Next(0, 3);
            switch (branchSide)
            {
                case 0:
                    _rows.Add(new SectionRow(Branches[branchSide],
                        true,
                        false,
                        Trunk,
                        Empty,
                        false,
                        false));
                    break;
                case 1:
                    _rows.Add(new SectionRow(Empty,
                        false,
                        false,
                        Trunk,
                        Branches[branchSide],
                        true,
                        false));
                    break;
                default:
                    _rows.Add(new SectionRow(Empty,
                        false,
                        false,
                        Trunk,
                        Empty,
                        false,
                        false));
                    break;
            }
        }

        public void DrawScreen(KeyPresser game)
        {
            if (game.Points == -1)
            {
                _rows[2] = new SectionRow(Empty,
                    false,
                    false,
                    Trunk,
                    DudeR,
                    false,
                    true);
                game.AddPoints();
            }
            foreach (var row in _rows)
            {
                row.WriteRow();
            }

            Console.WriteLine($"Score: {game.Points}");
        }

        public void Move(string side, KeyPresser game)
        {
            var lastRow = _rows.Last();
            _rows.Remove(lastRow);
            if (side == "left")
            {
                _rows.Add(new SectionRow(DudeJmpL,
                    lastRow.Row[0].Branch,
                    true, Empty,
                    lastRow.Row[2].Branch
                        ? TrunkR
                        : lastRow.Row[0].Branch
                            ? TrunkL
                            : Trunk,
                    lastRow.Row[2].Branch,
                    false));
            }
            else if (side == "right")
            {
                _rows.Add(new SectionRow(
                    lastRow.Row[0].Branch
                        ? TrunkL
                        : lastRow.Row[2].Branch
                            ? TrunkR
                            : Trunk,
                    lastRow.Row[0].Branch,
                    false, Empty,
                    DudeJmpR,
                    lastRow.Row[2].Branch,
                    true));
            }
            Console.Clear();
            DrawScreen(game);
            Thread.Sleep(100);
            Progression(side, game);
        }


        private void Progression(string side, KeyPresser game)
        {
            var secondRow = _rows[0];
            if (_rows[1].Row[0].Branch && _rows[2].Row[0].Dude)
            {
                game.Over();
                GameOver(side, game, secondRow);
                return;
            }
            if (_rows[1].Row[2].Branch && _rows[2].Row[2].Dude)
            {
                game.Over();
                GameOver(side, game, secondRow);
                return;
            }
            game.AddPoints();
            var thirdRow = _rows[2].Row[0].Dude
                ? new SectionRow(DudeL,
                    false,
                    true,
                    Trunk,
                    _rows[1].Row[2].Branch
                        ? Branches[1]
                        : Empty,
                    _rows[1].Row[2].Branch,
                    false)
                : new SectionRow(_rows[1].Row[0].Branch
                    ? Branches[0]
                    : Empty,
                    _rows[1].Row[0].Branch,
                    false,
                    Trunk,
                    DudeR,
                    false,
                    true);
            _rows.Clear();
            _rows = new List<SectionRow>();
            GenerateRandomRow();
            _rows.Add(secondRow);
            _rows.Add(thirdRow);
            Thread.Sleep(100);
            Console.Clear();
            DrawScreen(game);
        }

        private void GameOver(string side, KeyPresser game, SectionRow secondRow)
        {
            Thread.Sleep(500);
            _rows.Clear();
            _rows = new List<SectionRow>();
            GenerateRandomRow();
            _rows.Add(secondRow);
            _rows.Add(side == "left"
                ? new SectionRow(DeathL,
                    true,
                    true,
                    Trunk,
                    Empty,
                    false,
                    false)
                : new SectionRow(Empty,
                    false,
                    false,
                    Trunk,
                    DeathR,
                    true,
                    true));
            Console.Clear();
            DrawScreen(game);
            Thread.Sleep(1000);
            _rows[2] = side == "left"
                ? new SectionRow(DeadL,
                    true,
                    true,
                    Trunk,
                    Empty,
                    false,
                    false)
                : new SectionRow(Empty,
                    false,
                    false,
                    Trunk,
                    DeadR,
                    true,
                    true);
            Console.Clear();
            DrawScreen(game);
            Console.WriteLine("Game Over. Press Esc to retry");
        }
    }
}
