using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

/// <summary>
/// class qui g�re la routine d'un humain plante qui ne travail pas (Ballade, retour � la maison, assis par terre,...)
/// </summary>
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

    protected HumanPlants _humanPlants; //Pour les classes filles

    private void Start()
    {
        _humanPlants = GetComponentInParent<HumanPlants>();
    }

    /// <summary>
    /// Commence la routine al�atoire d'un humain plante
    /// </summary>
    public void StartChill()
    {
        CanChill = true;
        _chillCTS = new CancellationTokenSource(); //Servira � tout arr�ter si il y a une urgence
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
                        await UniTask.Delay(TimeAwaitAfterWander * 1000, cancellationToken: token); //J'attends et je v�rifie qu'il n'y a pas d'urgence
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

    /// <summary>
    /// Stop la routine d'un humain plante
    /// </summary>
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
