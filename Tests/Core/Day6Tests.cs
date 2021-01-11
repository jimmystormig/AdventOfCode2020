using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Utils;
using Core;
using Xunit;

namespace AdventOfCode2020.Core
{
    public class Day6Tests
    {
        [Fact]
        public void SummarizeUniqueAnswersPerGroup_WithAllGroups_ShouldSummarizeCorrect()
        {
            var input = FileLoader.ReadListFromFile<string>("6.txt");
            var groups = ParseGroups(input);

            var qty = Day6.SummarizeUniqueAnswersPerGroup(groups);
            
            Assert.Equal(6885, qty);
        }
        
        [Fact]
        public void SummarizeAnsweredByAllInGroup_WithAllGroups_ShouldSummarizeCorrect()
        {
            var input = FileLoader.ReadListFromFile<string>("6.txt");
            var groups = ParseGroups(input);

            var qty = Day6.SummarizeAnsweredByAllInGroup(groups);

            Assert.Equal(3550, qty);
        }

        private static List<List<List<char>>> ParseGroups(IEnumerable<string> input)
        {
            var groups = new List<List<List<char>>>();
            var group = new List<List<char>>();
            groups.Add(@group);

            foreach (var row in input)
            {
                if (string.IsNullOrEmpty(row))
                {
                    @group = new List<List<char>>();
                    groups.Add(@group);
                    continue;
                }

                @group.Add(row.ToCharArray().ToList());
            }

            return groups;
        }
    }
}