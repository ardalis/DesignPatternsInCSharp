using DesignPatternsInCSharp.Memento;
using System;
using System.Collections.Generic;

namespace HangmanGameApp
{
    /// <summary>
    /// This program uses the Memento pattern
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //var game = new HangmanGame();
            var game = new HangmanGameWithUndo();
            var gameHistory = new Stack<IMemento>();
            gameHistory.Push(game.CreateSetPoint());


            while (!game.IsOver)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Welcome to Hangman");

                Console.WriteLine(game.CurrentMaskedWord);
                Console.WriteLine($"Previous Guesses: {String.Join(',', game.PreviousGuesses.ToArray())}");
                Console.WriteLine($"Guesses Left: {game.GuessesRemaining}");
                Console.WriteLine("Guess (a-z or '-' to undo last guess): ");

                var entry = char.ToUpperInvariant(Console.ReadKey().KeyChar);

                if(entry == '-')
                {
                    if(gameHistory.Count > 1)
                    {
                        gameHistory.Pop();
                        game.ResumeFrom(gameHistory.Peek());
                        Console.WriteLine();
                        continue;
                    }
                }
                game.Guess(entry);
                gameHistory.Push(game.CreateSetPoint());
                Console.WriteLine();
            }

            if(game.Result == GameResult.Won)
            {
                Console.WriteLine("CONGRATS! YOU WON!");
            }

            if (game.Result == GameResult.Lost)
            {
                Console.WriteLine("SORRY, You lost this time. Try again!");
            }
        }
    }
}
