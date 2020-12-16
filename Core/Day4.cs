using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core
{
    public class Day4
    {
        private static readonly string[] _requiredKeys = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        public static int FindValidSimple(IEnumerable<Dictionary<string, string>> passports) =>
            passports.Count(p => _requiredKeys.All(p.ContainsKey));

        public static int FindValidAdvanced(IEnumerable<Dictionary<string, string>> passports) =>
            passports.Count(p =>
                {
                    if (!_requiredKeys.All(p.ContainsKey)) return false;

                    var byr = Convert.ToInt32(p["byr"]);
                    if (!(byr >= 1920 & byr <= 2002)) return false;
                    
                    var iyr = Convert.ToInt32(p["iyr"]);
                    if (!(iyr >= 2010 & iyr <= 2020)) return false;
                    
                    var eyr = Convert.ToInt32(p["eyr"]);
                    if (!(eyr >= 2020 & eyr <= 2030)) return false;
                    
                    var hgtMatch = Regex.Match(p["hgt"], @"^(\d+)(in|cm)$");
                    if(!(hgtMatch.Success && (hgtMatch.Groups[2].Value == "cm" &&
                                              Convert.ToInt32(hgtMatch.Groups[1].Value) >= 150 &&
                                              Convert.ToInt32(hgtMatch.Groups[1].Value) <= 193 ||
                                              hgtMatch.Groups[2].Value == "in" &&
                                              Convert.ToInt32(hgtMatch.Groups[1].Value) >= 59 &&
                                              Convert.ToInt32(hgtMatch.Groups[1].Value) <= 76))) return false;

                    var hclMatch = Regex.Match(p["hcl"], @"^#[0-9a-f]{6}$");
                    if (!hclMatch.Success) return false;

                    var validEyeColors = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                    if (!validEyeColors.Contains(p["ecl"])) return false;

                    var pidMatch = Regex.Match(p["pid"], @"^\d{9}$");
                    return pidMatch.Success;
                }
            );
    }
}