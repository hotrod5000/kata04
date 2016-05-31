using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Kata04.Test
{
    [TestClass]
    public class FileReaderTests
    {
        static FileReader _footballFileReader;
        static FileReader _weatherFileReader;

        [ClassInitialize]
        public static void TestClassInit(TestContext context)
        {
            _footballFileReader = new FileReader("football.dat",
                                        new Tuple<int, int>(7, 16),
                                        new Tuple<int, int>(43, 2),
                                        new Tuple<int, int>(50, 2),
                                        1,
                                        "-");
            _weatherFileReader = new FileReader("weather.dat",
                                        new Tuple<int, int>(0, 4),
                                        new Tuple<int, int>(6, 2),
                                        new Tuple<int, int>(12, 2),
                                        2,
                                        "m");
        }
        [TestMethod]
        public void CanReadFootballFile()
        {
            //act
            var lines = _footballFileReader.ReadStatsFromFile();
            //assert
            Assert.AreEqual(20, lines.Count);
        }

        [TestMethod]
        public void CanReadWeatherFile()
        {
            //act
            var lines = _weatherFileReader.ReadStatsFromFile();
            //assert
            Assert.AreEqual(30, lines.Count);
        }

    }
}
