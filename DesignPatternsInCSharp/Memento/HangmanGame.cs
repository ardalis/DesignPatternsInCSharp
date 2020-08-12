using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsInCSharp.Memento
{
    public class HangmanGame
    {
        private readonly string _secretWord;
        private const char _maskChar = '_';

        public HangmanGame(string secretWord = "secret")
        {
            _secretWord = secretWord.ToUpperInvariant();
        }

        public bool IsOver => this.Result > GameResult.InProgress;
        public string CurrentMaskedWord => new string(_secretWord.Select(c => PreviousGuesses.Contains(c) ? c : _maskChar).ToArray());
        public List<char> PreviousGuesses { get; } = new List<char>();
        public int GuessesRemaining { get; set; } = 5;
        public GameResult Result { get; private set; }

        public void Guess(string entry)
        {
            if (String.IsNullOrWhiteSpace(entry)) throw new InvalidGuessException("Guess must be a valid character.");
            if (entry.Length > 1) throw new InvalidGuessException("Guess must be a single character.");
            if (IsOver) throw new InvalidGuessException("Can't make guesses after game is over.");

            char guessChar = Convert.ToChar(entry.ToUpperInvariant());

            if (PreviousGuesses.Any(g => g == guessChar)) throw new DuplicateGuessException();

            PreviousGuesses.Add(guessChar);

            if (_secretWord.IndexOf(guessChar) >= 0)
            {
                if (!CurrentMaskedWord.Contains(_maskChar))
                {
                    Result = GameResult.Won;
                }
                return;
            }

            GuessesRemaining--;

            if(GuessesRemaining <= 0)
            {
                Result = GameResult.Lost;
            }
        }
    }
}
