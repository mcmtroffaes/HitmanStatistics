public class Mission
{
    public readonly int number;
    public readonly string name;
    public readonly float time;
    public readonly int[] statistics;
    public readonly bool? isSilentAssassin;

    public Mission()
    {
        number = 0;
        name = "";
        time = 0.0F;
        statistics = null;
        isSilentAssassin = null;
    }

    public Mission(int number, string name, float time, int[] statistics, bool? isSilentAssassin)
    {
        this.number = number;
        this.name = name;
        this.time = time;
        this.statistics = statistics;
        this.isSilentAssassin = isSilentAssassin;
    }

    public override string ToString()
    {
        return $"name: {name}, time: {time}, stats: {statistics}, silent assassin: {isSilentAssassin}";
    }
};

interface IGame
{
    string Name();
    string ProcessName();
    string[] StatisticsNames();
    bool IsRunning(int Handle);
    Mission Mission(int Handle);
}
