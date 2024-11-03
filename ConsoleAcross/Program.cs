using System;
using System.Collections.Generic;

namespace ConsoleAcross
{
    class Program
    {
        static void Main(string[] args)
        {
            IClueData data;
            try
            {
                data = new FileClueData("clues.tsv", '\t');
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, ConsoleColor.Red);
                return;
            }
            string option = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome To ConsoleAccoss");
                Console.WriteLine($"Clues loaded {((FileClueData)data).Entries.Count}");
                Console.WriteLine();
                Console.WriteLine("Please Select an option"); 
                Console.WriteLine("P: Find a entry by Publisher");
                Console.WriteLine("Y: Find a entry by year");
                Console.WriteLine("A: Find a entry by Answer");
                Console.WriteLine("C: Find a entry by Clue");
                Console.WriteLine();
                Console.WriteLine("X: to exit");
                option = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(option))
                    continue;
                string? search = "";
                List<CrosswordEntry> results = new List<CrosswordEntry>();
                switch (option?.ToLower()[0])
                {
                    case 'p':
                        Console.WriteLine("Enter Publisher ID:");
                        search = Console.ReadLine();
                        results = data.GetByPublisher(search);
                        break;

                    case 'y':
                        Console.WriteLine("Enter Year:");
                        search = Console.ReadLine();
                        {
                            int year = 0;
                            int.TryParse(search, out year);
                            results = data.GetByYear(year);
                        }
                        break;

                    case 'a':
                        Console.WriteLine("Enter Answer:");
                        search = Console.ReadLine();
                        results = data.GetByAnswer(search); 
                        break;

                    case 'c':
                        Console.WriteLine("Enter Clue:");
                        search = Console.ReadLine();
                        results = data.GetByAnswer(search);
                        break;
                    default:
                        Console.WriteLine($"{option} is an invalid.");
                        break;
                }
                PrintAllEntries(results);

            } while (option is null || !option.StartsWith("x", StringComparison.OrdinalIgnoreCase));
        }

        private static void PrintAllEntries(List<CrosswordEntry> entries)
        {
            if (entries.Count == 0)
            {
                Console.WriteLine(
                    "No Entires found. \r\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("PubID\tYEAR\tANSWER\t\t\tCLUE");
            foreach (CrosswordEntry entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}