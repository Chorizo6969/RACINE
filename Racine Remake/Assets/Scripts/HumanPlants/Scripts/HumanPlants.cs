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

    [Header("Others")]
    [SerializeField] private Stats _stats;
    private NavMeshAgent _agent;
    public Transform Maison;

    [Header("First Job")]
    [SerializeField] private HumanJobSO _firstJob;

    private async void Start()
    {
        TimeInGame.Instance.OnStartSleep += StartSleep;

        _agent = this.gameObject.GetComponent<NavMeshAgent>();
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

        _agent.enabled = true;
        _agent.SetDestination(Maison.position);

        while (Vector3.Distance(_agent.transform.position, Maison.position) > _agent.stoppingDistance + 1.7f)
        {
            await UniTask.Yield();
        }
        _stats.IsHome = true;
        await UniTask.Delay(3000);
    }
}
