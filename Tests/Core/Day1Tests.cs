using System.Linq;
using AdventOfCode2020.Utils;
using Core;
using Xunit;

namespace AdventOfCode2020.Core
{
    public class Day1Tests
    {
        [Fact]
        public void FindPair_WhenFindingPairByAddUpValue_ShouldFindTheCorrectPair()
        {
            var values = FileLoader.ReadListFromFile<int>("1.txt");
            var sut = new Day1();

            var pairAddingUpTo2020 = Day1.Find(values, 2, 2020).ToList();

            Assert.Equal(2, pairAddingUpTo2020.Count);
            Assert.Equal(2020, pairAddingUpTo2020.Sum());
            Assert.Equal(864864, Day1.Calculate(pairAddingUpTo2020));
        }
        
        [Fact]
        public void FindTriplet_WhenFindingPairByAddUpValue_ShouldFindTheCorrectTriplet()
        {
            var values = FileLoader.ReadListFromFile<int>("1.txt");
            var sut = new Day1();

            var tripletAddingUpTo2020 = Day1.Find(values, 3, 2020).ToList();

            Assert.Equal(3, tripletAddingUpTo2020.Count);
            Assert.Equal(2020, tripletAddingUpTo2020.Sum());
            Assert.Equal(281473080, Day1.Calculate(tripletAddingUpTo2020));
        }
    }
}