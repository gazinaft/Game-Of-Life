namespace GameOfLife.Scripts.Model
{
    public class CA
    {
        public int Generation { get; private set; }
        public IRuleset Rules { get; set; }
        public int[,] Cells;

        public readonly int Columns; // x
        public readonly int Rows; // y
        
        public CA(int[,] cells, IRuleset rules)
        {
            Cells = cells;
            Generation = 0;
            Rules = rules;
            
            Columns = cells.GetLength(0);
            Rows = cells.GetLength(1);
        }

        public void NextStep()
        {
            Rules.Eval(ref Cells);
            Generation++;
        }

        public void MakeNSteps(int n)
        {
            for (int i = 0; i < n; ++i)
            {
                Rules.Eval(ref Cells);
            }
            Generation += n;
        }
    }
}
