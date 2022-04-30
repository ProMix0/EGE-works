namespace N19_21
{
    //TODO
    public class PositionTableBuilder
    {
        internal  int firstMin;
        internal int secondMin;
        internal int winCount;
        internal List<Func<int, int>> turns;

        internal PositionTableBuilder(List<Func<int, int>> turns)
        {
            this.turns = turns;
        }

        public PositionTableBuilder StartHeap(int firstMin)
        {
            this.firstMin= firstMin;

            throw new NotImplementedException();
        }
    }
}