using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N19_21
{
    internal class PositionsTable
    {
        private readonly int firstMin;
        private readonly int secondMin;
        private readonly int winCount;
        private readonly List<Func<int, int>> turns;
        private readonly SortedDictionary<Point, PositionData> table = new();

        public PositionsTable(int firstMin, int secondMin, int winCount, List<Func<int, int>> turns)
        {
            this.firstMin = firstMin;
            this.secondMin = secondMin;
            this.winCount = winCount;
            this.turns = turns;
        }

        /*public static PositionTableBuilder New(List<Func<int, int>> turns)
        {
            return new(turns);
        }*/

        public PositionData this[int first, int second]
        {
            get
            {
                if (first < firstMin) throw new IndexOutOfRangeException();
                if (second < secondMin) throw new IndexOutOfRangeException();

                if (first + second >= winCount)
                    return new(false, 1);

                PositionData data;

                if (table.TryGetValue(new(first, second), out data))
                    return data;

                List<PositionData> positions = new();

                foreach (var turn in turns)
                {
                    positions.Add(this[turn(first), second]);
                    positions.Add(this[first, turn(second)]);
                }

                if (positions.All(position => position.Win))
                {
                    data = new(false, positions
                        .Select(position => position.TurnsCount)
                        .Min() + 1);

                    table.Add(new(first, second), data);
                }
                else
                {
                    data = new(true, positions
                        .Where(positions => !positions.Win)
                        .Select(positions => positions.TurnsCount)
                        .Min() - 1);

                    table.Add(new(first, second), data);
                }

                return data;
            }
        }

        public List<PositionData> GetPositions(int first, int secondFrom, int secondTo)
        {
            List<PositionData> result = new();

            for(int i = secondFrom; i <= secondTo; i++)
            {
                result.Add(this[first, i]);
            }

            return result;
        }

        public FileInfo ExportTable()
        {
            //https://habr.com/ru/post/525492/
            throw new NotImplementedException();
        }
    }
}
