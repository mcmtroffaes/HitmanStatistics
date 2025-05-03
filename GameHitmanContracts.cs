using System.Collections.Generic;
using System;
using System.Linq;
using HitmanStatistics;

public class GameHitmanContracts : IGame
{
    private const int baseAddress = 0x00400000;

    // Map pointers for HC
    readonly static Pointer[] mapPointers = {
        new Pointer(0x00393D58, new int[2] { 0x234, 0xBDE }),
        new Pointer(0x00394598, new int[3] { 0x10, 0x194, 0xC0E }),
        new Pointer(0x00394598, new int[2] { 0x214, 0xC0E }),
        new Pointer(0x00394578, new int[2] { 0x1EC0, 0x49FA }),
        new Pointer(0x00394578, new int[3] { 0x1E00, 0xBC, 0x49FA }),
        new Pointer(0x00394578, new int[4] { 0x1D80, 0x7C, 0xBC, 0x49FA }),
        new Pointer(0x00394578, new int[5] { 0x1D00, 0x7C, 0x7C, 0xBC, 0x49FA }),
        new Pointer(0x0039457C, new int[2] { 0x1E40, 0x49FA }),
        new Pointer(0x0039457C, new int[3] { 0x1D80, 0xBC, 0x49FA }),
        new Pointer(0x0039457C, new int[4] { 0x1D00, 0x7C, 0xBC, 0x49FA }),
        new Pointer(0x0039457C, new int[5] { 0x1C80, 0x7C, 0x7C, 0xBC, 0x49FA })
    };

    private readonly static Dictionary<string, Tuple<string, int>> mapValues = new Dictionary<string, Tuple<string, int>>() {
        { "C01-1_MA", new Tuple<string, int>("Asylum Aftermath", 1) },
        { "C01-2_MA", new Tuple<string, int>("The Meat King's Party", 2) },
        { "C02-1_MA", new Tuple<string, int>("The Bjarkhov Bomb", 3) },
        { "C03-1_MA", new Tuple<string, int>("Beldingford Manor", 4) },
        { "C06-1_MA", new Tuple<string, int>("Rendezvous in Rotterdam", 5) },
        { "C06-2_MA", new Tuple<string, int>("Deadly Cargo", 6) },
        { "C07-1_MA", new Tuple<string, int>("Traditions of the Trade", 7) },
        { "C08-1_MA", new Tuple<string, int>("Slaying a Dragon", 8) },
        { "C08-2_MA", new Tuple<string, int>("The Wang Fou Incident", 9) },
        { "C08-3_MA", new Tuple<string, int>("The Seafood Massacre", 10) },
        { "C08-4_MA", new Tuple<string, int>("Lee Hong Assassination", 11) },
        { "C09-1_MA", new Tuple<string, int>("Hunter and Hunted", 12) }
    };

    // All the possible Silent Assassin combinations for Hitman Contracts
    // https://docs.google.com/spreadsheets/d/1i6dmzcBROqoJlsQjUGY8wxdqwxt2hXzjB9fPVggTf2k/edit?gid=1074822823#gid=1074822823
    private static readonly int[][] validSACombination = {
        new int[] { 999, 0, 999, 1, 0, 0, 0, 0 },
        new int[] { 2, 1, 1, 0, 0, 0, 0, 0 },
        new int[] { 2, 1, 0, 0, 0, 1, 0, 0 },
        new int[] { 2, 0, 1, 1, 0, 1, 0, 0 },
        new int[] { 2, 0, 0, 0, 0, 2, 0, 0 },
        new int[] { 1, 1, 1, 0, 0, 2, 0, 0 },
        new int[] { 1, 1, 0, 0, 1, 0, 0, 0 },
        new int[] { 1, 1, 0, 0, 0, 3, 0, 0 },
        new int[] { 1, 0, 1, 1, 1, 0, 0, 0 },
        new int[] { 1, 0, 1, 1, 0, 3, 0, 0 },
        new int[] { 1, 0, 0, 1, 1, 1, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 4, 0, 0 },
        new int[] { 0, 1, 0, 0, 1, 2, 0, 0 },
        new int[] { 0, 1, 0, 0, 0, 5, 0, 0 },
        new int[] { 0, 0, 0, 1, 1, 3, 0, 0 },
        new int[] { 0, 0, 0, 1, 2, 0, 0, 0 },
        new int[] { 0, 0, 0, 1, 0, 6, 0, 0 }
    };
    private static readonly int[][] validSACombinationMap1 = {
        new int[] { 999, 0, 0, 1, 0, 0, 0, 0 },
        new int[] { 2, 0, 0, 0, 0, 2, 0, 0 },
        new int[] { 1, 0, 1, 1, 1, 0, 0, 0 },
        new int[] { 1, 0, 0, 1, 1, 1, 0, 0 },
        new int[] { 1, 0, 0, 1, 0, 4, 0, 0 },
        new int[] { 0, 0, 0, 1, 1, 3, 0, 0 },
        new int[] { 0, 0, 0, 1, 2, 0, 0, 0 },
        new int[] { 0, 0, 0, 1, 0, 6, 0, 0 }
    };

