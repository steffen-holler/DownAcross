using ConsoleAcross;

namespace DownAcross.Test
{
    [TestClass]
    public class TestCrosswordEntry
    {
        [DataTestMethod]
        [DataRow("", "", 0, "", "", ',', false)]
        [DataRow("", "", 0, "", "", '\t', false)]
        [DataRow("nyc", "nyc", 0, "", "", ',', false)]
        [DataRow("nyc", "nyc", 0, "", "", '\t', false)]
        [DataRow("nyc,2001", "nyc", 2001, "", "", ',', false)]
        [DataRow("nyc\t2001", "nyc", 2001, "", "", '\t', false)]
        [DataRow("nyc,2001,STAIRS", "nyc", 2001, "STAIRS", "", ',', false)]
        [DataRow("nyc\t2001\tSTAIRS", "nyc", 2001, "STAIRS", "", '\t', false)]
        [DataRow("nyc,2001,STAIRS,Things to move up and down", "nyc", 2001, "STAIRS", "Things to move up and down", ',', true)]
        [DataRow("nyc\t2001\tSTAIRS\tThings to move up and down", "nyc", 2001, "STAIRS", "Things to move up and down", '\t', true)]
        [DataRow("nyc\t2001\tSTAIRS\tThings to move up, and down", "nyc", 2001, "STAIRS", "Things to move up, and down", '\t', true)]
        [DataRow(",2001,STAIRS,Things to move up and down", "", 2001, "STAIRS", "Things to move up and down", ',', false)]
        [DataRow("nyc2001,,STAIRS,Things to move up and down", "nyc2001", 0, "STAIRS", "Things to move up and down", ',', false)]
        [DataRow(",nyc2001,STAIRS,Things to move up and down", "", 0, "STAIRS", "Things to move up and down", ',', false)]
        public void TestParse(string input, string pub, int year, string answer, string clue, char token, bool valid)
        {
            var entry = CrosswordEntry.Parse(input, token);

            Assert.AreEqual(pub, entry.Publisher, $"{pub} != {entry.Publisher}");
            Assert.AreEqual(year, entry.Year, $"{year} != {entry.Year}");
            Assert.AreEqual(answer, entry.Answer, $"{answer} != {entry.Answer}");
            Assert.AreEqual(clue, entry.Clue, $"{clue} != {entry.Clue}");
            Assert.AreEqual(valid, entry.IsValidEntry, $"{valid} != {entry.IsValidEntry}");
        }

        [DataTestMethod]
        [DataRow(",0000,,", "", 0, "", "", ',')]
        [DataRow("\t0000\t\t", "", 0, "", "", '\t')]
        [DataRow("nyc,0000,,", "nyc", 0, "", "", ',')]
        [DataRow("nyc\t0000\t\t", "nyc", 0, "", "", '\t')]
        [DataRow("nyc,2001,,", "nyc", 2001, "", "", ',')]
        [DataRow("nyc\t2001\t\t", "nyc", 2001, "", "", '\t')]
        [DataRow("nyc,2001,STAIRS,", "nyc", 2001, "STAIRS", "", ',')]
        [DataRow("nyc\t2001\tSTAIRS\t", "nyc", 2001, "STAIRS", "", '\t')]
        [DataRow("nyc,2001,STAIRS,Things to move up and down", "nyc", 2001, "STAIRS", "Things to move up and down", ',')]
        [DataRow("nyc\t2001\tSTAIRS\tThings to move up and down", "nyc", 2001, "STAIRS", "Things to move up and down", '\t')]
        [DataRow("nyc\t2001\tSTAIRS\tThings to move up, and down", "nyc", 2001, "STAIRS", "Things to move up, and down", '\t')]
        public void TestToString(string expected, string pub, int year, string answer, string clue, char token)
        {
            var entry = new CrosswordEntry()
            {
                Publisher = pub,
                Year = year,
                Answer = answer,
                Clue = clue,
                Token = token
            };
            string actual = entry.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}