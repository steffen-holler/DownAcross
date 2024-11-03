namespace ConsoleAcross
{
    internal class CrosswordEntry
    {
        internal char Token { get; set; } = '\t';

        public static readonly CrosswordEntry Empty = new CrosswordEntry();

        public bool IsValidEntry
        { 
            get 
            {
                return Year > 1913 &&
                    !string.IsNullOrWhiteSpace(Publisher) &&
                    !string.IsNullOrWhiteSpace(Answer) &&
                    !string.IsNullOrWhiteSpace(Clue);
            }
        }

        public string Publisher { get; set; } = "";
        public int Year { get; set; } = 0;
        public string Answer { get; set; } = "";
        public string Clue { get; set; } = "";

        internal CrosswordEntry()
        { }

        public CrosswordEntry(char token, string publisher, int year, string answer, string clue)
        {
            this.Token = token;
            Publisher = publisher;
            Year = year;
            Answer = answer;
            Clue = clue;
        }

        public static CrosswordEntry Parse(string line, char token='\t')
        {
            var entry = new CrosswordEntry();
            var data = line.Split(token);
            //if (data.Length <= 0 ) 
            //    return entry;
            if (data.Length >= 1 ) 
                entry.Publisher = data[0];
            if (data.Length >= 2 && int.TryParse(data[1], out int year))
                entry.Year = year;
            if (data.Length >= 3)
                entry.Answer = data[2];
            if (data.Length >= 4)
                entry.Clue = data[3];
            for (int i = 4; i < data.Length; i++)
                entry.Clue += $"{token}{data[i]}";
            return entry;
        }

        public override string ToString()
        {
            return
                $"{Publisher}{Token}{Year:0000}{Token}" +
                $"{Answer}{Token}{Clue}";
        }
    }
}
