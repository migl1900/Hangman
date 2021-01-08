// NuGet package enabling table-like printout in console
using ConsoleTables;
using System;

// Enables queries of data from different sources and formats as objects
using System.Linq;

// Enables validation of string values
using System.Text.RegularExpressions;

namespace Hangman
{
    class HandleWord
    {
        public HandleWord()
        {
            while (true)
            {
                // Clear any previous renderings
                Console.Clear();
                Console.WriteLine("Ansluter till MySQL...\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-- HANTERA ORD I SPELET --\n"); ;
                Console.ForegroundColor = ConsoleColor.Gray;

                // Show menu options
                Console.WriteLine("(1) Lägg till ord");
                Console.WriteLine("(2) Radera ord\n");
                Console.WriteLine("(X) Tillbaka till huvudmenyn\n");

                // Create instance of DbList
                DbList listOfWords = new DbList();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-- BEFINTLIGA ORD I SPELET --\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                // Create instance of ConsoleTable and populate with the ids and words from MySQL
                var table = new ConsoleTable("Id", "Ord");
                foreach (DbWord word in listOfWords.getListOfWords())
                {
                    table.AddRow(word.Id, word.Word);
                }
                table.Write(Format.Minimal);

                Console.Write("Menyval: ");

                // Get input from user and convert to lowercase
                string inp = Console.ReadLine().ToLower();

                // Handle input cases
                switch (inp)
                {
                    // Add a new word to MySQL
                    case "1":

                        // Create instance of DbWord
                        DbWord word = new DbWord();
                        Console.CursorVisible = true;

                        // Get new word from user
                        Console.Write("Ord att lägga till: ");
                        word.Word = Console.ReadLine();

                        // Check that input is set and matches letters from A-Ö
                        while (word.Word == "" || !Regex.IsMatch(word.Word, @"^[a-öA-Ö]+$"))
                        {
                            Console.Write("Fyll i ett ord med bokstäver från A till Ö: ");
                            word.Word = Console.ReadLine();
                        }

                        // Call addWord method from DbList class and add new word to MySQL
                        listOfWords.addWord(word);
                        break;

                    // Delete a word from MySQL
                    case "2":
                        Console.CursorVisible = true;

                        // Get id to delete from user
                        Console.Write("Välj id på ord som ska raderas: ");
                        String index = Console.ReadLine();
                        int inputTest = 0;

                        // Check if input is set and that it´s a numeric value within the set index scope
                        while (!int.TryParse(index, out inputTest) || !listOfWords.getListOfWords().Any(id => id.Id == inputTest))
                        {
                            Console.Write($"Du måste ange ett id-nummer ur listan: ");
                            index = Console.ReadLine();
                        }
                        listOfWords.deleteWord(Convert.ToInt32(index));
                        break;

                    // Exit menu
                    case "x":

                        // Create instance of Program and load main menu
                        Program newProgram = new Program();
                        newProgram.mainMenu();
                        break;
                }
            }
        }
    }
}
