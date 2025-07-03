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

    public async UniTask ChooseState()
    {
        while (CanChill)
        {
            int randomChoice = Random.Range(0, 3);
            print(randomChoice + gameObject.name);
            switch (randomChoice)
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
}
