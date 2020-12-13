using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Day1
    {
        public static IEnumerable<int> Find(IEnumerable<int> values, int howManyValuesToAdd, int shouldAddUpTo)
        {
            return FindRecursive(values.ToList(), new List<int>(), shouldAddUpTo, howManyValuesToAdd, 1);
        }

        private static IList<int> FindRecursive(ICollection<int> values, IList<int> foundValues, int shouldAddUpTo, int numbersToAdd, int level)
        {
            foreach (var value in values)
            {
                if (level == 1) foundValues = new List<int>();

                foundValues.Add(value);
                
                if (level == numbersToAdd)
                {
                    if (foundValues.Sum() == shouldAddUpTo) return foundValues;

                    foundValues.Remove(value);
                }

                if (level >= numbersToAdd) continue;
                
                var foundFromLowerLevels = FindRecursive(values, foundValues, shouldAddUpTo, numbersToAdd, level + 1);
                if (foundFromLowerLevels.Any()) return foundFromLowerLevels;

                foundValues.Remove(value);
            }
            
            return new List<int>();
        }

        public static int Calculate(IEnumerable<int> input)
        {
            return input.Aggregate((v1, v2) => v1 * v2);
        }
    }
}