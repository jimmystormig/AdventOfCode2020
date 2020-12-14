using System;
using System.Linq;
using AdventOfCode2020.Utils;
using Core;
using Xunit;

namespace AdventOfCode2020.Core
{
    public class Day2Tests
    {
        [Fact]
        public void FindValidPasswords_WhenProvidedList_ShouldFindPasswordsThatSatisfiesOldPolicy()
        {
            var validPasswords = FileLoader
                .ReadListFromFile<string>("2.txt")
                .Select(x =>
                {
                    var tokens = x.Split(" ");
                    var password = tokens[2];
                    var range = tokens[0].Split('-');
                    var letter = tokens[1].Substring(0, 1);
                    var policy = new Day2.OldPolicy((Convert.ToInt32((string?) range[0]), Convert.ToInt32((string?) range[1])), letter.ToCharArray()[0]);
                    return new Day2(password, policy);
                })
                .Count(x => x.SatisfiesPolicy());

            Assert.Equal(517, validPasswords);
        }
        
        [Fact]
        public void FindValidPasswords_WhenProvidedList_ShouldFindPasswordsThatSatisfiesNewPolicy()
        {
            var validPasswords = FileLoader
                .ReadListFromFile<string>("2.txt")
                .Select(x =>
                {
                    var tokens = x.Split(" ");
                    var password = tokens[2];
                    var range = tokens[0].Split('-');
                    var letter = tokens[1].Substring(0, 1);
                    var policy = new Day2.NewPolicy((Convert.ToInt32((string?) range[0]), Convert.ToInt32((string?) range[1])), letter.ToCharArray()[0]);
                    return new Day2(password, policy);
                })
                .Count(x => x.SatisfiesPolicy());

            Assert.Equal(284, validPasswords);
        }
    }
}