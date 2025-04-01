class SilentAssassin
{
    // All the possible Silent Assassin combinations for Hitman 2
    // https://docs.google.com/spreadsheets/d/1i6dmzcBROqoJlsQjUGY8wxdqwxt2hXzjB9fPVggTf2k/edit?gid=1074822823#gid=1074822823
    private static readonly Statistics[] validSACombinationH2 = {
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

    // All the possible Silent Assassin combinations for Hitman Contracts
    // https://docs.google.com/spreadsheets/d/1JgNscwEak6pR5qMcUzjRlGh34IG4aZJ6id9V8rahL18/edit?gid=1089548412#gid=1089548412
    private static readonly Statistics[] validSACombinationHC = {
        new Statistics(999, 0, 999, 1, 0, 0, 0, 0),
        new Statistics(2, 1, 1, 0, 0, 0, 0, 0),
        new Statistics(2, 1, 0, 0, 0, 1, 0, 0),
        new Statistics(2, 0, 1, 1, 0, 1, 0, 0),
        new Statistics(2, 0, 0, 0, 0, 2, 0, 0),
        new Statistics(1, 1, 1, 0, 0, 2, 0, 0),
        new Statistics(1, 1, 0, 0, 1, 0, 0, 0),
        new Statistics(1, 1, 0, 0, 0, 3, 0, 0),
        new Statistics(1, 0, 1, 1, 1, 0, 0, 0),
        new Statistics(1, 0, 1, 1, 0, 3, 0, 0),
        new Statistics(1, 0, 0, 1, 1, 1, 0, 0),
        new Statistics(1, 0, 0, 1, 0, 4, 0, 0),
        new Statistics(0, 1, 0, 0, 1, 2, 0, 0),
        new Statistics(0, 1, 0, 0, 0, 5, 0, 0),
        new Statistics(0, 0, 0, 1, 1, 3, 0, 0),
        new Statistics(0, 0, 0, 1, 2, 0, 0, 0),
        new Statistics(0, 0, 0, 1, 0, 6, 0, 0)
    };
    private static readonly Statistics[] validSACombinationHCMap1 = {
        new Statistics(999, 0, 0, 1, 0, 0, 0, 0),
        new Statistics(2, 0, 0, 0, 0, 2, 0, 0),
        new Statistics(1, 0, 1, 1, 1, 0, 0, 0),
        new Statistics(1, 0, 0, 1, 1, 1, 0, 0),
        new Statistics(1, 0, 0, 1, 0, 4, 0, 0),
        new Statistics(0, 0, 0, 1, 1, 3, 0, 0),
        new Statistics(0, 0, 0, 1, 2, 0, 0, 0),
        new Statistics(0, 0, 0, 1, 0, 6, 0, 0)
    };

    public static bool IsSilentAssassin(int gameNumber, int mapNumber, Statistics stats)
    {
        foreach (Statistics combination in ((gameNumber == 2) ? validSACombinationH2 : ((mapNumber != 1) ? validSACombinationHC : validSACombinationHCMap1)))
        {
            if (stats.IsLessOrEqualTo(combination))
            {
                return true;
            }
        }
        return false;
    }
}
