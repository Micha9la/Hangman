using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char UNDERSCORE = '_';
            const int MAX_FALSE_GUESS_COUNT = 3;

            Console.WriteLine("Hello to the game HANGMAN :)");
            Console.WriteLine("The word you are guessing is a name for a traditional austrian dish.");
            Console.WriteLine("Type in letters and see if the word contains them.");
            Console.WriteLine("Enjoy!");

            List<string> wordList = new List<string>();
            wordList.Add("Nudelsuppe");
            wordList.Add("Kaiserschmarren");
            wordList.Add("Schweinebraten");
            wordList.Add("Krautfleckerl");
            wordList.Add("Apfelstrudel");

            Random random = new Random();

            int index = random.Next(wordList.Count);

            string randomWord = wordList[index];

            //test to see what the word is
            //Console.WriteLine("The chosen word is " + randomWord);

            int falseGuessCount = 0;

            string gameState = new string(UNDERSCORE, randomWord.Length);
            char[] gameStateChars = gameState.ToCharArray();
            List<char> allUserGuesses = new List<char>();


            while (gameState.Contains(UNDERSCORE) && falseGuessCount < MAX_FALSE_GUESS_COUNT)
            {
                bool correctGuessCount = false;
                Console.WriteLine("Guess a letter:");
                char guessedLetter = Console.ReadKey().KeyChar;
                
                if (allUserGuesses.Contains(guessedLetter))
                {
                    Console.WriteLine(" You already guessed that letter. Try another one");
                }
                else
                {
                    allUserGuesses.Add(guessedLetter);
                }

                for (int i = 0; i < randomWord.Length; i++)
                {
                    if (char.ToLower(randomWord[i]) == char.ToLower(guessedLetter))
                    {
                        gameStateChars[i] = guessedLetter;
                        correctGuessCount = true;
                    }
                    
                }
                if (correctGuessCount == false)
                {
                    falseGuessCount++;
                    Console.WriteLine(" You have " + (MAX_FALSE_GUESS_COUNT - falseGuessCount) + " wrong guesses left.");
                }
                
                gameState = new string(gameStateChars);
                Console.WriteLine(" Game State: " + new string(gameStateChars));

                if (falseGuessCount == MAX_FALSE_GUESS_COUNT)
                {
                    Console.WriteLine("You are out of guesses. Game over!");
                    break;
                }
                if (gameState.Contains(UNDERSCORE))
                {
                    
                }
                else
                { 
                    Console.WriteLine("You won. Congratulations!"); 
                }
  
            }
        }
    }

}
