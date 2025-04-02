public class Statistics {
    public readonly int nbShotsFired;
    public readonly int nbCloseEncounters;
    public readonly int nbHeadshots;
    public readonly int nbAlerts;
    public readonly int nbEnemiesK;
    public readonly int nbEnemiesH;
    public readonly int nbInnocentsK;
    public readonly int nbInnocentsH;

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

    public override string ToString()
    {
        return $"sf={nbShotsFired} ce={nbCloseEncounters} hs={nbHeadshots} al={nbAlerts} ek={nbEnemiesH} eh={nbEnemiesH} ik={nbInnocentsK} ih={nbInnocentsH}";
    }
}
