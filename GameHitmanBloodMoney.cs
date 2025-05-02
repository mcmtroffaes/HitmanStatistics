using System;
using System.Net;
using System.Runtime.InteropServices;

public class GameHitmanBloodMoney : IGame
{
    // steam addresses from https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/StatModules/HM3/Src/HM3/HM3Pointers.cpp
    private const int baseAddress = 0x00400000;
    private const int statsPtr = 0x005B2538;
    private const int difficultyPtr = 0x0041F83C;
    private const int timePtr = 0x0041F820;
    // offsets from https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/StatModules/HM3/Src/HM3/Structs/HM3Stats.h
    private const int offsetRating1 = 0x0004; 
    private const int offsetRating0 = 0x0008; 
    private const int offsetSpecialRating = 0x000C; 
    private const int offsetRating1Total = 0x0010; 
    private const int offsetRating0Total = 0x0014; 
    private const int offsetCurrentLevel = 0x0018; 
    private const int offsetShotsFired = 0x001C; 
    private const int offsetShotsHit = 0x0020; 
    private const int offsetShotsMissed = 0x0024; 
    private const int offsetHeadshots = 0x0028; 
    private const int offsetCleanKills = 0x002C; 
    private const int offsetTargetCleanKills = 0x0030; 
    private const int offsetAccidentKills = 0x0034; 
    private const int offsetAlarms = 0x0038; 
    private const int offsetWitnesses = 0x003C; 
    private const int offsetEnemiesKilled = 0x0040; 
    private const int offsetUnknown01 = 0x0044; 
    private const int offsetEnemiesWounded = 0x0048; 
    private const int offsetEnemiesPushedToDeath = 0x004C; 
    private const int offsetPoliceMenKilled = 0x0050; 
    private const int offsetPoliceMenWounded = 0x0054; 
    private const int offsetInnocentsKilled = 0x0058; 
    private const int offsetInnocentsWounded = 0x005C; 
    private const int offsetUnknown02 = 0x0060; 
    private const int offsetUnknown03 = 0x0064; 
    private const int offsetTargetsSniped = 0x0068; 
    private const int offsetTargetsKilled = 0x006C; 
    private const int offsetUnknown04 = 0x0070; 
    private const int offsetFiberwireKills = 0x0074; 
    private const int offsetCloseCombatKills = 0x0078; 
    private const int offsetPreferredWeapon = 0x007C; 
    private const int offsetUnknown05 = 0x0080; 
    private const int offsetNoisyShots = 0x0084; 
    private const int offsetNumSaves = 0x0088; 
    private const int offsetBodiesHidden = 0x008C; 
    private const int offsetDisguisesUsed = 0x0090; 
    private const int offsetImpersonations = 0x0094; 
    private const int offsetAgencyPickups = 0x0098; 
    private const int offsetTime = 0x009C; 
    private const int offsetMoney = 0x00A0; 
    private const int offsetSuitLeftOnLevel = 0x00A4; 
    private const int offsetTarget1KilledWith = 0x00A8; 
    private const int offsetTarget2KilledWith = 0x00AC; 
    private const int offsetTarget3KilledWith = 0x00B0; 
    private const int offsetTarget4KilledWith = 0x00B4; 
    private const int offsetTarget5KilledWith = 0x00B8; 
    private const int offsetTarget6KilledWith = 0x00BC; 
    private const int offsetMainTargetNumber = 0x00C0; 
    private const int offsetTargetsPoisoned = 0x00C4; 
    private const int offsetFriskFailed = 0x00C8; 
    private const int offsetGhostFailed = 0x00CC; 
    private const int offsetBodiesFound = 0x00D0; 
    private const int offsetTargetBodiesFound = 0x00D4; 
    private const int offsetUnconsciousBodiesFound = 0x00D8; 
    private const int offsetCoverBlown = 0x00DC; 
    private const int offsetUnknown07 = 0x00E0; 
    private const int offsetNotoriety = 0x00E4; 
    private const int offsetTotalNotoriety = 0x00E8; 
    private const int offsetCameraCaught = 0x00EC; 
    private const int offsetUnknown08 = 0x00F0; 
    private const int offsetCustomWeaponsLeftOnLevel = 0x00F4; 
    private const int offsetCustomSniperSilenced = 0x00F8; 
    private const int offsetCustomHardballerSilenced = 0x00FC; 
    private const int offsetCustomSGSilenced = 0x0100; 
    private const int offsetCustomMGSilenced = 0x0104; 
    private const int offsetCustomSMGSilenced = 0x0108;
    // https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/Statman/Engines/HM3/StatTracker.cs
    private static readonly double[] statsMultipliers = {
        0.0, 1.0, 1.5, 2.0, 2.5, 3.0, 3.25, 3.5, 3.75, 4.0, 4.1300001, 4.25, 4.3800001, 4.5, 4.6300001, 4.75,
        4.8800001, 5.0, 5.0599999, 5.1300001, 5.1900001, 5.25, 5.3099999, 5.3800001, 5.4400001, 5.5, 5.5599999,
        5.6300001, 5.6900001, 5.75, 5.8099999, 5.8800001, 5.9400001, 6.0
    };
    private const int indexDifficulty = 0;
    private const int indexInnocentsKilled = 1;
    private const int indexInnocentsWounded = 2;
    private const int indexEnemiesKilled = 3;
    private const int indexEnemiesWounded = 4;
    private const int indexPoliceKilled = 5;
    private const int indexPoliceWounded = 6;
    private const int indexFriskFailed = 7;
    private const int indexCoverBlown = 8;
    private const int indexBodiesFound = 9;
    private const int indexTargetBodiesFound = 10;
    private const int indexUnconsciousBodiesFound = 11;
    private const int indexWitnesses = 12;
    private const int indexCaughtOnCamera = 13;
    private const int indexCustomWeaponsLeft = 14;
    private const int indexSuitLeft = 15;

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

