using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class DebugResourcesProducing : MonoBehaviour
{
    #region Initialization

    private CancellationTokenSource _source;
    private UniTask _task;

    private void Start()
    {
        _source = new();
        _task = ProduceResources(_source.Token);
    }

    #endregion

    private async UniTask ProduceResources(CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            await Task.Delay(1000);
            ResourcesHandler.AddResources(new WorldResources
            {
                Wood = 10,
                Rock = 10,
                Water = 10
            });

            await UniTask.Yield();
        }
    }
}
