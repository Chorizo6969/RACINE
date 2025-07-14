using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Script qui gère les mouvements de l'humains plantes
/// </summary>
public class HumanMotors : MonoBehaviour
{
    public NavMeshAgent Agent;
    private float _agentSpeed;

    private void Start()
    {
        _agentSpeed = Agent.speed;
    }

    public void GoTo(GameObject go)
    {
        Agent.SetDestination(go.transform.position);
    }

    public void GoTo(Vector3 position)
    {
        Agent.SetDestination(position);
    }

    public void StopMoveAgent()
    {
        _agentSpeed = Agent.speed;
        Agent.speed = 0;
    }

    public void CanMoveAgent()
    {
        Agent.speed = _agentSpeed;
    }

    public async UniTask PickupUpPoop(GameObject go, CancellationToken token)
    {
        StopMoveAgent();
        GoTo(go);
        //anim rammase caca
        await UniTask.Delay(3000, cancellationToken: token);
        Destroy(go);
        CanMoveAgent();
    }
}
