using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Kata04
{
    public class FootballFileReader
    {
        public List<FootballStats> ReadFootballStatsFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            return ProcessFootballStats(lines.Skip(1).Where(x => !x.TrimStart().StartsWith("-"))); //skip first line and lines starting with "-"
        }

        public List<FootballStats> ProcessFootballStats(IEnumerable<string> lines)
        {
            var ret = new List<FootballStats>();
            foreach (var line in lines)
            {
                ret.Add(ProcessLine(line));
            }

            return ret;
        }
        public FootballStats ProcessLine(string line)
        {
            var stats = new FootballStats();
            stats.TeamName = line.Substring(7, 16).Trim();
            string forString = line.Substring(43, 2);
            string againstString = line.Substring(50, 2);
            stats.For = int.Parse(forString);
            stats.Against = int.Parse(againstString);
            return stats;
        }

    }
}
