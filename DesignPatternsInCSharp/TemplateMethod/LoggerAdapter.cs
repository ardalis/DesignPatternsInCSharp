using System;
using System.Collections.Generic;

namespace DesignPatternsInCSharp.TemplateMethod
{
    public class LoggerAdapter
    {
        private List<string> _messages = new List<string>();
        public void Log(string message)
        {
            _messages.Add(message);
        }

        public string Dump()
        {
            return String.Join(Environment.NewLine, _messages);
        }
    }
}
