using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

/// <summary>
/// Classe qui va détecter les caca et réagir en conséquence (fixe ou nettoyage)
/// </summary>
public class PoopDetector : MonoBehaviour
{
    private CancellationTokenSource _poopCTS; //les tokens servent à tout arrêter en cas de pépin

    [SerializeField] private Stats _stats;

    private bool _craphophage;
    private bool _fanDeCrotte;

    [Header("Paramètres de détection")]
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private LayerMask _poopMask;

    public void SetupValue()
    {
        _craphophage = _stats.CleanPoop;
        _fanDeCrotte = _stats.FixeCaca;
    }

    public void StartDetection()
    {
        _poopCTS = new CancellationTokenSource();
        DetectionLoop(_poopCTS.Token).Forget();
    }

    private async UniTask DetectionLoop(CancellationToken token)
    {
        while (true)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _detectionRadius, _poopMask);
            foreach (Collider hit in hits)
            {
                if (_craphophage)
                {
                    //start anim clean poop
                    await UniTask.Delay(3000, cancellationToken: token);
                }
                else if (_fanDeCrotte)
                {
                    await UniTask.WaitUntil(() => hit == null || hit.gameObject == null, cancellationToken: token); // il attends que le caca soit ramassé
                }
            }
        }
    }

    public void StopDetection()
    {
        _poopCTS?.Cancel();
        _poopCTS?.Dispose();
    }

}
