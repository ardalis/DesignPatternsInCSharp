using DesignPatternsInCSharp.Memento;
using System;

namespace HangmanGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new HangmanGame();

            Console.WriteLine("Welcome to Hangman");

            while (!game.IsOver)
            {
                Console.WriteLine(game.CurrentMaskedWord);
                Console.WriteLine($"Previous Guesses: {String.Join(',', game.PreviousGuesses.ToArray())}");
                Console.WriteLine($"Guess Left: {game.GuessesRemaining}");
                Console.WriteLine("Guess: ");

                var entry = Console.ReadLine();
                game.Guess(entry);


            }
        }
    }
}
