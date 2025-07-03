using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class HumanPlants : MonoBehaviour
{
    [Header("OtherDomain")]
    public Personality HumanPersonality;
    public Job HumanJob;
    public RelationShips HumanRelationShips;

    public Transform Maison;

    [Header("First Job")]
    [SerializeField] private HumanJobSO _firstJob;

    private void Start()
    {
        TimeInGame.Instance.OnStartSleep += StartSleep;
        HumanJob.CurrentJob = _firstJob;
    }

    private async void StartSleep() { print("Dodo..."); await BackHome(); }

    public async UniTask BackHome()
    {
        print("Je retorune à la maison");
        //temporaire
        NavMeshAgent agent = this.gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(Maison.position);
        while (Vector3.Distance(agent.transform.position, Maison.position) > agent.stoppingDistance + 1.7f)
        {
            await UniTask.Yield();
        }
        await Task.Delay(3000);
    }
}
