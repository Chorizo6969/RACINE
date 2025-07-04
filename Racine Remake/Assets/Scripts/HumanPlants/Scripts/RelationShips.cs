using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;
using static HumanEnum;
using System.Threading.Tasks;

public class RelationShips : MonoBehaviour
{
    [Header("Relation")]
    [SerializeField] private RelationShips _friends;
    [SerializeField] private RelationShips _enemy;

    [Header("Zone de discussion")]
    [SerializeField] private Bounds _talkingLimits;

    [Header("Param�tres de d�placement")]
    [SerializeField] private int _walkDelayMax = 8;

    [Header("Param�tres de d�tection")]
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private LayerMask _villagerMask;

    private NavMeshAgent _agent;
    private bool _canTalk;
    [HideInInspector] public bool IsTalking;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        TimeInGame.Instance.OnStartDiscuss += GoTalk;
    }

    public void GoTalk()
    {
        _canTalk = true;
        IsTalking = false;
        Debug.Log("Il faut papoter !");
        WanderRoutine().Forget();
        LookForSomeoneRoutine().Forget();
    }

    private async UniTaskVoid WanderRoutine()
    {
        while (_canTalk && !IsTalking)
        {
            Vector3 randomDirection = GetBoundsPoint();
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            {
                _agent.SetDestination(hit.position);
            }
            await UniTask.Delay(Random.Range(1, _walkDelayMax) * 1000);
        }
    }

    private async UniTaskVoid LookForSomeoneRoutine()
    {
        await UniTask.Delay(3000);
        while (_canTalk && !IsTalking)
        {
            RelationShips target = FindAvailableVillager();
            if (target != null)
            {
                StartConversationWith(target);
                break;
            }

            await UniTask.Yield(); // Check toutes les secondes
        }
        print("stop");
    }

    private Vector3 GetBoundsPoint()
    {
        Vector3 randomPoint = new Vector3(Random.Range(_talkingLimits.min.x, _talkingLimits.max.x), _talkingLimits.center.y , Random.Range(_talkingLimits.min.z, _talkingLimits.max.z));
        return randomPoint;
    }

    private RelationShips FindAvailableVillager()
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

    private void StartConversationWith(RelationShips other)
    {
        _canTalk = false;
        IsTalking = true;
        other.IsTalking = true;

        _agent.ResetPath();
        other._agent.ResetPath();

        LookAtSmoothly(other.transform).Forget();
        other.LookAtSmoothly(transform).Forget();

        Debug.Log($"{name} parle avec {other.name}");

        switch (HumanRelation.Instance.ResultOfTalking())
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

    private async UniTaskVoid LookAtSmoothly(Transform target)
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

    private void EndConversation() 
    {
        _canTalk = false;
        IsTalking = false;
        //dodo � lancer plus t�t
        this.gameObject.GetComponent<HumanPlants>().BackHome().Forget();
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