namespace GameOfLife.Scripts.Model
{
    public interface IRuleset
    {
        void Eval(ref int[,] cells);
    }
}