    int mapPointerNumber = 0;

    public string Name()
    {
        return "Hitman Contracts";
    }

    public string ProcessName()
    {
        return "HitmanContracts";
    }

    public Tuple<string, Func<int, string>>[] StatisticsNames()
    {
        return new Tuple<string, Func<int, string>>[] {
            Tuple.Create("Shots Fired", Utils.ValueToString),
            Tuple.Create("Close Encounters", Utils.ValueToString),
            Tuple.Create("Headshots", Utils.ValueToString),
            Tuple.Create("Alerts", Utils.ValueToString),
            Tuple.Create("Enemies Killed", Utils.ValueToString),
            Tuple.Create("Enemies Wounded", Utils.ValueToString),
            Tuple.Create("Innocents Killed", Utils.ValueToString),
            Tuple.Create("Innocents Wounded", Utils.ValueToString),
        };
    }

    public bool IsRunning(int Handle)
    {
        return Handle != 0 && Trainer.ReadPointerInteger(Handle, baseAddress) == 0x00905A4D;
    }

    public Mission Mission(int Handle)
    {
        if (Handle != 0)
        {
            string mapKey = Trainer.ReadPointerString(Handle, baseAddress + mapPointers[mapPointerNumber].Address, mapPointers[mapPointerNumber].Offsets, 8);
            Logger.Log($"map key: {mapKey}");
            if (mapValues.TryGetValue(mapKey, out Tuple<string, int> mapNameNumber))
            {
                string mapName = mapNameNumber.Item1;
                int mapNumber = mapNameNumber.Item2;
                float missionTime = Trainer.ReadPointerFloat(Handle, baseAddress + 0x39457C, new int[1] { 0x24 });
                Logger.Log($"mission time: {missionTime}");
                if (missionTime != 0)
                {
                    int[] stats = new int[] {
                        Trainer.ReadPointerInteger(Handle, baseAddress + 0x3947B0, new int[3] { 0xBA0, 0x104, 0x82F }),  // shots fired
                        Trainer.ReadPointerInteger(Handle, baseAddress + 0x3947C0, new int[1] { 0xB2F }),  // close encounters
                        Trainer.ReadPointerInteger(Handle, baseAddress + 0x3947C0, new int[1] { 0xB17 }),  // headshots
                        Trainer.ReadPointerInteger(Handle, baseAddress + 0x3947C0, new int[1] { 0xB2B }),  // alerts
                        Trainer.ReadPointerInteger(Handle, baseAddress + 0x3947C0, new int[1] { 0xB1F }),  // enemies killed
                        Trainer.ReadPointerInteger(Handle, baseAddress + 0x3947C0, new int[1] { 0xB1B }),  // enemies wounded
                        Trainer.ReadPointerInteger(Handle, baseAddress + 0x3947C0, new int[1] { 0xB27 }),  // innocents killed
                        Trainer.ReadPointerInteger(Handle, baseAddress + 0x3947C0, new int[1] { 0xB23 })  // innocents wounded
                    };
                    Logger.Log($"stats: {stats}");
                    bool isSilentAssassin =
                        mapNumber != 1
                        ? validSACombination.Any(combination => IsLessOrEqualTo(stats, combination))
                        : validSACombinationMap1.Any(combination => IsLessOrEqualTo(stats, combination));
                    Logger.Log($"silent assassin: {isSilentAssassin}");
                    return new Mission(mapNumber, mapName, missionTime, stats, isSilentAssassin ? 0 : 2);
                }
            }
            else
            {
                // Try different pointer on next iteration.
                mapPointerNumber++;
                if (mapPointerNumber > 10)
                    mapPointerNumber = 0;
                Logger.Log($"map pointer number: {mapPointerNumber}");
            }
        }
        return null;
    }

    private bool IsLessOrEqualTo(int[] stats1, int[] stats2)
    {
        return stats1.Zip(stats2, (v1, v2) => v1 <= v2).All(x => x);
    }
}
