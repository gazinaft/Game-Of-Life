namespace GameOfLife.Scripts.Model
{
    public class CA
    {
        public int Generation { get; private set; }
        private IRuleset _rules;
        public Cell[,] Cells;

        public int Columns; // x
        public int Rows; // y
        
        public CA(Cell[,] cells, IRuleset rules)
        {
            Cells = cells;
            Generation = 0;
            _rules = rules;
            
            Columns = cells.GetLength(0);
            Rows = cells.GetLength(1);
        }

        public void NextStep()
        {
            _rules.Eval(this);
            Generation++;
        }

        public void MakeNSteps(int n)
        {
            for (int i = 0; i < n; ++i)
            {
                _rules.Eval(this);
            }
            Generation += n;
        }
    }
}