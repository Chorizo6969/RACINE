using Cysharp.Threading.Tasks;
using UnityEngine;

public class NoJobGestion : MonoBehaviour
{
    [Header("Waiting after State")]
    [SerializeField] private int TimeAwaitAfterWander = 120;
    [SerializeField] private int TimeAwaitGoHome = 60;
    [SerializeField] private int TimeAwaitSitDown = 60;
    [HideInInspector] public bool CanChill;

    [Header("State reference")]
    [SerializeField] private RandomBallade _randomBalladeRef;
    [SerializeField] private HumanPlants _humanPlantsRef;
    [SerializeField] private SitAndChill _sitAndChillRef;

    [Header("State Probabilities")]
    [Range(0, 1)][SerializeField] private float _wanderProbability = 0.33f;
    [Range(0, 1)][SerializeField] private float _goHomeProbability = 0.33f;
    [Range(0, 1)][SerializeField] private float _sitProbability = 0.34f;

    public async UniTask ChooseState()
    {
        while (CanChill)
        {
            int choice = GetWeightedRandomChoice();
            switch (choice)
            {
                case 0:
                    _randomBalladeRef.StartWander();
                    await UniTask.Delay(TimeAwaitAfterWander * 1000);
                    _randomBalladeRef.StopWander();
                    break;
                case 1:
                    await _humanPlantsRef.BackHome();
                    await UniTask.Delay(TimeAwaitGoHome * 1000);
                    break;
                case 2:
                    _sitAndChillRef.SitDownAndChill();
                    await UniTask.Delay(TimeAwaitSitDown * 1000);
                    break;
            }
        }
    }

    private int GetWeightedRandomChoice()
    {
        float total = _wanderProbability + _goHomeProbability + _sitProbability;
        float random = Random.Range(0, total);
        if (random < _wanderProbability) return 0;
        if (random < _wanderProbability + _goHomeProbability) return 1;
        return 2;
    }
}
