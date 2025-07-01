using UnityEngine;
using static HumanEnum;

public class HumanRelation : MonoBehaviour
{
    [SerializeField][Range (0, 1)] private float _friendProba;
    [SerializeField][Range(0, 1)] private float _enemyProba;
    public static HumanRelation Instance;

    private void Awake() { Instance = this; }

    public HumanRelationResult ResultOfTalking()
    {
        float neutralProba = 1 - _friendProba - _enemyProba;
        float result = Random.Range(0, 1f);

        if (result < _enemyProba ) { return HumanRelationResult.Enemy; }

        else if (result > _friendProba + neutralProba) { return HumanRelationResult.Friend; }

        else { return HumanRelationResult.Neutral; }
    }
}
