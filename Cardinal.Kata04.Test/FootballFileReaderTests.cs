using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Kata04.Test
{
    [TestClass]
    public class FootballFileReaderTests
    {
        readonly string _line = "    1. Arsenal         38    26   9   3    79  -  36    87";
        [TestMethod]
        public void CanReadFile()
        {
            //arrange
            var sut = new FootballFileReader();
            //act
            var lines = sut.ReadFootballStatsFromFile("football.dat");
            //assert
            Assert.AreEqual(20, lines.Count);
        }
        [TestMethod]
        public void CanReadTeamName()
        {
            //arrange
            var sut = new FootballFileReader();
            //act
            var result = sut.ProcessLine(_line);
            //assert
            Assert.AreEqual("Arsenal", result.TeamName);
        }
        [TestMethod]
        public void CanReadForValue()
        {
            //arrange
            var sut = new FootballFileReader();
            //act
            var result = sut.ProcessLine(_line);
            //assert
            Assert.AreEqual(79, result.For);
        }
        [TestMethod]
        public void CanReadAgainstValue()
        {
            //arrange
            var sut = new FootballFileReader();
            //act
            var result = sut.ProcessLine(_line);
            //assert
            Assert.AreEqual(36, result.Against);
        }
    }
}
