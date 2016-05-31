using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Cardinal.Kata04.Test
{
    [TestClass]
    public class WeatherFileReaderTests
    {
        string _line = "   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5";
        static IEnumerable<string> _testInputFile;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _testInputFile = File.ReadAllLines("weather.dat");
        }
        [TestMethod]
        public void CanReadFile()
        {
            //arrange
            var sut = new WeatherFileReader();
            //act
            var lines = sut.ReadWeatherStatsFromFile("weather.dat");
            //assert
            Assert.AreEqual(30, lines.Count);
        }
        [TestMethod]
        public void CanReadDayNumber()
        {
            //arrange
            var sut = new WeatherFileReader();
            //act
            var result = sut.ProcessLine(_line);
            //assert
            Assert.AreEqual(1, result.Day);
        }
        [TestMethod]
        public void CanReadMxT()
        {
            //arrange
            var sut = new WeatherFileReader();
            //act
            var result = sut.ProcessLine(_line);
            //assert
            Assert.AreEqual(88, result.Max);
        }
        [TestMethod]
        public void CanReadMnT()
        {
            //arrange
            var sut = new WeatherFileReader();
            //act
            var result = sut.ProcessLine(_line);
            //assert
            Assert.AreEqual(59, result.Min);
        }

        [TestMethod]
        public void CanDetermineMinSpread()
        {
            //arrange
            var sut = new WeatherFileReader();
            //act
            var stats = sut.ReadWeatherStatsFromFile("weather.dat");
            //assert
            var minSpread = stats.OrderBy(x => x.Max - x.Min).First();
            Assert.AreEqual(2, minSpread);

        }
        
    }
}
