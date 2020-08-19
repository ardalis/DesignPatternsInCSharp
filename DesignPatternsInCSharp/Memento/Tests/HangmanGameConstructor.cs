using Xunit;

namespace DesignPatternsInCSharp.Memento.Tests
{
    public class HangmaneGamConstructor
    {
        private const string TEST_SECRET_WORD = "TEST";

        private HangmanGame _game = new HangmanGame(TEST_SECRET_WORD);

        [Fact]
        public void HasMaskedWordOfAllUnderscores()
        {
            Assert.Equal("____", _game.CurrentMaskedWord);
        }
    }
}
