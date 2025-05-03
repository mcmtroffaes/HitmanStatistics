using System;
using System.Collections.Generic;

class Utils
{
    public readonly static Func<int, string> ValueToString = (int value) => value.ToString();

    public readonly static Func<int, string> ValueToYesNo = (int value) => value != 0 ? "Yes" : "No";

    public static Func<int, string> MapToString(IDictionary<int, string> map)
    {
        return (int key) => map.TryGetValue(key, out string value) ? value : key.ToString();
    }
}
