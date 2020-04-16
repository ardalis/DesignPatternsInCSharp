using System;
using System.Reflection;

namespace DesignPatternsInCSharp.Singleton.v1
{
    public static class SingletonTestHelpers
    {
        public static void Reset()
        {
            Type type = typeof(Singleton);
            FieldInfo info = type.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
            info.SetValue(null, null);
        }

        public static Singleton GetPrivateStaticInstance()
        {
            Type type = typeof(Singleton);
            FieldInfo info = type.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
            return info.GetValue(null) as Singleton;
        }
    }
}
