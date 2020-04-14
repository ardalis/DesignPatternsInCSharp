using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsInCSharp.Singleton.v1
{
    public static class Logger
    {
        private static List<string> _log = new List<string>();

        public static void Log(string message)
        {
            _log.Add(message);
        }

        public static void Clear()
        {
            _log.Clear();
        }

        public static string StringDump()
        {
            return string.Join(Environment.NewLine, _log);
        }

        public static IEnumerable<string> Output()
        {
            return _log.AsEnumerable();
        }
    }
}
