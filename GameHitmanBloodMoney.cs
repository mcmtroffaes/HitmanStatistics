public class GameHitmanBloodMoney : IGame
{
    private const int baseAddress = 0x00400000;

    public string Name()
    {
        return "Hitman Blood Money";
    }

    public string ProcessName()
    {
        return "HitmanBloodMoney";
    }

    public bool IsRunning(int Handle)
    {
        return Handle != 0 && Trainer.ReadPointerInteger(Handle, baseAddress) == 0x00905A4D;
    }

    public Mission Mission(int Handle)
    {
        if (Handle != 0)
        {
            int missionTime = Trainer.ReadPointerInteger(Handle, baseAddress + 0x41F820, new int[1] { 0x48 });
            Logger.Log($"mission time: {missionTime}");
            return new Mission(0, "Unknown", missionTime / 1024.0F, null, null);
        }
        return null;
    }
}
