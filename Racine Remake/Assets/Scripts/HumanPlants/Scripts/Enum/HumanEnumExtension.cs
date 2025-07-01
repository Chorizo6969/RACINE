using System.Collections.Generic;

public static class HumanEnumExtensions
{
    public static readonly Dictionary<HumanEnum.HumanJobs, string> DefaultJobDescriptions = new()
    {
        { HumanEnum.HumanJobs.Ch�meur, "Ne fait rien du tout." },
        { HumanEnum.HumanJobs.Constructeur, "Construit des b�timents pour la colonie." },
        { HumanEnum.HumanJobs.Explorateur, "Explore les alentours � la recherche de ressources." },
        { HumanEnum.HumanJobs.B�cheron, "Coupe du bois pour la construction." },
        { HumanEnum.HumanJobs.R�colteurEau, "Cherche de l'eau potable." },
        { HumanEnum.HumanJobs.Mineur, "Extrait des minerais dans la mine." },
        { HumanEnum.HumanJobs.Planteur, "Plante des graines pour produire des arbres." },
        { HumanEnum.HumanJobs.M�decin, "Soigne les bless�s et permet de d�nicher les faux malades." },
        { HumanEnum.HumanJobs.Chevalier, "Prot�ge le village des ch�vres." },
        { HumanEnum.HumanJobs.Archer, "Assure la d�fense � distance." },
        { HumanEnum.HumanJobs.Cavalier, "Patrouille rapidement autour du camp sur son fid�le destrier." },
    };

    public static readonly Dictionary<HumanEnum.HumanPersonality, string> DefaultPersonalityDescriptions = new()
    {
        { HumanEnum.HumanPersonality.Ralentit, "Met 50% de temps en plus lors d'une r�colte ou d'une construction." },
        { HumanEnum.HumanPersonality.Maigrichon, "Rapporte 50% de ressources en moins." },
        { HumanEnum.HumanPersonality.T�teEnAir, "Perd parfois les ressources qu'il transporte (25% de chance)." },
        { HumanEnum.HumanPersonality.Surpoids, "Marche 75% moins vite." },
        { HumanEnum.HumanPersonality.K�k�, "A tendance � chercher la bagarre." },
        { HumanEnum.HumanPersonality.Fain�ant, "Feint d'�tre malade plus souvent." },
        { HumanEnum.HumanPersonality.MouDuBulbe, "Met 10 secondes de plus � comprendre les ordres." },
        { HumanEnum.HumanPersonality.PeurDesCh�vres, "Fuit automatiquement s'il y a une attaque ennemie, m�me s'il est combattant." },
        { HumanEnum.HumanPersonality.Laxatif, "Fait caca plus souvent." },
        { HumanEnum.HumanPersonality.FanDeCrotte, "Se bloque devant une crotte et refuse d'avancer tant qu'elle n'est pas ramass�e." },
        { HumanEnum.HumanPersonality.Narcoleptique, "Peut s'endormir � n'importe quel moment de la journ�e." },
        { HumanEnum.HumanPersonality.CriePourRien, "Hurle parfois sans aucune raison." },
        { HumanEnum.HumanPersonality.Z�l�, "Travaille 15% plus vite que la moyenne." },
        { HumanEnum.HumanPersonality.Crapophage, "Ramasse les crottes automatiquement quand il passe � c�t�." },
        { HumanEnum.HumanPersonality.MoteurFeuillu, "Marche 50% plus vite." },
        { HumanEnum.HumanPersonality.BonVivant, "Augmente la jauge de bonheur ." },
        { HumanEnum.HumanPersonality.DoigtsDeRacine, "R�colte +20% de ressources." },
        { HumanEnum.HumanPersonality.Constip�, "Ne fait jamais caca !" },
        { HumanEnum.HumanPersonality.Survivaliste, "Ne peut pas mourir." },
    };
}
