using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace DesignPatternsInCSharp.Memento
{
    public class HangmanGame
    {
        private readonly string _secretWord;

        public HangmanGame(string secretWord = "secret")
        {
            _secretWord = secretWord.ToUpper();
        }

        public bool IsOver { get; set; }
        public string CurrentMaskedWord => new string(_secretWord.Select(c => PreviousGuesses.Contains(c) ? c : '_').ToArray());
        public List<char> PreviousGuesses { get; } = new List<char>();
        public int GuessesRemaining { get; set; } = 5;

        public void Guess(string entry)
        {
            if (String.IsNullOrWhiteSpace(entry)) throw new InvalidGuessException();
            if (entry.Length > 1) throw new InvalidGuessException();
            char guessChar = Convert.ToChar(entry);

            if (PreviousGuesses.Any(g => g == guessChar)) throw new DuplicateGuessException();

            PreviousGuesses.Add(guessChar);

            if (_secretWord.IndexOf(entry) >= 0) return;

            GuessesRemaining--;
        }
    }

    public class HangmaneGameConstructor
    {
        private const string TEST_SECRET_WORD = "TEST";

        private HangmanGame _game = new HangmanGame(TEST_SECRET_WORD);

        [Fact]
        public void HasMaskedWordOfAllUnderscores()
        {
            Assert.Equal("____", _game.CurrentMaskedWord);
        }
    }

    public class HangmanGameGuess
    {
        private const string TEST_SECRET_WORD = "TEST";

        private HangmanGame _game = new HangmanGame(TEST_SECRET_WORD);

        [Theory]
        [InlineData("AA")]
        [InlineData("")]
        public void ThrowsGivenInvalidGuess(string invalidGuess)
        {
            Assert.Throws<InvalidGuessException>(() => _game.Guess(invalidGuess));
        }

        [Fact]
        public void ThrowsGivenDuplicateGuess()
        {
            string wrongGuess = "Z";
            _game.Guess(wrongGuess);
            
            Assert.Throws<DuplicateGuessException>(() => _game.Guess(wrongGuess));
        }

        [Fact]
        public void DecrementsGuessesRemainingGivenInvalidGuess()
        {
            int initialGuesses = _game.GuessesRemaining;
            string wrongGuess = "Z";

            _game.Guess(wrongGuess);

            Assert.Equal(initialGuesses - 1, _game.GuessesRemaining);
        }

        [Fact]
        public void DoesNotDecrementGuessesRemainingGivenValidGuess()
        {
            int initialGuesses = _game.GuessesRemaining;
            string correctGuess = "E";

            _game.Guess(correctGuess);

            Assert.Equal(initialGuesses, _game.GuessesRemaining);
        }

        [Fact]
        public void MaskedWordIncludesGuessLetterIfCorrect()
        {
            string correctGuess = "E";

            _game.Guess(correctGuess);

            Assert.True(_game.CurrentMaskedWord.IndexOf(Convert.ToChar(correctGuess)) >= 0);
        }
    }
}
