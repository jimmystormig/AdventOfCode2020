using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Day5
    {
        private const int rows = 128;
        private const int columns = 8;
        
        public static IEnumerable<(int Row, int Column)> ConvertToRowAndColumn(IEnumerable<string> partitions)
        {
            foreach (var partition in partitions)
            {
                var tokens = partition.ToCharArray();
                var rowTokens = tokens.Take(7);
                var columnTokens = tokens.Skip(7);

                var rowSequence = Enumerable.Range(0, rows).ToList();
                foreach (var rowToken in rowTokens)
                {
                    rowSequence = rowToken switch
                    {
                        'F' => rowSequence.Take(rowSequence.Count / 2).ToList(),
                        'B' => rowSequence.Skip(rowSequence.Count / 2).ToList(),
                        _ => throw new ArgumentOutOfRangeException(nameof(rowToken), rowToken, "Illegal character")
                    };
                }

                var columnSequence = Enumerable.Range(0, columns).ToList();
                foreach (var columnToken in columnTokens)
                {
                    columnSequence = columnToken switch
                    {
                        'L' => columnSequence.Take(columnSequence.Count / 2).ToList(),
                        'R' => columnSequence.Skip(columnSequence.Count / 2).ToList(),
                        _ => throw new ArgumentOutOfRangeException(nameof(columnToken), columnToken, "Illegal character")
                    };
                }

                yield return (rowSequence.Single(), columnSequence.Single());
            }
        }

        public static IEnumerable<int> CalculateSeatId(IEnumerable<(int Row, int Column)> rowsAndColumns) =>
            rowsAndColumns.Select(x => x.Row * 8 + x.Column);

        public static (int Row, int Column) FindMissingSeat(IEnumerable<(int Row, int Column)> rowsAndColumns)
        {
            var veryFirstOrEndRowDivider = 12;
            
            var allPossibleFiltered = GetAllPossibleRowsAndColumns().ToList().Where(x => x.Row > veryFirstOrEndRowDivider && x.Row < rows - veryFirstOrEndRowDivider);
            var filtered = rowsAndColumns.ToList().Where(x => x.Row > veryFirstOrEndRowDivider && x.Row < rows - veryFirstOrEndRowDivider);
            var missing = allPossibleFiltered.Except(filtered);
            
            return missing.Single();
        }

        private static IEnumerable<(int Row, int Column)> GetAllPossibleRowsAndColumns()
        {
            for (var y = 0; y < rows; y++)
            for (var x = 0; x < columns; x++)
                yield return (y, x);
        }
    }
}