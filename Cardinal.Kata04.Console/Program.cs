using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Kata04.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var footballStats = GetMinSpreadFootball();
            var weatherStats = GetMinSpreadWeather();
            System.Console.WriteLine("Day with minimum spread is day {0} with a spread of {1}",
                                                                                weatherStats.Id,
                                                                                Math.Abs(weatherStats.Value1 - weatherStats.Value2));
            System.Console.WriteLine("Team with minimum spread is {0} with a spread of {1}",
                                                                                footballStats.Id,
                                                                                Math.Abs(footballStats.Value1 - footballStats.Value2));
            System.Console.ReadKey();
            
        }
        static Stats GetMinSpreadFootball()
        {
            var fileReader = new FileReader("football.dat",
                                        new Tuple<int, int>(7, 16),
                                        new Tuple<int, int>(43, 2),
                                        new Tuple<int, int>(50, 2),
                                        1,
                                        "-");
            var stats = fileReader.ReadStatsFromFile();
            return stats.OrderBy(x => Math.Abs(x.Value1 - x.Value2)).First();
            
        }
        static Stats GetMinSpreadWeather()
        {
            var fileReader = new FileReader("weather.dat",
                                        new Tuple<int, int>(0, 4),
                                        new Tuple<int, int>(6, 2),
                                        new Tuple<int, int>(12, 2),
                                        2,
                                        "m");
            var stats = fileReader.ReadStatsFromFile();
            return stats.OrderBy(x => Math.Abs(x.Value1 - x.Value2)).First();

        }

    }
}
