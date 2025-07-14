using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Script qui gère les mouvements de l'humains plantes
/// </summary>
public class HumanMotors : MonoBehaviour
{
    public NavMeshAgent Agent;
    private float _agentSpeed;

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
}
