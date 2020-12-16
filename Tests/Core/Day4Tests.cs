using System.Collections.Generic;
using AdventOfCode2020.Utils;
using Core;
using Xunit;

namespace AdventOfCode2020.Core
{
    public class Day4Tests
    {
        [Fact]
        public void FindValid_WhenSuppliedWithList_ShouldReturnNumberOfValidBySimpleRulesPassports()
        {
            var input = FileLoader.ReadListFromFile<string>("4.txt");
            var passports = ParsePassports(input);

            var validPassports = Day4.FindValidSimple(passports);
            
            Assert.Equal(196, validPassports);
        }

        [Fact]
        public void FindValid_WhenSuppliedWithList_ShouldReturnNumberOfValidByAdvancedRulesPassports()
        {
            var input = FileLoader.ReadListFromFile<string>("4.txt");
            var passports = ParsePassports(input);

            var validPassports = Day4.FindValidAdvanced(passports);
            
            Assert.Equal(114, validPassports);
        }

        private static IList<Dictionary<string, string>> ParsePassports(IEnumerable<string> input)
        {
            IList<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
            var passport = new Dictionary<string, string>();
            passports.Add(passport);

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    passport = new Dictionary<string, string>();
                    passports.Add(passport);
                }

                var pairs = line.Split(' ');
                foreach (var pair in pairs)
                {
                    if (string.IsNullOrWhiteSpace(pair)) continue;
                    var tokens = pair.Split(':');
                    passport[tokens[0]] = tokens[1];
                }
            }

            return passports;
        }
    }
}