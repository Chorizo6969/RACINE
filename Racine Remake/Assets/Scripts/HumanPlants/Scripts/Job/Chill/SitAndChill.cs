using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe qui fait en sorte que l'humain plante regarde autour de lui pendant un moment
/// </summary>
public class SitAndChill : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = this.gameObject.GetComponentInParent<NavMeshAgent>();
    }

    public void SitDownAndChill()
    {
        _agent.ResetPath();
    }
}
