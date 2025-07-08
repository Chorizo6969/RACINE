using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe qui fait retourner l'humain plante chez lui.
/// </summary>
public class BackHouseForChill : MonoBehaviour
{
    private Transform _maison;
    private NavMeshAgent _agent;
    [SerializeField] private Stats _stats;

    public void Start()
    {
        _maison = this.gameObject.GetComponentInParent<HumanPlants>().Maison;
        _agent = this.gameObject.GetComponentInParent<NavMeshAgent>();
    }

    public async UniTask BackHome()
    {
        print("je vais chill chez moi");
        _agent.SetDestination(_maison.position);
        while (Vector3.Distance(_agent.transform.position, _maison.position) > _agent.stoppingDistance + 1.7f)
        {
            await UniTask.Yield();
        }
        _stats.IsHome = true;
    }
}