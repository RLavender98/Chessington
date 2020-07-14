namespace Chessington.GameEngine
{
    public class TravelStep
    {
        public int DeltaCol { get; set; }
        public int DeltaRow { get; set; }

        public TravelStep(int dcol, int drow)
        {
            DeltaCol = dcol;
            DeltaRow = drow;
        }
        public Square TravelFromSquare(Square square)
        {
            return Square.At(square.Row + DeltaRow, square.Col + DeltaCol);
        }
    }
}