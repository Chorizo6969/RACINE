/// <summary>
/// Classe static de tout les enums des humains plantes (Jobs, JobType, Personality, RelationShips)
/// </summary>
public static class HumanEnum
{
    public enum HumanJobs
    {
        Ch�meur,
        Constructeur,
        Explorateur,
        B�cheron,
        R�colteurEau,
        Mineur,
        Planteur,
        M�decin,
        Chevalier,
        Archer,
        Cavalier
    }

    public enum HumanJobType
    {
        R�colteur,
        D�fense,
        Ponctuelle
    }

    public enum HumanPersonality
    {
        Ralentit,
        Maigrichon,
        T�teEnAir,
        Surpoids,
        K�k�,
        Fain�ant,
        MouDuBulbe,
        PeurDesCh�vres,
        Laxatif,
        Narcoleptique,
        FanDeCrotte,
        CriePourRien,
        Z�l�,
        Crapophage,
        MoteurFeuillu,
        BonVivant,
        DoigtsDeRacine,
        Constip�,
        Survivaliste
    }

    public enum HumanPersonalityEffect
    {
        EfficiencyWorking,
        WiningRessourcesRatio,
        ForgetRessourcesProba,
        SpeedHuman,
        FightingProba,
        SickProba,
        PoopSpeed,
        TimeBeforeOrder,
        IsScared,
        IsNarcoleptique,
        CleanPoop,
        FixeCaca,
        BuffAudioValue,
        HappinessFlat
    }

    public enum HumanPersonalityMaths
    {
        Add,
        Bool
    }


    public enum HumanRelationResult
    {
        Friend,
        Neutral,
        Enemy
    }

}
