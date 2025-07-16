using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class Narcoleptique : MonoBehaviour, IPersonalitySetup
{
    private CancellationTokenSource _sleepCTS; //les tokens servent à tout arrêter en cas de pépin

    [SerializeField] private HumanPlants _humanPlants;

    [Header("Paramètres de Sommeil")]
    [SerializeField] private int _timeBeforeRestartFunction = 5;
    [SerializeField] private float _increasedProbabilityEachIteration = 0.1f;
    [SerializeField] [Range(0,1)] private float _probaFallAsleep = 0f;

    private void Start()
    {
        TimeInGame.Instance.OnStartWork += StartDetection;
        TimeInGame.Instance.OnStartSleep += StopDetection;
    }

    public void StartDetection()
    {
        if (!_humanPlants.StatsRef.IsNarcoleptique)
            return;
        _sleepCTS = new CancellationTokenSource();
        SleepingLoop(_sleepCTS.Token).Forget();
    }

    private async UniTask SleepingLoop(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (_probaFallAsleep >= 0.7f) //Si fatigue à + de 70% alors il va peut être dodo
            {
                float randomProba = Random.Range(0f, 1f);
                if (randomProba <= _probaFallAsleep)
                {
                    _humanPlants.StatsRef.Asleep = true;             //dors
                    _humanPlants.HumanMotorsRef.StopMoveAgent();
                }
            }
            _probaFallAsleep += _increasedProbabilityEachIteration;
            await UniTask.Delay(_timeBeforeRestartFunction * 1000, cancellationToken: token); //attente avant de relancer la méthode
        }
    }

    public void StopDetection()
    {
        _sleepCTS?.Cancel();
        _sleepCTS?.Dispose();
        _humanPlants.HumanMotorsRef.CanMoveAgent();
    }
}
