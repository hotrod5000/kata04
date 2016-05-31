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
            var reader = new WeatherFileReader();
            var stats = reader.ReadWeatherStatsFromFile("weather.dat");
            var minSpread = stats.OrderBy(x => x.Max - x.Min).First();
            System.Console.WriteLine("Day with minimum spread is day {0} with a spread of {1}",
                                                                                minSpread.Day,
                                                                                minSpread.Max - minSpread.Min);
            var minSpreadFootballTeam = GetMinSpreadFootball();
            System.Console.WriteLine("Team with minimum spread is {0} with a spread of {1}",
                                                                                minSpreadFootballTeam.TeamName,
                                                                                Math.Abs(minSpreadFootballTeam.Against - minSpreadFootballTeam.For));
            System.Console.ReadKey();
            
        }
        static FootballStats GetMinSpreadFootball()
        {
            var reader = new FootballFileReader();
            var stats = reader.ReadFootballStatsFromFile("football.dat");
            return stats.OrderBy(x => Math.Abs(x.For - x.Against)).First();
            
        }
    }
}
