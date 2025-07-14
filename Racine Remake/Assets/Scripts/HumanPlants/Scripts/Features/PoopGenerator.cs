using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
/// <summary>
/// Script qui fait faire caca à l'humain plante
/// </summary>
public class PoopGenerator : MonoBehaviour
{
    [Header("Poop Settings")]
    [SerializeField] private GameObject _poopPrefab;
    [SerializeField] private Stats _stats;
    [SerializeField] private Personality _personality;

    [Header("Poop Timer Settings")]
    [SerializeField] private float _poopTimer; // Durée initiale avant caca
    [SerializeField] private float _currentPoopTimer; // Durée initiale avant caca
    private int _poopSpeed;

    private CancellationTokenSource _poopCTS;

    private void Start()
    {
        TimeInGame.Instance.OnStartWork += StartPoop;
        TimeInGame.Instance.OnStartSleep += StopPoop;
        _personality.OnStatsReady += SetupValue;
    }

    public void SetupValue()
    {
        _poopSpeed = Mathf.RoundToInt(_stats.PoopSpeed);
        _poopTimer = Random.Range(100, 250);
        _currentPoopTimer = _poopTimer;
    }

    public void StartPoop()
    {
        if (_poopSpeed == 0) { return; }
        _poopCTS = new CancellationTokenSource();
        LoopPoopTimer(_poopCTS.Token).Forget();
    }

    private async UniTaskVoid LoopPoopTimer(CancellationToken token)
    {
        while (true)
        {
            await UniTask.Delay(1000 / _poopSpeed, cancellationToken: token);

            if (_stats.IsHome)
            {
                _currentPoopTimer = _poopTimer; // reset s'il est à la maison
                continue;
            }

            _currentPoopTimer--;

            if (_currentPoopTimer <= 0)
            {
                Poop();
                _poopTimer = Random.Range(100, 250);
                _currentPoopTimer = _poopTimer;
                continue;
            }
        }
    }

    public void StopPoop()
    {
        _poopCTS?.Cancel();
        _poopCTS?.Dispose();
    }

    private async void Poop()
    {
        Instantiate(_poopPrefab, transform.position, Quaternion.identity);
        await Happiness.Instance.ReduceHappiness(5);
        Debug.Log($"{gameObject.name} a fait caca !");
    }
}
