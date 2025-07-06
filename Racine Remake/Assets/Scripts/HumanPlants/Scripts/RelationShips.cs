using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;
using static HumanEnum;

public class RelationShips : MonoBehaviour
{
    [Header("Relation")]
    [SerializeField] private RelationShips _friends;
    [SerializeField] private RelationShips _enemy;

    [Header("Zone de discussion")]
    [SerializeField] private Bounds _talkingLimits;

    [Header("Paramètres de déplacement")]
    [SerializeField] private int _walkDelayMax = 8;

    [Header("Paramètres de détection")]
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private LayerMask _villagerMask;

    [SerializeField] private NavMeshAgent _agent;
    private bool _canTalk;
    [HideInInspector] public bool IsTalking;

    private void Start()
    {
        TimeInGame.Instance.OnStartDiscuss += GoTalk;
        TimeInGame.Instance.OnStartSleep += VerifTalking;
    }

    public void GoTalk()
    {
        _canTalk = true;
        IsTalking = false;
        WanderRoutine().Forget();
        LookForSomeoneRoutine().Forget();
    }

    private async UniTaskVoid WanderRoutine() //On patrouille en quête d'humain
    {
        while (_canTalk && !IsTalking)
        {
            Vector3 randomDirection = new Vector3(Random.Range(_talkingLimits.min.x, _talkingLimits.max.x), _talkingLimits.center.y, Random.Range(_talkingLimits.min.z, _talkingLimits.max.z));
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            {
                _agent.SetDestination(hit.position);
            }
            await UniTask.Delay(Random.Range(1, _walkDelayMax) * 1000);
        }
    }

    private async UniTaskVoid LookForSomeoneRoutine() //Routine de blabla
    {
        await UniTask.Delay(3000); //Pour éviter un spawnkill de discution
        while (_canTalk && !IsTalking)
        {
            RelationShips target = FindAvailableVillager();
            if (target != null)
            {
                StartConversationWith(target);
                break;
            }
            await UniTask.Yield();
        }
    }

    private RelationShips FindAvailableVillager() //On cherche à attraper un humain qui passe
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _detectionRadius, _villagerMask);
        foreach (Collider hit in hits)
        {
            if (hit.gameObject == this.gameObject) continue;

            RelationShips other = hit.GetComponent<RelationShips>();
            if (other != null && !other.IsTalking && other._canTalk)
                return other;
        }

        return null;
    }

    private void StartConversationWith(RelationShips other) //dialogue entre les 2
    {
        _canTalk = false;
        IsTalking = true;
        other.IsTalking = true;

        _agent.ResetPath();
        other._agent.ResetPath();

        LookAtSmoothly(other.transform).Forget();
        other.LookAtSmoothly(transform).Forget();

        Debug.Log($"{name} parle avec {other.name}");

        switch (HumanRelation.Instance.ResultOfTalking()) //résultat de l'interaction
        {
            case HumanRelationResult.Friend:
                _friends = other;
                other._friends = this.gameObject.GetComponent<RelationShips>();
                break;
            case HumanRelationResult.Enemy:
                _enemy = other;
                other._enemy = this.gameObject.GetComponent<RelationShips>();
                break;
        }

        Invoke(nameof(EndConversation), 20); //Lance EndConv dans 20s
        other.Invoke(nameof(other.EndConversation), 20);
        _agent.enabled = false;
    }

    private async UniTaskVoid LookAtSmoothly(Transform target) //Se tourne vers son pote
    {
        float duration = 0.5f;
        float elapsed = 0f;

        Quaternion startRot = transform.rotation;
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        Quaternion targetRot = Quaternion.LookRotation(direction);

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRot, targetRot, elapsed / duration);
            elapsed += Time.deltaTime;
            await UniTask.Yield();
        }

        transform.rotation = targetRot;
    }

    private void EndConversation() //dodo à lancer plus tôt
    {
        _canTalk = false;
        IsTalking = false;
        this.gameObject.GetComponent<HumanPlants>().BackHome().Forget();
    }

    private void VerifTalking()
    {
        if (IsTalking) { return; }
        EndConversation();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(_talkingLimits.center, _talkingLimits.size);
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
#endif
}