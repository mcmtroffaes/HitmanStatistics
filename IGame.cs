public class Mission
{
    public readonly int number;
    public readonly string name;
    public readonly float time;
    public readonly Statistics statistics;
    public readonly bool isSilentAssassin;

    public Mission()
    {
        this.number = 0;
        this.name = "";
        this.time = 0.0F;
        this.statistics = new Statistics(0, 0, 0, 0, 0, 0, 0, 0);
        this.isSilentAssassin = true;
    }

    public Mission(int number, string name, float time, Statistics statistics, bool isSilentAssassin)
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
    bool IsRunning(int Handle);
    Mission Mission(int Handle);
}
