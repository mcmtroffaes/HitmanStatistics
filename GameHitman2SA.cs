using System.Collections.Generic;
using System;
using System.Linq;

public class GameHitman2SA : IGame
{
    private const int baseAddress = 0x00400000;

    // Most values are accessed with 3-levels pointers and the second offset is different depending on the current mission.
    // All second offsets are stored here to be accessed according to the correct mission.
    readonly static int[] secondOffset = { 0x838, 0xB24, 0x8A0, 0x138, 0xB88, 0xBB8, 0xB48, 0xCE8, 0x136C, 0xAD0, 0xF50, 0x8D4, 0x9EC, 0x400, 0x9EC, 0x644, 0xB08, 0x96C, 0xB00, 0x8 };

    private readonly static Dictionary<string, Tuple<string, int>> mapValues = new Dictionary<string, Tuple<string, int>>() {
        { "C1-1__MA", new Tuple<string, int>("Anathema", 1) },
        { "C2-1__MA", new Tuple<string, int>("St. Petersburg Stakeout", 2) },
        { "C2-2__MA", new Tuple<string, int>("Kirov Park Meeting", 3) },
        { "C2-3__MA", new Tuple<string, int>("Tubeway Torpedo", 4) },
        { "C2-4__MA", new Tuple<string, int>("Invitation to a Party", 5) },
        { "C3-1__MA", new Tuple<string, int>("Tracking Hayamoto", 6) },
        { "\\C3-2a__", new Tuple<string, int>("Hidden Valley", 7) },
        { "\\C3-2b__", new Tuple<string, int>("At the Gates", 8) },
        { "C3-3__MA", new Tuple<string, int>("Shogun Showdown", 9) },
        { "C4-1__MA", new Tuple<string, int>("Basement Killing", 10) },
        { "C4-2__MA", new Tuple<string, int>("The Graveyard Shift", 11) },
        { "C4-3__MA", new Tuple<string, int>("The Jacuzzi Job", 12) },
        { "C5-1__MA", new Tuple<string, int>("Murder At The Bazaar", 13) },
        { "C5-2__MA", new Tuple<string, int>("The Motorcade Interception", 14) },
        { "C5-3__MA", new Tuple<string, int>("Tunnel Rat", 15) },
        { "C6-1__MA", new Tuple<string, int>("Temple City Ambush", 16) },
        { "C6-2__MA", new Tuple<string, int>("The Death of Hannelore", 17) },
        { "C6-3__MA", new Tuple<string, int>("Terminal Hospitality", 18) },
        { "C7-1__MA", new Tuple<string, int>("St. Petersburg Revisited", 19) },
        { "C8-1__MA", new Tuple<string, int>("Redemption at Gontranno", 20) }
    };

    // All the possible Silent Assassin combinations for Hitman 2
    // https://docs.google.com/spreadsheets/d/1i6dmzcBROqoJlsQjUGY8wxdqwxt2hXzjB9fPVggTf2k/edit?gid=1074822823#gid=1074822823
    private readonly static Statistics[] validSACombination = {
        new Statistics(0, 1, 0, 0, 1, 2, 0, 0),
        new Statistics(0, 1, 0, 0, 0, 5, 0, 0),
        new Statistics(0, 1, 0, 0, 0, 2, 0, 1),
        new Statistics(0, 0, 0, 1, 2, 0, 0, 0),
        new Statistics(0, 0, 0, 1, 1, 3, 0, 0),
        new Statistics(0, 0, 0, 1, 1, 0, 0, 1),
        new Statistics(0, 0, 0, 1, 0, 6, 0, 0),
        new Statistics(0, 0, 0, 1, 0, 3, 0, 1),
        new Statistics(0, 0, 0, 1, 0, 0, 1, 0),
        new Statistics(0, 0, 0, 1, 0, 0, 0, 2),
        new Statistics(0, 0, 0, 0, 1, 0, 0, 1),
        new Statistics(1, 1, 1, 0, 0, 2, 0, 0),
        new Statistics(1, 1, 0, 0, 1, 0, 0, 0),
        new Statistics(1, 1, 0, 0, 0, 3, 0, 0),
        new Statistics(1, 1, 0, 0, 0, 0, 0, 1),
        new Statistics(1, 0, 1, 1, 1, 0, 0, 0),
        new Statistics(1, 0, 1, 1, 0, 3, 0, 0),
        new Statistics(1, 0, 1, 1, 0, 0, 0, 1),
        new Statistics(1, 0, 0, 1, 1, 1, 0, 0),
        new Statistics(1, 0, 0, 1, 0, 4, 0, 0),
        new Statistics(1, 0, 0, 1, 0, 1, 0, 1),
        new Statistics(1, 0, 0, 0, 1, 1, 0, 0),
        new Statistics(2, 1, 1, 0, 0, 0, 0, 0),
        new Statistics(2, 1, 0, 0, 0, 1, 0, 0),
        new Statistics(2, 0, 2, 1, 0, 0, 0, 0),
        new Statistics(2, 0, 1, 1, 0, 1, 0, 0),
        new Statistics(3, 0, 0, 1, 0, 0, 0, 0)
    };

