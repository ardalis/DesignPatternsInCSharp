using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace DesignPatternsInCSharp.KATA.Singleton_AdamAndEve
{
    public class Male : Human
    {
        public Male(string name, Female mother, Male father)
        {
            Name = name;
            Mother = mother;
            Father = father;
            if (father == null || mother == null)
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(2);
                if (callingFrame == null || callingFrame.GetMethod().DeclaringType.Name != "Adam")
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public string Name { get; set; }
        public Female Mother { get; set; }
        public Male Father { get; set; }
    }
}
