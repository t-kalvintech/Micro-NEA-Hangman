using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using System.IO;
using System.Threading;

namespace Hangman
{
    internal class Program
    {
        private static void displayHangman(int incorrect)
        {
            if(incorrect == 0)
            {
                Console.WriteLine("  _______");
                Console.WriteLine("  |     |");
                Console.WriteLine("        |");
                Console.WriteLine("        |");
                Console.WriteLine("        |");
                Console.WriteLine("     ___|__");
            }
            else if(incorrect == 1)
            {
                Console.WriteLine("  _______");
                Console.WriteLine("  |     |");
                Console.WriteLine("  O     |");
                Console.WriteLine("        |");
                Console.WriteLine("        |");
                Console.WriteLine("     ___|__");
            }
            else if (incorrect == 2)
            {
                Console.WriteLine("  _______");
                Console.WriteLine("  |     |");
                Console.WriteLine("  O     |");
                Console.WriteLine("  |     |");
                Console.WriteLine("        |");
                Console.WriteLine("     ___|__");
            }
            else if (incorrect == 3)
            {
                Console.WriteLine("  _______");
                Console.WriteLine("  |     |");
                Console.WriteLine("  O     |");
                Console.WriteLine(" /|     |");
                Console.WriteLine("        |");
                Console.WriteLine("     ___|__");
            }
            else if (incorrect == 4)
            {
                Console.WriteLine("  _______");
                Console.WriteLine("  |     |");
                Console.WriteLine("  O     |");
                Console.WriteLine(" /|\\    |");
                Console.WriteLine("        |");
                Console.WriteLine("     ___|__");
            }
            else if (incorrect == 5)
            {
                Console.WriteLine("  _______");
                Console.WriteLine("  |     |");
                Console.WriteLine("  O     |");
                Console.WriteLine(" /|\\    |");
                Console.WriteLine(" /      |");
                Console.WriteLine("     ___|__");
            }
            else if (incorrect == 6)
            {
                Console.WriteLine("  _______");
                Console.WriteLine("  |     |");
                Console.WriteLine("  O     |");
                Console.WriteLine(" /|\\    |");
                Console.WriteLine(" / \\    |");
                Console.WriteLine("     ___|__");
            }

        }
        private static int displayWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int correctletters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if(guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    correctletters++;
                }
                else
                {
                    Console.Write(" ");
                }
                counter++;
            }
            return correctletters;
        }

        private static void displayLines(String randomWord)
        {
            Console.Write("\r");
            foreach(char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Kalvin's Hangman Game!");
            Thread.Sleep(1000);
            Console.WriteLine("  _______");
            Console.WriteLine("  |     |");
            Console.WriteLine("  O     |");
            Console.WriteLine(" /|\\    |");
            Console.WriteLine(" / \\    |");
            Console.WriteLine("     ___|__");
            Console.WriteLine("\n");
            Thread.Sleep(1000);
            Console.WriteLine("--------------------------------- \n");
            Thread.Sleep(2000);

            Random random = new Random();
            List<string> hangmanList = new List<string> { "test"};
            int index = random.Next(hangmanList.Count);
            String randomWord = hangmanList[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }
            Console.WriteLine("\n ");
            int lengthOfActualWord = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> numOfLettersGuessed = new List<char>();
            int numOfLettersCorrect = 0;

            while(amountOfTimesWrong != 6 && numOfLettersCorrect != lengthOfActualWord)
            {
                Thread.Sleep(250);
                Console.Write("\nThe letters you have guessed so far are: \n");
                foreach(char letter in numOfLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                Thread.Sleep(250);
                Console.Write("\nPlease enter a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                if(numOfLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n Please enter a different letter as you have already guessed this letter!");
                    displayHangman(amountOfTimesWrong);
                    numOfLettersCorrect = displayWord(numOfLettersGuessed, randomWord);
                    displayLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for(int i=0; i<randomWord.Length; i++) {if(letterGuessed == randomWord[i]) { right = true; } }

                    if(right)
                    {
                        displayHangman(amountOfTimesWrong);
                        numOfLettersGuessed.Add(letterGuessed);
                        numOfLettersCorrect = displayWord(numOfLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        displayLines(randomWord);
                    }
                    else
                    {
                        amountOfTimesWrong++;
                        numOfLettersGuessed.Add(letterGuessed);
                        displayHangman(amountOfTimesWrong);
                        numOfLettersCorrect = displayWord(numOfLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        displayLines(randomWord);
                    }

                }
            }
            Console.WriteLine("GAME OVER! 😢 😭");
            Thread.Sleep(1000);
            Console.WriteLine("The word that you needed to guess was: " + randomWord);
            Thread.Sleep(1000);
            Console.WriteLine("GOOD BYE! 👏");
        }
    }
}
