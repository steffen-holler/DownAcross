using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleAcross
{
    internal class FileClueData : IClueData
    {
        public List<CrosswordEntry> Entries { get; } = new List<CrosswordEntry>();
        
        public FileClueData(string file, char token)
        {
            if (!File.Exists(file)) 
                throw new FileNotFoundException();
            var lines = File.ReadAllLines(file);
            for(int i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Trim();
                var entry = CrosswordEntry.Parse(line);
                if (!string.IsNullOrWhiteSpace(entry.Answer))
                    Entries.Add(entry);
            }
        }

        public List<CrosswordEntry> GetByPublisher(string? publisher)
        {
            if (publisher == null)
                return new List<CrosswordEntry>();
            return Entries.FindAll(e => e.Publisher.ToUpper() == publisher.ToUpper());
        }

        public List<CrosswordEntry> GetByYear(int? year)
        {
            if (year == null)
                return new List<CrosswordEntry>();
            return Entries.FindAll(e => e.Year == year);    
        }

        public List<CrosswordEntry> GetByAnswer(string answer)
        {
            if (answer == null)
                return new List<CrosswordEntry>();
            return Entries.FindAll(e => e.Answer.ToUpper() == answer.ToUpper());
        }

        public List<CrosswordEntry> GetByClue(string clue)
        {
            if (clue == null)
                return new List<CrosswordEntry>();
            return Entries.FindAll(e => e.Clue.Equals(clue, 
                StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
