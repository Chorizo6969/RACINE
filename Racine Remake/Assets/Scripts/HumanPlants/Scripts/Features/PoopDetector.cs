using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

/// <summary>
/// Classe qui va d�tecter les caca et r�agir en cons�quence (fixe ou nettoyage)
/// </summary>
public class PoopDetector : MonoBehaviour
{
    private CancellationTokenSource _poopCTS; //les tokens servent � tout arr�ter en cas de p�pin

    [SerializeField] private Stats _stats;

    private bool _craphophage;
    private bool _fanDeCrotte;

    [Header("Param�tres de d�tection")]
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
                    await UniTask.WaitUntil(() => hit == null || hit.gameObject == null, cancellationToken: token); // il attends que le caca soit ramass�
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
