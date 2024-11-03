using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAcross
{
    internal interface IClueData
    {
        public List<CrosswordEntry> GetByPublisher(string? publisher);
        public List<CrosswordEntry> GetByYear(int? year);
        public List<CrosswordEntry> GetByAnswer(string? answer);
        public List<CrosswordEntry> GetByClue(string? clue);
    }
}
