using System;
using Xunit;

namespace DesignPatternsInCSharp.Memento.Tests
{
    public class HangmanGameGuess
    {
        private const string TEST_SECRET_WORD = "TEST";

        private HangmanGame _game = new HangmanGame(TEST_SECRET_WORD);

        [Theory]
        [InlineData(' ')]
        [InlineData('-')]
        [InlineData('1')]
        public void ThrowsGivenInvalidGuess(char invalidGuess)
        {
            Assert.Throws<InvalidGuessException>(() => _game.Guess(invalidGuess));
        }

        [Fact]
        public void ThrowsGivenDuplicateGuess()
        {
            char wrongGuess = 'Z';
            _game.Guess(wrongGuess);

            Assert.Throws<DuplicateGuessException>(() => _game.Guess(wrongGuess));
        }

        [Fact]
        public void ThrowsGivenValidGuessWhenGameIsOver()
        {
            _game.Guess('T');
            _game.Guess('E');
            _game.Guess('S'); // game over - WON

            Assert.Throws<InvalidGuessException>(() => _game.Guess('A'));
        }

        [Fact]
        public void DecrementsGuessesRemainingGivenInvalidGuess()
        {
            int initialGuesses = _game.GuessesRemaining;
            char wrongGuess = 'Z';

            _game.Guess(wrongGuess);

            Assert.Equal(initialGuesses - 1, _game.GuessesRemaining);
        }

        [Theory]
        [InlineData('E')]
        public void DoesNotDecrementGuessesRemainingGivenValidGuess(char correctGuess)
        {
            int initialGuesses = _game.GuessesRemaining;

            _game.Guess(correctGuess);

            Assert.Equal(initialGuesses, _game.GuessesRemaining);
        }

        [Fact]
        public void MaskedWordIncludesGuessLetterIfCorrect()
        {
            char correctGuess = 'E';

            _game.Guess(correctGuess);

            Assert.True(_game.CurrentMaskedWord.IndexOf(Convert.ToChar(correctGuess)) >= 0);
        }

        [Fact]
        public void SetsGameIsOverTrueAndResultLostWhenGuessesLeftReaches0()
        {               
            _game.Guess('A');
            _game.Guess('B');
            _game.Guess('C');
            _game.Guess('D');
            _game.Guess('E'); // correct
            _game.Guess('F');

            Assert.True(_game.IsOver);
            Assert.Equal(GameResult.Lost, _game.Result);
        }

        [Fact]
        public void SetsGameIsOverTrueAndResultWonWhenEntireWordIsGuessed()
        {
            _game.Guess('T');
            _game.Guess('E');
            _game.Guess('S');

            Assert.True(_game.IsOver);
            Assert.Equal(GameResult.Won, _game.Result);
        }

    }
}
