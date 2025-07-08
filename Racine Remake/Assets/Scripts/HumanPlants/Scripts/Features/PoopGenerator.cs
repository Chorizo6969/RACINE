using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

/// <summary>
/// Loop qui permet au humain plante de faire caca en extèrieur
/// </summary>
public class PoopGenerator : MonoBehaviour
{
    [Header("Poop Settings")]
    [SerializeField] private GameObject _poopPrefab;
    [SerializeField] private Stats _stats;
    [SerializeField] private Personality _personality;

    [Header("Need Settings")]
    private float _maxPoopNeed = 100f;
    private float _poopNeed = 0f;
    private float _poopNeedRate = 5f; // gain par seconde

    [Header("Poop Timing")]
    private int _maxDelay = 300;
    private int _minDelay = 60;

    private CancellationTokenSource _poopCTS;

    private void Start()
    {
        TimeInGame.Instance.OnStartWork += StartPoop;
        TimeInGame.Instance.OnStartSleep += StopPoop;
        _personality.OnStatsReady += SetupValue;
    }

    public void SetupValue()
    {
        _poopNeedRate = _stats.PoopSpeed;
    }

    public void StartPoop()
    {
        _poopCTS = new CancellationTokenSource();
        StartPoopLoop(_poopCTS.Token).Forget();
    }

    private async UniTaskVoid StartPoopLoop(CancellationToken token)
    {
        while (true)
        {
            int randomOffset = Random.Range(-50, 0);
            float delay = Mathf.Lerp(_maxDelay, _minDelay, _poopNeed / _maxPoopNeed) + randomOffset;
            delay = Mathf.Clamp(delay, _minDelay, _maxDelay); // pour éviter des valeurs négatives
            print(delay);
            await UniTask.Delay(System.TimeSpan.FromSeconds(delay), cancellationToken: token);

            _poopNeed += _poopNeedRate * delay;         // Augmente le besoin avec le temps
            _poopNeed = Mathf.Clamp(_poopNeed, 0f, _maxPoopNeed);

            if (!_stats.IsHome && _poopNeed >= _maxPoopNeed * 0.75f) // commence à 75% du besoin
            {
                Poop();
                _poopNeed = 0f;
            }
            else if (_stats.IsHome) { _poopNeed = 0; } // Il fait chez lui

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

