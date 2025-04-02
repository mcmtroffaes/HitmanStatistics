using System.IO;
using System;

class Logger
{
    public static void Log(string msg)
    {
#if DEBUG
        DateTime now = DateTime.Now;
        File.AppendAllText(
            Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                $"HitmanStatistics-{now:yyyyMMdd}.log"
            ),
            $"[{now}] {msg}\n"
        );
#endif
    }
}
