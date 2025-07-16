using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe qui va détecter les caca et réagir en conséquence (fixe ou nettoyage)
/// </summary>
public class PoopDetector : MonoBehaviour, IPersonalitySetup
{
    private CancellationTokenSource _poopCTS; //les tokens servent à tout arrêter en cas de pépin

    [SerializeField] private HumanPlants _humanPlants;

    private bool _craphophage;
    private bool _fanDeCrotte;
    private Collider[] _results = new Collider[10];

    [Header("Paramètres de détection")]
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private LayerMask _poopMask;

    private void Start()
    {
        TimeInGame.Instance.OnStartWork += StartDetection;
        TimeInGame.Instance.OnStartSleep += StopDetection;
    }

    public void StartDetection()
    {
        _craphophage = _humanPlants.StatsRef.CleanPoop;
        _fanDeCrotte = _humanPlants.StatsRef.FixeCaca;

        _poopCTS = new CancellationTokenSource();
        DetectionLoop(_poopCTS.Token).Forget();
    }

    private async UniTask DetectionLoop(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _detectionRadius, _results, _poopMask);

            for (int i = 0; i < hitCount; i++)
            {
                if (token.IsCancellationRequested) break;

                Collider hit = _results[i];

                if (_craphophage)
                {
                    await _humanPlants.HumanMotorsRef.PickupUpPoop(hit.gameObject, token);
                }
                else if (_fanDeCrotte)
                {
                    await LookPoop(hit, token);
                }
            }

            await UniTask.Delay(500, cancellationToken: token); //petite pause
        }
    }

    public void StopDetection()
    {
        _poopCTS?.Cancel();
        _poopCTS?.Dispose();
        _humanPlants.HumanMotorsRef.CanMoveAgent();
    }

    private async UniTask LookPoop(Collider hit, CancellationToken token)
    {
        if (hit == null || hit.gameObject == null) return;

        Vector3 poopPosition = hit.transform.position;
        float angle = UnityEngine.Random.Range(0f, 360f);
        Vector3 offset = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * 3;
        Vector3 targetPosition = poopPosition + offset;
        targetPosition.y = transform.position.y; 

        if (NavMesh.SamplePosition(targetPosition, out NavMeshHit navHit, 1f, NavMesh.AllAreas)) 
        {
            _humanPlants.HumanMotorsRef.GoTo(navHit.position);
        }

        await UniTask.Delay(2000, cancellationToken: token); //Placement
        _humanPlants.HumanMotorsRef.StopMoveAgent();

        await LookAtSmoothly(poopPosition, token); // Tourner vers le caca

        await UniTask.WaitUntil(() => hit == null || hit.gameObject == null, cancellationToken: token); //regarde son caca...
        _humanPlants.HumanMotorsRef.CanMoveAgent();
    }

    private async UniTask LookAtSmoothly(Vector3 target, CancellationToken token) //Se tourne vers son caca
    {
        float duration = 0.5f;
        float elapsed = 0f;

        Quaternion startRot = transform.rotation;
        Vector3 direction = (target - transform.position).normalized;
        direction.y = 0;
        Quaternion targetRot = Quaternion.LookRotation(direction);

        while (elapsed < duration && !token.IsCancellationRequested)
        {
            transform.rotation = Quaternion.Slerp(startRot, targetRot, elapsed / duration);
            elapsed += Time.deltaTime;
            await UniTask.Yield();
        }

        transform.rotation = targetRot;
    }

}
