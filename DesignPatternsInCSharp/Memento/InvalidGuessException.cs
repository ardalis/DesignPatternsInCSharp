using System;

namespace DesignPatternsInCSharp.Memento
{
    public class InvalidGuessException : Exception
    {
        public InvalidGuessException(string message) : base(message)
        {
        }
    }
}
