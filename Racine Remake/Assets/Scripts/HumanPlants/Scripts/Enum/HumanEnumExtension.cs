using System.Collections.Generic;

public static class HumanEnumExtensions
{
    public static readonly Dictionary<HumanEnum.HumanJobs, string> DefaultJobDescriptions = new()
    {
        { HumanEnum.HumanJobs.Chômeur, "Ne fait rien du tout." },
        { HumanEnum.HumanJobs.Constructeur, "Construit des bâtiments pour la colonie." },
        { HumanEnum.HumanJobs.Explorateur, "Explore les alentours à la recherche de ressources." },
        { HumanEnum.HumanJobs.Bûcheron, "Coupe du bois pour la construction." },
        { HumanEnum.HumanJobs.RécolteurEau, "Cherche de l'eau potable." },
        { HumanEnum.HumanJobs.Mineur, "Extrait des minerais dans la mine." },
        { HumanEnum.HumanJobs.Planteur, "Plante des graines pour produire des arbres." },
        { HumanEnum.HumanJobs.Médecin, "Soigne les blessés et permet de dénicher les faux malades." },
        { HumanEnum.HumanJobs.Chevalier, "Protège le village des chèvres." },
        { HumanEnum.HumanJobs.Archer, "Assure la défense à distance." },
        { HumanEnum.HumanJobs.Cavalier, "Patrouille rapidement autour du camp sur son fidèle destrier." },
    };

    public static readonly Dictionary<HumanEnum.HumanPersonality, string> DefaultPersonalityDescriptions = new()
    {
        { HumanEnum.HumanPersonality.Ralentit, "Met 50% de temps en plus lors d'une récolte ou d'une construction." },
        { HumanEnum.HumanPersonality.Maigrichon, "Rapporte 50% de ressources en moins." },
        { HumanEnum.HumanPersonality.TêteEnAir, "Perd parfois les ressources qu'il transporte (25% de chance)." },
        { HumanEnum.HumanPersonality.Surpoids, "Marche 75% moins vite." },
        { HumanEnum.HumanPersonality.Kéké, "A tendance à chercher la bagarre." },
        { HumanEnum.HumanPersonality.Fainéant, "Feint d'être malade plus souvent." },
        { HumanEnum.HumanPersonality.MouDuBulbe, "Met 10 secondes de plus à comprendre les ordres." },
        { HumanEnum.HumanPersonality.PeurDesChèvres, "Fuit automatiquement s'il y a une attaque ennemie, même s'il est combattant." },
        { HumanEnum.HumanPersonality.Laxatif, "Fait caca plus souvent." },
        { HumanEnum.HumanPersonality.FanDeCrotte, "Se bloque devant une crotte et refuse d'avancer tant qu'elle n'est pas ramassée." },
        { HumanEnum.HumanPersonality.Narcoleptique, "Peut s'endormir à n'importe quel moment de la journée." },
        { HumanEnum.HumanPersonality.CriePourRien, "Hurle parfois sans aucune raison." },
        { HumanEnum.HumanPersonality.Zélé, "Travaille 15% plus vite que la moyenne." },
        { HumanEnum.HumanPersonality.Crapophage, "Ramasse les crottes automatiquement quand il passe à côté." },
        { HumanEnum.HumanPersonality.MoteurFeuillu, "Marche 50% plus vite." },
        { HumanEnum.HumanPersonality.BonVivant, "Augmente la jauge de bonheur ." },
        { HumanEnum.HumanPersonality.DoigtsDeRacine, "Récolte +20% de ressources." },
        { HumanEnum.HumanPersonality.Constipé, "Ne fait jamais caca !" },
        { HumanEnum.HumanPersonality.Survivaliste, "Ne peut pas mourir." },
    };
}
