using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Kata04
{
    public class WeatherFileReader
    {
        public List<WeatherStats> ReadWeatherStatsFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            return ProcessWeatherStats(lines.Skip(2).Where(x => !x.TrimStart().StartsWith("m"))); //skip first 2 lines and last summary line
        }

        public List<WeatherStats> ProcessWeatherStats(IEnumerable<string> lines)
        {
            var ret = new List<WeatherStats>();
            foreach(var line in lines)
            {
                

                ret.Add(ProcessLine(line));

            }

            return ret;
        }
        public WeatherStats ProcessLine(string line)
        {
            var dayStats = new WeatherStats();
            string dayString = line.Substring(0, 4);
            string maxString = line.Substring(6, 2);
            string minString = line.Substring(12, 2);
            dayStats.Day = int.Parse(dayString);
            dayStats.Min = int.Parse(minString);
            dayStats.Max = int.Parse(maxString);
            return dayStats;
        }
        

    }
}