    public string[] StatisticsNames()
    {
        // order must match index values
        return new string[] {
            "Difficulty",
            "Innocents Killed",
            "Innocents Wounded",
            "Enemies Killed",
            "Enemies Wounded",
            "Police Killed",
            "Police Wounded",
            "Frisk Failed",
            "Cover Blown",
            "Bodies Found",
            "Target Bodies Fnd",
            "Uncon Bodies Fnd",
            "Witnesses",
            "On Camera",
            "Weapons Left",
            "Suit Left"
        };
    }

    public Mission Mission(int Handle)
    {
        if (Handle != 0)
        {
            // 0x48 from https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/StatModules/HM3/Src/HM3/HM3Pointers.cpp
            int missionTime = Trainer.ReadPointerInteger(Handle, baseAddress + timePtr, new int[1] { 0x48 });
            Logger.Log($"mission time: {missionTime}");
            // order must match index values
            int[] stats = new int[] {
                // 0x6664 from https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/StatModules/HM3/Src/HM3/HM3Pointers.cpp
                Trainer.ReadPointerInteger(Handle, baseAddress + difficultyPtr, new int[1] { 0x6664 }),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetInnocentsKilled),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetInnocentsWounded),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetEnemiesKilled),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetEnemiesWounded),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetPoliceMenKilled),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetPoliceMenWounded),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetFriskFailed),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetCoverBlown),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetBodiesFound),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetTargetBodiesFound),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetUnconsciousBodiesFound),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetWitnesses),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetCameraCaught),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetCustomWeaponsLeftOnLevel),
                Trainer.ReadPointerInteger(Handle, baseAddress + statsPtr + offsetSuitLeftOnLevel)
            };
            return new Mission(0, "", missionTime / 1024.0F, stats, IsSilentAssassin(stats));
        }
        return null;
    }

    private bool IsSilentAssassin(int[] stats)
    {
        return CalculateRating0(stats) == 0 && CalculateRating1(stats) == 0;
    }

    private double CalculateScoreFor(int value, int unit)
    {
        return statsMultipliers[value >= 34 ? 33 : value] * unit;
    }

    private int CalculateRatingFromScore(double score)
    {
        return (int)Math.Ceiling((Math.Round(score > 100.0 ? 100.0 : score) / 100.0) * 6.0);
    }

    // https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/Statman/Engines/HM3/StatTracker.cs
    private int CalculateRating0(int[] stats)
    {
        return CalculateRatingFromScore(
            CalculateScoreFor(stats[indexInnocentsKilled], 12)
            + CalculateScoreFor(stats[indexInnocentsWounded], 6)
            + CalculateScoreFor(stats[indexEnemiesKilled], 6)
            + CalculateScoreFor(stats[indexEnemiesWounded], 3)
            + CalculateScoreFor(stats[indexPoliceKilled], 9)
            + CalculateScoreFor(stats[indexPoliceWounded], 5)
        );
    }

    // https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/Statman/Engines/HM3/StatTracker.cs
    private int CalculateRating1(int[] stats)
    {
        return CalculateRatingFromScore(
            CalculateScoreFor(stats[indexFriskFailed], 6)
            + CalculateScoreFor(stats[indexCoverBlown], 6)
            + CalculateScoreFor(stats[indexBodiesFound] + ((stats[indexDifficulty] > 1) ? stats[indexTargetBodiesFound] : 0), 6)
            + CalculateScoreFor(stats[indexUnconsciousBodiesFound], 6)
            + CalculateScoreFor(stats[indexWitnesses], 8)
            + CalculateScoreFor(stats[indexCaughtOnCamera], 10)
            + ((stats[indexDifficulty] > 2) ? CalculateScoreFor((stats[indexCustomWeaponsLeft] > 0) ? 1 : 0, 5) : 0)
            + ((stats[indexDifficulty] > 2) ? CalculateScoreFor(stats[indexSuitLeft], 5) : 0)
        );
    }
}
