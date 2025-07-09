using UnityEngine;
using static HumanEnum;

/// <summary>
/// Script qui g�re le r�sultat d'une int�raction entre 2 humains plantes (Fonction : ResultOfTalking())
/// </summary>
public class HumanRelation : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float _friendProba = 0.3f;
    [SerializeField][Range(0, 1)] private float _enemyProba = 0.2f;
    public static HumanRelation Instance;

    private void Awake() { Instance = this; }

    /// <summary>
    /// Fonction qui retourne le r�sultat de l'interaction
    /// </summary>
    /// <returns> Enum HumanRelationResult (Ami neutral, Enemy) </returns>
    public HumanRelationResult ResultOfTalking(/*Stats stats*/)
    {
        //_enemyProba = stats.FightingProba;
        float total = _friendProba + _enemyProba;
        float neutralProba = Mathf.Clamp01(1f - total);

        float rand = Random.Range(0f, 1f);

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
