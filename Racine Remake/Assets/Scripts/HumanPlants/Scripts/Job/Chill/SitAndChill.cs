using UnityEngine;
using UnityEngine.AI;

public class SitAndChill : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    public void SitDownAndChill()
    {
        _agent.ResetPath();
    }
}
