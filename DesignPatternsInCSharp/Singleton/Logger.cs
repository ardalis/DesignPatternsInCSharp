using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsInCSharp.Singleton
{
    public static class Logger
    {
        private static ConcurrentQueue<string> _log = new ConcurrentQueue<string>();
        public static int DelayMilliseconds { get; set; } = 0;

        public static void Log(string message)
        {
            System.Threading.Thread.Sleep(DelayMilliseconds);
            _log.Enqueue(message);
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
            return _log.ToList();
        }
    }
}
