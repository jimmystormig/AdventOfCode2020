using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Utils;
using Core;
using Xunit;

namespace AdventOfCode2020.Core
{
    public class Day5Tests
    {
        [Fact]
        public void FindHighestSeatId_WhenSuppliedWithList_ShouldCalculateSeatId()
        {
            var input = FileLoader.ReadListFromFile<string>("5.txt");
            IEnumerable<(int Row, int Column)> rowsAndColumns = Day5.ConvertToRowAndColumn(input);

            var seatIds = Day5.CalculateSeatId(rowsAndColumns);

            Assert.Equal(974, seatIds.Max());
        }
        
        [Fact]
        public void FindMissingSeat_WhenSuppliedWithList_ShouldFindMissingSeat()
        {
            var input = FileLoader.ReadListFromFile<string>("5.txt");
            IEnumerable<(int Row, int Column)> rowsAndColumns = Day5.ConvertToRowAndColumn(input);
            var missingRowAndColumn = Day5.FindMissingSeat(rowsAndColumns);

            var missingSeatId = Day5.CalculateSeatId(new[] {missingRowAndColumn});

            Assert.Equal(646, missingSeatId.Single());
        }
    }
}