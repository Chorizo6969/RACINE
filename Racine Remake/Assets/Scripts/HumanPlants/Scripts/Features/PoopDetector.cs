using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

/// <summary>
/// Classe qui va détecter les caca et réagir en conséquence (fixe ou nettoyage)
/// </summary>
public class PoopDetector : MonoBehaviour
{
    private CancellationTokenSource _poopCTS; //les tokens servent à tout arrêter en cas de pépin

    [SerializeField] private HumanPlants _humanPlants;

    private bool _craphophage;
    private bool _fanDeCrotte;

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
        while (_craphophage || _fanDeCrotte)
        {
            try
            {
                Collider[] hits = Physics.OverlapSphere(transform.position, _detectionRadius, _poopMask);
                foreach (Collider hit in hits)
                {
                    if (_craphophage)
                    {
                        await _humanPlants.HumanMotorsRef.PickupUpPoop(hit.gameObject, token);  //start anim clean poop dedans
                    }
                    else if (_fanDeCrotte)
                    {
                        await UniTask.WaitUntil(() => hit == null || hit.gameObject == null, cancellationToken: token); // il attends que le caca soit ramassé
                    }
                }
                await UniTask.Yield();
            }
            catch(MissingReferenceException)
            {
                Debug.LogWarning("Fait belleck le while était en cours");
            }

        }
    }

    public void StopDetection()
    {
        _poopCTS?.Cancel();
        _poopCTS?.Dispose();
        _humanPlants.HumanMotorsRef.CanMoveAgent();
    }

}
