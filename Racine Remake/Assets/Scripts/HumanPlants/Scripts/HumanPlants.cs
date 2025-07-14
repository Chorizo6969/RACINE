using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe majeure, gère le retour à la maison pour dormir et liens vers d'autres scripts
/// </summary>
public class HumanPlants : MonoBehaviour
{
    [Header("OtherDomain")]
    public Personality HumanPersonality;
    public Job HumanJob;
    public RelationShips HumanRelationShips;
    public NoJobGestion HumanNoJobGestion;
    public HumanMotors HumanMotorsRef;

    [Header("Others")]
    public Stats StatsRef;
    public Transform Maison;

    [Header("First Job")]
    [SerializeField] private HumanJobSO _firstJob;

    private async void Start()
    {
        TimeInGame.Instance.OnStartSleep += StartSleep;

        HumanJob.CurrentJob = _firstJob;
        await BackHome();
    }

    private async void StartSleep() { HumanRelationShips.VerifTalking(); await BackHome(); }

    public async UniTask BackHome() //temporaire
    {
        print("Je retourne à la maison");
        while(HumanRelationShips.IsTalking)
        {
            await UniTask.Yield();
        }

        //_agent.enabled = true;
        HumanMotorsRef.GoTo(Maison.gameObject);
        while (Vector3.Distance(gameObject.transform.position, Maison.position) > HumanMotorsRef.Agent.stoppingDistance + 1.7f)
        {
            await UniTask.Yield();
        }
        StatsRef.IsHome = true;
        await UniTask.Delay(3000);
    }
}
