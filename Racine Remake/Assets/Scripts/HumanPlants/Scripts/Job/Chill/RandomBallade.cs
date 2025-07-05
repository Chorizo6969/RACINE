using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class RandomBallade : MonoBehaviour
{
    private NavMeshAgent _agent;

    [Header("Wandering Settings")]
    [SerializeField] private float _wanderRadius = 25;
    [SerializeField] private int _wanderInterval;
    private bool _isWander;

    public void Start() 
    { 
        _agent = this.gameObject.GetComponentInParent<NavMeshAgent>();
    }

    private void StartChomage() { WanderRoutine().Forget(); } //A 11h il commence la journée

    private async UniTask WanderRoutine()
    {
        while (_isWander)
        {
            if(!this.gameObject.GetComponent<NoJobGestion>().CanChill) { _isWander = false; }
            GetRandomPath();
            _wanderInterval = Random.Range(0, 15);
            await UniTask.Delay(_wanderInterval * 1000);
        }
    }

    private void GetRandomPath()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _wanderRadius;
        randomDirection += _agent.gameObject.transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _wanderRadius, NavMesh.AllAreas) && this.gameObject.GetComponent<NoJobGestion>().CanChill)
        {
            _agent.SetDestination(hit.position);
        }
    }

    public void StopWander() 
    {
        _isWander = false;
        _agent.ResetPath();
    }

    public void StartWander() 
    {
        _isWander = true;
        StartChomage();
    }
}
