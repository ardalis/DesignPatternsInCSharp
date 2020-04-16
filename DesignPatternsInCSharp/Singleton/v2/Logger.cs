using System;
using System.Collections.Generic;

namespace DesignPatternsInCSharp.Singleton.v2
{
    public static class Logger
    {
        private static List<string> _log = new List<string>();
        public static int DelayMilliseconds { get; set; } = 0;

        public static void Log(string message)
        {
            System.Threading.Thread.Sleep(DelayMilliseconds);
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

        public static List<string> Output()
        {
            return _log;
        }
    }
}
