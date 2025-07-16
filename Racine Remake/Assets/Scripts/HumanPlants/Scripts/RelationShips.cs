using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;
using static HumanEnum;

/// <summary>
/// Classe Majeure qui gère les rencontres entre humains plantes
/// </summary>
public class RelationShips : MonoBehaviour
{
    [Header("Relation")]
    [SerializeField] private HumanPlants _humanPlantsRef;
    [SerializeField] private RelationShips _friends;
    [SerializeField] private RelationShips _enemy;

    [Header("Zone de discussion")]
    [SerializeField] private Bounds _talkingLimits; //Centre du village ou à lieu les discussions

    [Header("Paramètres de déplacement")]
    [SerializeField] private int _walkDelayMax = 8;

    [Header("Paramètres de détection")]
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private LayerMask _villagerMask;
    private Collider[] _results = new Collider[10];

    private bool _canTalk;
    [HideInInspector] public bool IsTalking;

    private void Start()
    {
        TimeInGame.Instance.OnStartDiscuss += SetupTalkingProces;
    }

    public void SetupTalkingProces()
    {
        if(_humanPlantsRef.StatsRef.IsSick || _humanPlantsRef.StatsRef.IsFakeSick) { return; }

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
                _humanPlantsRef.HumanMotorsRef.GoTo(hit.position);
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
        int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _detectionRadius, _results, _villagerMask);
        for (int i = 0; i < hitCount; i++)
        {
            if (_results[i].gameObject == this.gameObject) continue;

            RelationShips other = _results[i].GetComponent<RelationShips>();
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

        _humanPlantsRef.HumanMotorsRef.Agent.ResetPath();
        other._humanPlantsRef.HumanMotorsRef.Agent.ResetPath();

        LookAtSmoothly(other.transform).Forget();
        other.LookAtSmoothly(transform).Forget();

        Debug.Log($"{name} parle avec {other.name}");

        switch (HumanRelation.Instance.ResultOfTalking(_humanPlantsRef.StatsRef, other._humanPlantsRef.StatsRef)) //résultat de l'interaction
        {
            case HumanRelationResult.Friend:
                _friends = other;
                other._friends = this;
                break;
            case HumanRelationResult.Enemy:
                _enemy = other;
                other._enemy = this;
                break;
        }

        Invoke(nameof(EndConversation), 20); //Lance EndConv dans 20s
        other.Invoke(nameof(other.EndConversation), 20);
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
        _humanPlantsRef.BackHome().Forget();
    }

    public void VerifTalking()
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