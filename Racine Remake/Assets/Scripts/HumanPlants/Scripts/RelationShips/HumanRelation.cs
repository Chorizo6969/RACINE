using UnityEngine;
using static HumanEnum;

/// <summary>
/// Script qui gère le résultat d'une intéraction entre 2 humains plantes (Fonction : ResultOfTalking())
/// </summary>
public class HumanRelation : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float _friendProba;
    [SerializeField][Range(0, 1)] private float _enemyProba;
    public static HumanRelation Instance;

    private void Awake() { Instance = this; }

    //IMPORTANT : POUR L'INSTANT, DEFENSEUR ET KEKE VONT JUSTE AVOIR PLUS DE CHANCE D'ETRE ENNEMIE !!!

    /// <summary>
    /// Fonction qui retourne le résultat de l'interaction
    /// </summary>
    /// <returns> Enum HumanRelationResult (Ami neutral, Enemy) </returns>
    public HumanRelationResult ResultOfTalking(Stats Mystats, Stats Otherstats)
    {
        _enemyProba += Mystats.FightingProba + Otherstats.FightingProba;
        float total = _friendProba + _enemyProba;
        float neutralProba = Mathf.Clamp01(1f - total);

        float rand = Random.Range(0f, 1f);
        print(rand);
        if (rand < _enemyProba)
        {
            return HumanRelationResult.Enemy;
        }
        else if (rand < _enemyProba + neutralProba)
        {
            return HumanRelationResult.Neutral;
        }
        else
        {
            return HumanRelationResult.Friend;
        }
    }
}
