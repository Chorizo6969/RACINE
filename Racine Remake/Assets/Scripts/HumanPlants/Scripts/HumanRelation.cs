using UnityEngine;
using static HumanEnum;

public class HumanRelation : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float _friendProba = 0.3f;
    [SerializeField][Range(0, 1)] private float _enemyProba = 0.2f;
    public static HumanRelation Instance;

    private void Awake() { Instance = this; }

    public HumanRelationResult ResultOfTalking()
    {
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
