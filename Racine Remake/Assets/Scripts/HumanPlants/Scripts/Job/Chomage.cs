using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Chomage : MonoBehaviour
{
    private NavMeshAgent _agent;

    [Header("Wandering Settings")]
    [SerializeField] private float _wanderRadius = 25;
    [SerializeField] private int _wanderInterval;

    private void Start()
    {
        _agent = this.gameObject.GetComponent<NavMeshAgent>();
        WanderRoutine().Forget();
    }

    private async UniTask WanderRoutine()
    {
        while (true)
        {
            GetRandomPath();
            _wanderInterval = Random.Range(0, 15);
            await UniTask.Delay(_wanderInterval * 1000);
        }
    }

    private void Goto(Vector3 targetPosition)
    {
        _agent.SetDestination(targetPosition);
    }

    private void GetRandomPath()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _wanderRadius;
        randomDirection += transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _wanderRadius, NavMesh.AllAreas))
        {
            Goto(hit.position);
        }
    }
}
