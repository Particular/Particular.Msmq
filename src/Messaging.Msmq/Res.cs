namespace System.Messaging
{
    using System.Collections.Generic;

    static class Res
    {
        public static string GetString(string id) => strings[id];

        static readonly Dictionary<string, string> strings = new();
    }
}

