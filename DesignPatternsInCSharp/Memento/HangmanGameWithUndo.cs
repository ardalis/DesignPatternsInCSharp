namespace DesignPatternsInCSharp.Memento
{
    public class HangmanGameWithUndo : HangmanGame
    {
        public IMemento CreateSetPoint()
        {
            var guesses = PreviousGuesses.ToArray();
            return new HangmanState() { State = guesses };
        }

        public void ResumeFrom(IMemento memento)
        {
            var guesses = (char[])memento.State;
            PreviousGuesses.Clear();
            PreviousGuesses.AddRange(guesses);
        }

        public class HangmanState : IMemento
        {
            public object State { get; set; }
        }
    }
}
