using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Chomage : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] private HumanJobSO _jobSO;

    [Header("Wandering Settings")]
    [SerializeField] private float _wanderRadius = 25;
    [SerializeField] private int _wanderInterval;

    public static Chomage Instance;

    private void Awake() { Instance = this; }

    private void Start() { TimeInGame.Instance.OnStartChomeur += StartChomage; }

    public void SetupAgent(GameObject go) 
    { 
        _agent = go.GetComponent<NavMeshAgent>();
        go.GetComponent<Job>().CurrentJob = _jobSO;
    }

    private void StartChomage() { WanderRoutine().Forget(); } //A 11h il commence la journée

    private async UniTask WanderRoutine()
    {
        while (_agent.GetComponent<Job>().IsJobing)
        {
            GetRandomPath();
            _wanderInterval = Random.Range(0, 15);
            await UniTask.Delay(_wanderInterval * 1000);
        }
    }

    private void GetRandomPath()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _wanderRadius;
        randomDirection += _agent.gameObject.transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _wanderRadius, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.position);
        }
    }
}
