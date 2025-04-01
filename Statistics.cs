using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Statistics {
    public int nbShotsFired = 0, nbCloseEncounters = 0, nbHeadshots = 0, nbAlerts = 0, nbEnemiesK = 0, nbEnemiesH = 0, nbInnocentsK = 0, nbInnocentsH = 0;

    // All the possible Silent Assassin combinations for Hitman 2
    // https://docs.google.com/spreadsheets/d/1i6dmzcBROqoJlsQjUGY8wxdqwxt2hXzjB9fPVggTf2k/edit?gid=1074822823#gid=1074822823
    readonly Statistics[] validSACombinationH2 = {
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
    readonly Statistics[] validSACombinationHC = {
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

    public Statistics(int sf, int ce, int hs, int al, int ek, int eh, int ik, int ih)
    {
        nbShotsFired = sf;
        nbCloseEncounters = ce;
        nbHeadshots = hs;
        nbAlerts = al;
        nbEnemiesK = ek;
        nbEnemiesH = eh;
        nbInnocentsK = ik;
        nbInnocentsH = ih;
    }

    public bool IsLessOrEqualTo(Statistics other)
    {
        return (
            nbShotsFired <= other.nbShotsFired
            && nbCloseEncounters <= other.nbCloseEncounters
            && nbHeadshots <= other.nbHeadshots
            && nbAlerts <= other.nbAlerts
            && nbEnemiesK <= other.nbEnemiesK
            && nbEnemiesH <= other.nbEnemiesH
            && nbInnocentsK <= other.nbInnocentsK
            && nbInnocentsH <= other.nbInnocentsH
        );
    }

    // Used to check if the actual rating is Silent Assassin
    public bool IsSilentAssassin(int gameNumber, int mapNumber)
    {
        if (gameNumber == 3 && mapNumber == 1 && nbCloseEncounters > 0)
        {
            // TODO correct this case (it is Asylum Aftermath)
            // see spreadsheet
            return false;
        }
        foreach (Statistics combination in ((gameNumber == 2) ? validSACombinationH2 : validSACombinationHC))
        {
            if (IsLessOrEqualTo(combination))
            {
                return true;
            }
        }
        return false;
    }

}
