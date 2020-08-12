using System;
using Xunit;

namespace DesignPatternsInCSharp.Memento.Tests
{
    public class HangmanGameGuess
    {
        private const string TEST_SECRET_WORD = "TEST";

        private HangmanGame _game = new HangmanGame(TEST_SECRET_WORD);

        [Theory]
        [InlineData("AA")]
        [InlineData("")]
        [InlineData("-")]
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
        public void ThrowsGivenValidGuessWhenGameIsOver()
        {
            _game.Guess("t");
            _game.Guess("e");
            _game.Guess("s"); // game over - WON

            Assert.Throws<InvalidGuessException>(() => _game.Guess("a"));
        }

        [Fact]
        public void DecrementsGuessesRemainingGivenInvalidGuess()
        {
            int initialGuesses = _game.GuessesRemaining;
            string wrongGuess = "Z";

            _game.Guess(wrongGuess);

            Assert.Equal(initialGuesses - 1, _game.GuessesRemaining);
        }

        [Theory]
        [InlineData("E")]
        [InlineData("e")]
        public void DoesNotDecrementGuessesRemainingGivenValidGuess(string correctGuess)
        {
            int initialGuesses = _game.GuessesRemaining;

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

        [Fact]
        public void SetsGameIsOverTrueAndResultLostWhenGuessesLeftReaches0()
        {
            _game.Guess("a");
            _game.Guess("b");
            _game.Guess("c");
            _game.Guess("d");
            _game.Guess("e"); // correct
            _game.Guess("f");

            Assert.True(_game.IsOver);
            Assert.Equal(GameResult.Lost, _game.Result);
        }

        [Fact]
        public void SetsGameIsOverTrueAndResultWonWhenGuessesLeftReaches0()
        {
            _game.Guess("t");
            _game.Guess("e");
            _game.Guess("s");

            Assert.True(_game.IsOver);
            Assert.Equal(GameResult.Won, _game.Result);
        }

    }
}
