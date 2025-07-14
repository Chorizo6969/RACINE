using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe qui fait en sorte que l'humain plante se ballade de manière aléatoire dans la map
/// </summary>
public class RandomBallade : NoJobGestion
{
    [Header("Wandering Settings")]
    [SerializeField] private float _wanderRadius = 25;
    [SerializeField] private int _wanderInterval;
    private bool _isWander;

    private void StartChomage() { WanderRoutine().Forget(); } //A 11h il commence la journée

    private async UniTask WanderRoutine()
    {
        while (_isWander)
        {
            GetRandomPath();
            _wanderInterval = Random.Range(0, 15);
            await UniTask.Delay(_wanderInterval * 1000);
        }
    }

    private void GetRandomPath()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _wanderRadius;
        randomDirection += _humanPlants.gameObject.transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _wanderRadius, NavMesh.AllAreas))
        {
            _humanPlants.HumanMotorsRef.GoTo(hit.position);
            _humanPlants.StatsRef.IsHome = false;
        }
    }

    public void StopWander() 
    {
        _isWander = false;
        _humanPlants.HumanMotorsRef.Agent.ResetPath();
    }

    public void StartWander() 
    {
        _isWander = true;
        StartChomage();
    }
}
