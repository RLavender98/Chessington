namespace Chessington.GameEngine
{
    public class Move
    {
        public Square From { get; set; }
        public Square To { get; set; }

        public static bool operator ==(Move one, Move two)
        {
            return (one.From == two.From && one.To == two.To);
        }
        
        public static bool operator !=(Move one, Move two)
        {
            return (one.From != two.From || one.To != two.To);
        }
    }
}