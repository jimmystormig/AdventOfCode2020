using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public static class Day6
    {
        public static int SummarizeUniqueAnswersPerGroup(IEnumerable<List<List<char>>> groups) =>
            groups.Sum(group => group.SelectMany(x => x).Distinct().Count());

        public static int SummarizeAnsweredByAllInGroup(List<List<List<char>>> groups)
        {
            var sum = 0;
            foreach (var group in groups)
            {
                var persons = group.Count;
                var groupAnswers = group.SelectMany(x => x).GroupBy(x => x);
                sum += groupAnswers.Count(x => x.Count() == persons);
            }

            return sum;
        }
    }
}