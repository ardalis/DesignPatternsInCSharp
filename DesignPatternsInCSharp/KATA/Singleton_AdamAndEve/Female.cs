using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace DesignPatternsInCSharp.KATA.Singleton_AdamAndEve
{
    public class Female : Human
    {
        public Female(string name, Female mother, Male father)
        {
            Name = name;
            Mother = mother;
            Father = father;
            if (father == null || mother == null)
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(2);
                if (callingFrame == null || callingFrame.GetMethod().DeclaringType.Name != "Eve")
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