    public string Name()
    {
        return "Hitman 2 Silent Assassin";
    }

    public string ProcessName()
    {
        return "hitman2";
    }

    public bool IsRunning(int Handle)
    {
        return Handle != 0 && Trainer.ReadPointerInteger(Handle, baseAddress) == 0x00905A4D;
    }

    public Mission Mission(int Handle)
    {
        if (Handle != 0)
        {
            string mapKey = Trainer.ReadPointerString(Handle, baseAddress + 0x2A6C5C, new int[2] { 0x98, 0xBC7 }, 8);
            Logger.Log($"map key: {mapKey}");
            if (mapValues.TryGetValue(mapKey, out Tuple<string, int> mapNameNumber))
            {
                string mapName = mapNameNumber.Item1;
                int mapNumber = mapNameNumber.Item2;
                int missionTime = Trainer.ReadPointerInteger(Handle, baseAddress + 0x2A6C58, new int[5] { 0x118, 0xB38, 0x8, 0x1084, 0x24 });
                Logger.Log($"mission time: {missionTime}");
                if (missionTime != 0)
                {
                    int mapSecondOffset = secondOffset[mapNumber - 1];
                    Statistics stats = new Statistics(
                        sf: Trainer.ReadPointerInteger(Handle, baseAddress + 0x39419, new int[2] { 0xBD, 0x11C7 }),  // TODO this is broken
                        ce: Trainer.ReadPointerInteger(Handle, baseAddress + 0x2A6C50, new int[3] { 0x28, mapSecondOffset, 0x220 }),
                        hs: Trainer.ReadPointerInteger(Handle, baseAddress + 0x2A6C50, new int[3] { 0x28, mapSecondOffset, 0x208 }),
                        al: Trainer.ReadPointerInteger(Handle, baseAddress + 0x2A6C50, new int[3] { 0x28, mapSecondOffset, 0x21C }),
                        ek: Trainer.ReadPointerInteger(Handle, baseAddress + 0x2A6C50, new int[3] { 0x28, mapSecondOffset, 0x210 }),
                        eh: Trainer.ReadPointerInteger(Handle, baseAddress + 0x2A6C50, new int[3] { 0x28, mapSecondOffset, 0x20C }),
                        ik: Trainer.ReadPointerInteger(Handle, baseAddress + 0x2A6C50, new int[3] { 0x28, mapSecondOffset, 0x218 }),
                        ih: Trainer.ReadPointerInteger(Handle, baseAddress + 0x2A6C50, new int[3] { 0x28, mapSecondOffset, 0x214 })
                    );
                    Logger.Log($"stats: {stats}");
                    bool isSilentAssassin = validSACombination.Any(combination => stats.IsLessOrEqualTo(combination));
                    Logger.Log($"silent assassin: {isSilentAssassin}");
                    return new Mission(mapNumber, mapName, missionTime / 60.0F, stats, isSilentAssassin);
                }
            }
        }
        return new Mission();
    }
}
