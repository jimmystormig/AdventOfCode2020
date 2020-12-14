using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Day3
    {
        public static int DetectTrees(List<List<bool>> map, int stepsToTheRight, int stepsDown)
        {
            var x = 0;
            var treesFound = 0;
            for (var y = 0; y < map.Count; y++)
            {
                if(y % stepsDown == 1) continue;
                if(map[y][x]) treesFound++;
                x += stepsToTheRight;
            }

            return treesFound;
        }
    }
}