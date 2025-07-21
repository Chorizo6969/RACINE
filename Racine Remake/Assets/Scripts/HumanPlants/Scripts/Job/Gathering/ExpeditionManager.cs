using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Classe qui gère les comportements d'expédition des humains plantes
/// </summary>
public class ExpeditionManager : MonoBehaviour
{
    [Header("Bois")]
    [SerializeField] private int _averageAmountWood;
    [SerializeField] private int _finalHitWood;

    [Header("Pierre")]
    [SerializeField] private int _averageAmountStone;
    [SerializeField] private int _timeWorking;

    [Header("Eau")]
    [SerializeField] private int _averageAmountWater;
    [SerializeField] private int _timeForeachBuckets;

    public static ExpeditionManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public async UniTask<WorldResources> StoneWork()
    {
        int time = _timeWorking;
        while (time > 0)
        {
            await UniTask.Delay(1000);
            time--;
        }

        WorldResources results = new() 
        { 
            Wood = 0,
            Rock = Random.Range(_averageAmountStone - 2, _averageAmountStone + 3),
            Water = 0
        };

        return results;
    }

    public async UniTask<WorldResources> WaterWork()
    {
        int waterResults = 0;

        for(int i = 0; i < 2; i++)
        {
            int time = _timeForeachBuckets;
            while (time > 0)
            {
                await UniTask.Delay(1000);
                time--;
            }

            waterResults += Random.Range(_averageAmountWater - 2, _averageAmountWater + 3);
        }

        WorldResources results = new()
        {
            Wood = 0,
            Rock = 0,
            Water = waterResults
        };

        return results;
    }

    public async UniTask GoBackReserve(WorldResources ressources)
    {
        if(ressources.Wood != 0)
        {
            //chercher reserve bois
        }
        if(ressources.Rock != 0)
        {
            //chercher reserve pierre
        }
        if (ressources.Water != 0)
        {
            //chercher reserve eau
        }

    }

    public void ReturnResults(int wood, int stone, int water)
    {
        WorldResources results = new() { Wood = wood, Rock = stone, Water = water };
        ResourcesHandler.AddResources(results);
    }
}
