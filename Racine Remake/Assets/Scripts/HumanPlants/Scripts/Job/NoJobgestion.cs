using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

public class NoJobGestion : MonoBehaviour
{
    [Header("Waiting after State")]
    [SerializeField] private int TimeAwaitAfterWander = 120;
    [SerializeField] private int TimeAwaitGoHome = 60;
    [SerializeField] private int TimeAwaitSitDown = 60;
    [HideInInspector] public bool CanChill;

    [Header("State reference")]
    [SerializeField] private RandomBallade _randomBalladeRef;
    [SerializeField] private BackHouseForChill _backHouse;
    [SerializeField] private SitAndChill _sitAndChillRef;

    [Header("State Probabilities")]
    [Range(0, 1)][SerializeField] private float _wanderProbability = 0.33f;
    [Range(0, 1)][SerializeField] private float _goHomeProbability = 0.33f;
    [Range(0, 1)][SerializeField] private float _sitProbability = 0.34f;

    private CancellationTokenSource _chillCTS;

    public void StartChill()
    {
        CanChill = true;
        _chillCTS = new CancellationTokenSource();
        ChooseState(_chillCTS.Token).Forget();
    }

    private async UniTask ChooseState(CancellationToken token)
    {
        while (CanChill && !token.IsCancellationRequested)
        {
            int choice = GetWeightedRandomChoice();
            switch (choice)
            {
                case 0:
                    _randomBalladeRef.StartWander();
                    try
                    {
                        await UniTask.Delay(TimeAwaitAfterWander * 1000, cancellationToken: token);
                    }
                    catch (OperationCanceledException) { }
                    _randomBalladeRef.StopWander();
                    break;

                case 1:
                    await _backHouse.BackHome();
                    try
                    {
                        await UniTask.Delay(TimeAwaitGoHome * 1000, cancellationToken: token);
                    }
                    catch (OperationCanceledException) { }
                    break;

                case 2:
                    _sitAndChillRef.SitDownAndChill();
                    try
                    {
                        await UniTask.Delay(TimeAwaitSitDown * 1000, cancellationToken: token);
                    }
                    catch (OperationCanceledException) { }
                    break;
            }
        }
    }

    public void StopAllChillBehaviors()
    {
        CanChill = false;

        _chillCTS?.Cancel();
        _chillCTS?.Dispose();

        _randomBalladeRef.StopWander();
        //_sitAndChillRef.StopChilling();
        //_humanPlantsRef.ForceExitHome();
    }

    private int GetWeightedRandomChoice()
    {
        float total = _wanderProbability + _goHomeProbability + _sitProbability;
        float random = UnityEngine.Random.Range(0, total);
        if (random < _wanderProbability) return 0;
        if (random < _wanderProbability + _goHomeProbability) return 1;
        return 2;
    }
}
