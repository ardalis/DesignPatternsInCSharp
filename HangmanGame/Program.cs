#define SupportUndo

using DesignPatternsInCSharp.Memento;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HangmanGameApp
{
    /// <summary>
    /// This program uses the Memento pattern
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

#if SupportUndo
            // MEMENTO NOTES:
            // HangmanGameWithUndo == ORIGINATOR
            // This Main Program   == CARETAKER
            // HangmanMemento      == MEMENTO
            var game = new HangmanGameWithUndo();
            var gameHistory = new Stack<HangmanMemento>();
            gameHistory.Push(game.CreateSetPoint());
#else
            var game = new HangmanGame();
#endif

            while (!game.IsOver)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Welcome to Hangman");

                Console.WriteLine(game.CurrentMaskedWord);
                Console.WriteLine($"Previous Guesses: {String.Join(',', game.PreviousGuesses.ToArray())}");
                Console.WriteLine($"Guesses Left: {game.GuessesRemaining}");

#if SupportUndo
                Console.WriteLine("Guess (a-z or '-' to undo last guess): ");
#else
                Console.WriteLine("Guess (a-z): ");
#endif

                var entry = char.ToUpperInvariant(Console.ReadKey().KeyChar);

#if SupportUndo
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
#endif
                try
                {
                    game.Guess(entry);
#if SupportUndo
                    gameHistory.Push(game.CreateSetPoint());
#endif
                    Console.WriteLine();
                }
                catch (DuplicateGuessException)
                {
                    OutputError("You already guessed that.");
                    continue;
                }
                catch (InvalidGuessException)
                {
                    OutputError("Sorry, invalid guess.");
                    continue;
                }
            }

            if (game.Result == GameResult.Won)
            {
                Console.WriteLine("CONGRATS! YOU WON!");
            }

            if (game.Result == GameResult.Lost)
            {
                Console.WriteLine("SORRY, You lost this time. Try again!");
            }
        }

        private static void OutputError(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }
}
