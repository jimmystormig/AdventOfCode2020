using System.Linq;
using AdventOfCode2020.Utils;
using Core;
using Xunit;

namespace AdventOfCode2020.Core
{
    public class Day3Tests
    {
        [Fact]
        public void DetectTrees_WhenProvidedWithMap_ShouldDetectNUmberOfTreesInPath()
        {
            var input = FileLoader.ReadListFromFile<string>("3.txt");
            var map = input
                .Select(line => string.Concat(Enumerable.Repeat(line, 50)))
                .Select(line => line.Select(token => token == '#').ToList())
                .ToList();

            var trees = Day3.DetectTrees(map, 3, 1);
            
            Assert.Equal(216, trees);
        }
        
        [Fact]
        public void DetectTrees_WhenProvidedWithMap_ShouldDetectAndMultiplyNUmberOfTreesInDifferentPaths()
        {
            var input = FileLoader.ReadListFromFile<string>("3.txt");
            var map = input
                .Select(line => string.Concat(Enumerable.Repeat(line, 100)))
                .Select(line => line.Select(token => token == '#').ToList())
                .ToList();

            var treesInPath1 = Day3.DetectTrees(map, 1, 1);
            var treesInPath2 = Day3.DetectTrees(map, 3, 1);
            var treesInPath3 = Day3.DetectTrees(map, 5, 1);
            var treesInPath4 = Day3.DetectTrees(map, 7, 1);
            var treesInPath5 = Day3.DetectTrees(map, 1, 2);

            var product = (long)treesInPath1 * treesInPath2 * treesInPath3 * treesInPath4 * treesInPath5;
            
            Assert.Equal(6708199680, product);
        }
    }
}