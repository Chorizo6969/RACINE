using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class Narcoleptique : MonoBehaviour, IPersonalitySetup
{
    private CancellationTokenSource _sleepCTS; //les tokens servent � tout arr�ter en cas de p�pin

    [SerializeField] private HumanPlants _humanPlants;

    [Header("Param�tres de Sommeil")]
    [SerializeField] private int _timeBeforeRestartFunction = 5;
    [SerializeField] private float _increasedProbabilityEachIteration = 0.1f;
    [SerializeField] [Range(0,1)] private float _probaFallAsleep = 0f;
    [SerializeField] private ParticleSystem _sleepParticle;

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
            if (_humanPlants.StatsRef.IsHome)
            {
                await UniTask.WaitUntil(() => !_humanPlants.StatsRef.IsHome, cancellationToken: token);
            }
            else
            {
                if (_probaFallAsleep >= 0.7f && !_humanPlants.StatsRef.Asleep) //Si fatigue � + de 70% alors il va peut �tre dodo
                {
                    float randomProba = Random.Range(0f, 1f);
                    if (randomProba <= _probaFallAsleep)
                    {
                        _humanPlants.StatsRef.Asleep = true;             //dors
                        _sleepParticle.Play();
                        _humanPlants.HumanMotorsRef.StopMoveAgent();
                    }
                }
                _probaFallAsleep = Mathf.Clamp01(_probaFallAsleep + _increasedProbabilityEachIteration);
                await UniTask.Delay(_timeBeforeRestartFunction * 1000, cancellationToken: token); //attente avant de relancer la m�thode
            }
        }
    }

    public void StopDetection()
    {
        _sleepCTS?.Cancel();
        _sleepCTS?.Dispose();
        _humanPlants.HumanMotorsRef.CanMoveAgent();
    }

    public void StopSleep()
    {
        _humanPlants.StatsRef.Asleep = false;
        _sleepParticle.Stop();
        _humanPlants.HumanMotorsRef.CanMoveAgent();
        _probaFallAsleep = 0f;
    }
}
