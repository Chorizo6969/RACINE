using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingDetector : MonoBehaviour
{
    #region Initialization

    public event Action<BuildingBase> OnBuildingDetected;
    public event Action OnDetectionCancelled;
    private CancellationTokenSource _source;
    private UniTask _task;

    private void Start()
    {
        _source = new();
        _task = CheckBuilding(_source.Token);
    }

    #endregion

    private async UniTask CheckBuilding(CancellationToken token)
    {
        await UniTask.Yield();

        while (!token.IsCancellationRequested)
        {
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !BuildingManager.Instance.GridConstructor.IsGridActive()); // Mouse click detected, not on UI.

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.collider.CompareTag("Building")) DetectBuilding(hit.transform.parent);

            else OnDetectionCancelled?.Invoke();
        }
    }

    private void DetectBuilding(Transform transform)
    {
        Vector2Int newPos = new Vector2Int((int)(transform.position.x + 0.5f), (int)transform.position.z);

        if (BuildingManager.Instance.GridConstructor.Grid.TryGetValue(newPos, out Cell cell)) OnBuildingDetected?.Invoke(cell.Building);
        else OnDetectionCancelled?.Invoke();
    }
}
