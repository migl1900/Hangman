using System;

namespace Hangman
{
    public class Program
    {
        // Method to display main menu and handling user input
        public void mainMenu()
        {

            while (true)
            {
                // Clear any previous renderings
                Console.Clear();

                // Custom text color
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine(@" _    _  _  _                      _____       _     _          ");
                Console.WriteLine(@"| |  | ||_||_|                    / ____|     | |   | |         ");
                Console.WriteLine(@"| |__| | __ _ _ __   __ _  __ _  | |  __ _   _| |__ | |__   ___ ");
                Console.WriteLine(@"|  __  |/ _` | '_ \ / _` |/ _` | | | |_ | | | | '_ \| '_ \ / _ \");
                Console.WriteLine(@"| |  | | (_| | | | | (_| | (_| | | |__| | |_| | |_) | |_) |  __/");
                Console.WriteLine(@"|_|  |_|\__,_|_| |_|\__, |\__,_|  \_____|\__,_|_.__/|_.__/ \___|");
                Console.WriteLine(@"                     _ / |                                      ");
                Console.WriteLine(@"                    |___/                                       ");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Välkommen till konsolspelet Hänga gubbe!");
                Console.WriteLine("Du kan välja mellan att spela eller att hantera orden som används i spelet!\n");

                // Menu choices
                Console.WriteLine("(1) Spela");
                Console.WriteLine("(2) Hantera ord\n");
                Console.WriteLine("(X) Avsluta\n");

                Console.Write("Menyval: ");

                // Get input from user and convert to lowercase
                string inp = Console.ReadLine().ToLower();

                // Handle input cases
                switch (inp)
                {
                    // Start instance of hangman game
                    case "1":
                        Hangman hangman = new Hangman();
                        String word = "";
                        hangman.playHangman(word);
                        break;

                    // Start instance of interface handling database words
                    case "2":
                        HandleWord handlWord = new HandleWord();
                        break;

                    // Exit program
                    case "x":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            // Load main menu
            Program newProgram = new Program();
            newProgram.mainMenu();
        }
    }
}
