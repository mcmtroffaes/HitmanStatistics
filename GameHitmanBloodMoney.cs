using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;

public class GameHitmanBloodMoney : IGame
{
    // steam addresses from https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/StatModules/HM3/Src/HM3/HM3Pointers.cpp
    private const int baseAddress = 0x00400000;
    private const int statsPtr = 0x005B2538;
    private const int gamedataPtr = 0x0041F83C;
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
    private readonly static Dictionary<int, string> difficultyMap = new Dictionary<int, string>()
    {
        { 0, "Rookie" },
        { 1, "Normal" },
        { 2, "Expert" },
        { 3, "Pro" }
    };

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

    public Tuple<string, Func<int, string>>[] StatisticsNames()
    {
        // order must match index values
        return new Tuple<string, Func<int, string>>[] {
            Tuple.Create("Difficulty", Utils.MapToString(difficultyMap)),
            Tuple.Create("Innocents Killed", Utils.ValueToString),
            Tuple.Create("Innocents Wounded", Utils.ValueToString),
            Tuple.Create("Enemies Killed", Utils.ValueToString),
            Tuple.Create("Enemies Wounded", Utils.ValueToString),
            Tuple.Create("Police Killed", Utils.ValueToString),
            Tuple.Create("Police Wounded", Utils.ValueToString),
            Tuple.Create("Frisk Failed", Utils.ValueToYesNo),
            Tuple.Create("Cover Blown", Utils.ValueToYesNo),
            Tuple.Create("Bodies Found", Utils.ValueToString),
            Tuple.Create("Target Bodies Fnd", Utils.ValueToString),
            Tuple.Create("Uncon Bodies Fnd", Utils.ValueToString),
            Tuple.Create("Witnesses", Utils.ValueToString),
            Tuple.Create("On Camera", Utils.ValueToYesNo),
            Tuple.Create("Cust Weapons Left", Utils.ValueToYesNo),
            Tuple.Create("Suit Left",  Utils.ValueToYesNo)
        };
    }

    public Mission Mission(int Handle)
    {
        if (Handle != 0)
        {
            // 0x48 from https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/StatModules/HM3/Src/HM3/HM3Pointers.cpp
            int missionTime = Trainer.ReadPointerInteger(Handle, baseAddress + timePtr, new int[1] { 0x48 });
            Logger.Log($"mission time: {missionTime}");
            // suit detection
            // https://github.com/OrfeasZ/Statman/blob/a3df06ca0f3004ec4117baaa41c05c90463053a3/StatModules/HM3/Src/HM3/Hooks/ZHM3LevelControl_FrameUpdate.cpp#L70
            // https://github.com/OrfeasZ/Statman/blob/a3df06ca0f3004ec4117baaa41c05c90463053a3/StatModules/HM3/Src/HM3/Structs/ZHM3GameData.h
            // https://github.com/OrfeasZ/Statman/blob/a3df06ca0f3004ec4117baaa41c05c90463053a3/StatModules/HM3/Src/HM3/Structs/ZHM3Actor.h#L857
            int current_suit = Trainer.ReadPointerInteger(Handle, baseAddress + gamedataPtr, new int[2] { 0x0A40, 0x0FD0 });
            int starting_suit = Trainer.ReadPointerInteger(Handle, baseAddress + gamedataPtr, new int[2] { 0x0A40, 0x0FD4 });
            int suit_left_on_level = (current_suit == starting_suit) ? 0 : 1;
            // order must match index values
            int[] stats = new int[] {
                // 0x6664 from https://github.com/OrfeasZ/Statman/blob/3f280f2fa5a2e2bdd18e15e0642c10cfcb3764f1/StatModules/HM3/Src/HM3/HM3Pointers.cpp
                Trainer.ReadPointerInteger(Handle, baseAddress + gamedataPtr, new int[1] { 0x6664 }),
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
                suit_left_on_level
            };
            return new Mission(0, "", missionTime / 1024.0F, stats, SilentAssassin(stats));
        }
        return null;
    }

    private int SilentAssassin(int[] stats)
    {
        bool items_left_on_map = stats[indexDifficulty] > 2 && (stats[indexCustomWeaponsLeft] != 0 || stats[indexSuitLeft] != 0);
        return (
            stats[indexInnocentsKilled] != 0
            || stats[indexInnocentsWounded] != 0
            || stats[indexEnemiesKilled] != 0
            || stats[indexPoliceKilled] != 0
            || stats[indexPoliceWounded] != 0
            || stats[indexFriskFailed] != 0
            || stats[indexCoverBlown] != 0
            || stats[indexBodiesFound] != 0
            || (stats[indexDifficulty] > 1 && stats[indexTargetBodiesFound] != 0)
            || stats[indexUnconsciousBodiesFound] != 0
            || stats[indexWitnesses] != 0
        ) ? 2 : items_left_on_map || (stats[indexCaughtOnCamera] != 0) ? 1 : 0;
    }
}
