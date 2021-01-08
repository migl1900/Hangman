using System;

// Namespace handling lists
using System.Collections.Generic;

// Namespace to enable StringBuilder
using System.Text;

// Enables validation of string values
using System.Text.RegularExpressions;

namespace Hangman
{
    class Hangman
    {
        // Variables for storing game word
        private String hangmanWord;
        private String hangmanWordLowercase;

        // Method to display current correct guesses and remaining letters as stars
        public void showWordStatus(StringBuilder letters)
        {
            Console.WriteLine();
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == '*')
                {
                    Console.Write(letters[i]);
                }
                else
                {
                    // Change color of correct letters to green
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(letters[i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            }
            Console.WriteLine("\n");
        }

        // Method to display menu at end of game
        public void endMenu()
        {
            while (true)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("(1) Spela igen");
                Console.WriteLine("(2) Till huvudmeny\n");

                Console.Write("Menyval: ");

                // Get input from user and convert to lowercase
                string inp = Console.ReadLine().ToLower();

                // Handle input cases
                switch (inp)
                {
                    case "1":
                        Hangman hangman = new Hangman();
                        hangman.playHangman(hangmanWord);
                        break;

                    case "2":
                        Program newProgram = new Program();
                        newProgram.mainMenu();
                        break;
                }
            }
        }

        // Play hangman game Method
        public void playHangman(String lastWord)
        {
            Console.Clear();

            //Create object and get random word
            RandomWord randWord = new RandomWord();
            hangmanWord = randWord.getRandomWord();

            // Check if last used word is same as new word otherwise get new word
            while (lastWord == hangmanWord)
            {
                hangmanWord = randWord.getRandomWord();
            }

            // Convert letters to lower case
            hangmanWordLowercase = hangmanWord.ToLower();

            // Create a string with same numbers of stars instead of characters as game word
            StringBuilder letters = new StringBuilder(hangmanWord.Length);
            for (int i = 0; i < hangmanWord.Length; i++)
            {
                letters.Append('*');
            }

            // Prepare lists to store right and wrong guesses
            List<Char> right = new List<Char>();
            List<Char> wrong = new List<Char>();

            // Number of wrong guesses allowed
            int lives = 5;

            // Variable to check if game won
            bool won = false;

            // Variable to keep count of right guesses
            int correctLetters = 0;

            // Variable to get user input
            String input;

            // Variable to store converted user input from string to char
            Char guess;

            // Display initial message
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-- SPELA HÄNGA GUBBE! --\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Du ska nu försöka gissa ett ord på {hangmanWord.Length} bokstäver.\n");

            // Display initial stars instead of word
            Console.WriteLine(letters);
            Console.WriteLine();

            // Start game loop
            while (!won && lives > 0)
            {
                // Get user input
                Console.Write("Gissa en bokstav: ");
                input = Console.ReadLine().ToLower();

                // Check that input is more than 1 character and only span from a-ö
                if (input.Length > 1)
                {
                    Console.WriteLine("\nAnge endast en bokstav i taget, försök igen! ");
                    showWordStatus(letters);
                    continue;
                }
                else if (!Regex.IsMatch(input, @"^[a-öA-Ö]+$"))
                {
                    Console.WriteLine("\nDet måste vara en bokstav från A till Ö, försök igen! ");
                    showWordStatus(letters);
                    continue;
                }

                guess = input[0];

                // Check if user input already exist either as right or wrong guess
                if (right.Contains(guess))
                {
                    Console.WriteLine($"\nDu har redan testat {guess} och det var rätt bokstav, försök igen!");
                    showWordStatus(letters);
                    continue;
                }
                else if (wrong.Contains(guess))
                {
                    Console.WriteLine($"\nDu har redan testat {guess} och det var fel bokstav, försök igen!");
                    showWordStatus(letters);
                    continue;
                }

                // Check if user input is correct
                if (hangmanWordLowercase.Contains(guess))
                {
                    // Add user input to list of right answers
                    right.Add(guess);

                    for (int i = 0; i < hangmanWord.Length; i++)
                    {
                        // Check if current letters is equal to user input (both in lower case)
                        if (hangmanWordLowercase[i] == guess)
                        {
                            // Replaces any occurrence of stars with corresponding letter from game word
                            letters[i] = hangmanWord[i];

                            // Add number of right guesses
                            correctLetters++;
                        }
                    }

                    // Check if all letters have been found
                    if (correctLetters == hangmanWord.Length)
                        won = true;
                }

                // If user input is incorrect
                else
                {
                    // Add user input to list of wrong answers
                    wrong.Add(guess);

                    // display wrong letter in red color
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\n{input[0]}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($" finns inte i ordet, försök igen!");

                    // Deduct 1 from number of lives
                    lives--;

                    // Display corresponding image of a hanged man i correlation to number of lives
                    if (lives == 4)
                    {
                        Console.WriteLine(@" ______________");
                        Console.WriteLine(@" |/         |  ");
                        Console.WriteLine(@" |        (¤_¤)");
                        Console.WriteLine(@" |             ");
                        Console.WriteLine(@" |             ");
                        Console.WriteLine(@" |             ");
                        Console.WriteLine(@" |             ");
                        Console.WriteLine(@" |_______      ");

                    }
                    if (lives == 3)
                    {
                        Console.WriteLine(@" ______________");
                        Console.WriteLine(@" |/         |  ");
                        Console.WriteLine(@" |        (¤_¤)");
                        Console.WriteLine(@" |     _____|  ");
                        Console.WriteLine(@" |             ");
                        Console.WriteLine(@" |             ");
                        Console.WriteLine(@" |             ");
                        Console.WriteLine(@" |_______      ");

                    }
                    if (lives == 2)
                    {
                        Console.WriteLine(@" ______________  ");
                        Console.WriteLine(@" |/         |    ");
                        Console.WriteLine(@" |        (¤_¤)  ");
                        Console.WriteLine(@" |     _____|____");
                        Console.WriteLine(@" |               ");
                        Console.WriteLine(@" |               ");
                        Console.WriteLine(@" |               ");
                        Console.WriteLine(@" |_______        ");

                    }
                    if (lives == 1)
                    {
                        Console.WriteLine(@" ______________  ");
                        Console.WriteLine(@" |/         |    ");
                        Console.WriteLine(@" |        (¤_¤)  ");
                        Console.WriteLine(@" |     _____|____");
                        Console.WriteLine(@" |          |    ");
                        Console.WriteLine(@" |         /     ");
                        Console.WriteLine(@" |        /      ");
                        Console.WriteLine(@" |_______        ");

                    }
                }

                // Display current status of letters and stars
                showWordStatus(letters);
            }

            // Display congratulations i green
            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Grattis du klarade ordet!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            // Display game over text and end image
            else
            {
                Console.Write($"Tyvärr har du inga fler gissningar, rätt ord var ");

                // Display correct word in yellow
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(hangmanWord);
                Console.ForegroundColor = ConsoleColor.Gray;
                {
                    Console.WriteLine(@" ______________  ");
                    Console.WriteLine(@" |/         |    ");
                    Console.WriteLine(@" |        (¤_¤)  ");
                    Console.WriteLine(@" |     _____|____");
                    Console.WriteLine(@" |          |    ");
                    Console.WriteLine(@" |         / \   ");
                    Console.WriteLine(@" |        /   \  ");
                    Console.WriteLine(@" |_______        ");
                    Console.WriteLine();

                }
            }

            // Display menu to try again or go back to main menu
            endMenu();
        }
    }
}
