using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Kata04
{
    public class FileReader
    {
        Tuple<int, int> _idColumn, _val1Column, _val2Column;
        string _filePath;
        int _numberOfLinesToSkip;
        string _ignoreMarker;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath">path to file to read</param>
        /// <param name="idColumnStartAndLength">Pair to identify column number and length of string for Id value</param>
        /// <param name="val1ColumnStartAndLength">Pair to identify column number and length of string for Value1</param>
        /// <param name="val2ColumnStartAndLength">Pair to identify column number and length of string for Value2</param>
        /// <param name="numberOfLinesToSkip">Number of lines to ignore at top of file</param>
        /// <param name="ignoreMarker">any lines in the file that start with this string will be ignored</param>
        public FileReader(string filePath,
                            Tuple<int,int> idColumnStartAndLength,
                            Tuple<int,int> val1ColumnStartAndLength,
                            Tuple<int,int> val2ColumnStartAndLength,
                            int numberOfLinesToSkip,
                            string ignoreMarker)
        {
            _filePath = filePath;
            _idColumn = idColumnStartAndLength;
            _val1Column = val1ColumnStartAndLength;
            _val2Column = val2ColumnStartAndLength;
            _numberOfLinesToSkip = numberOfLinesToSkip;
            _ignoreMarker = ignoreMarker;
        }
        public List<Stats> ReadStatsFromFile()
        {
            var lines = File.ReadAllLines(_filePath);

            return ProcessStats(lines.Skip(_numberOfLinesToSkip).Where(x => !x.TrimStart().StartsWith(_ignoreMarker))); 
        }

        private List<Stats> ProcessStats(IEnumerable<string> lines)
        {
            var ret = new List<Stats>();
            foreach (var line in lines)
            {   
                ret.Add(ProcessLine(line));
            }

            return ret;
        }
        public Stats ProcessLine(string line)
        {
            var stats = new Stats();
            stats.Id = line.Substring(_idColumn.Item1, _idColumn.Item2).Trim();
            string val1String = line.Substring(_val1Column.Item1, _val1Column.Item2);
            string val2String = line.Substring(_val2Column.Item1, _val2Column.Item2);
            stats.Value1 = int.Parse(val1String);
            stats.Value2 = int.Parse(val2String);
            return stats;
        }

    }
}
