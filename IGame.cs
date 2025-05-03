using System;

public class Mission
{
    public readonly int number;
    public readonly string name;
    public readonly float time;
    public readonly int[] statistics;
    public readonly int silentAssassin;  // 0 = yes, 1 = maybe, 2 = no

    public Mission()
    {
        number = 0;
        name = "";
        time = 0.0F;
        statistics = null;
        silentAssassin = 0;
    }

    public Mission(int number, string name, float time, int[] statistics, int silentAssassin)
    {
        this.number = number;
        this.name = name;
        this.time = time;
        this.statistics = statistics;
        this.silentAssassin = silentAssassin;
    }

    public override string ToString()
    {
        return $"name: {name}, time: {time}, stats: {statistics}, silent assassin: {silentAssassin}";
    }
};

interface IGame
{
    string Name();
    string ProcessName();
    Tuple<string, Func<int, string>>[] StatisticsNames();
    bool IsRunning(int Handle);
    Mission Mission(int Handle);
}
