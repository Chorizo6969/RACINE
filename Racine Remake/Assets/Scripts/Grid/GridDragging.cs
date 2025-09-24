using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridDragging : MonoBehaviour
{
    #region Initialization

    public event Action OnDragStop;
    public event Action<List<Cell>, BuildingBase> OnDrag;
    public event Action OnDragStart;

    private CancellationTokenSource _source;
    private UniTask _task;
    private List<Cell> _buildingCells;

    private void Start()
    {
        BuildingManager.Instance.BuildingConstructor.OnBuildingChosen += StartDraggingMethod;
    }

    public void StartDraggingMethod(BuildingBase building)
    {
        _source = new();
        building.Collider.enabled = false;
        _task = DragBuilding(_source, building, false, Vector2Int.zero);
        OnDragStart.Invoke();
    }

    public void StopDragging(CancellationTokenSource source)
    {
        _buildingCells.ForEach(cell => cell.ResetCell()); // Paints the cells as occupied.
        _buildingCells.Clear();

        source?.Cancel();
        OnDragStop?.Invoke();
        if (_task.AsTask() != null) _task.Forget();
    }

    #endregion

    public async UniTask DragBuilding(CancellationTokenSource source, BuildingBase building, bool upgrade, Vector2Int previous)
    {
        await UniTask.Yield();

        while (!source.IsCancellationRequested)
        {
            await UniTask.WaitUntil(() => !EventSystem.current.IsPointerOverGameObject());

            if (upgrade)
            {

                BuildingManager.Instance.GridConstructor.GetCurrentCells(previous, building.Data.Size, out _buildingCells);
                building.transform.position = GridPositionHandler.CellToBuilding(_buildingCells[0]);

                if (BuildingManager.Instance.BuildingConstructor.BuyBuilding(building.Placement.Count == 0, building, _buildingCells)) // If the building can be bought and placed.
                {
                    building.ResetCells();
                    building.Collider.enabled = true;

                    foreach (Cell cell in _buildingCells)
                    {
                        cell.Building = building;
                        building.Placement.Add(cell);
                    }

                    _buildingCells.ForEach(cell => cell.ResetCell()); // Paints the cells as occupied.
                    _buildingCells.Clear();
                    OnDrag?.Invoke(_buildingCells, building);

                    return; // Stops the dragging and resets the cells.
                }
            }

            #region Raycast Check

            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Vector2Int hitPos = new Vector2Int((int)hit.transform.position.x, (int)hit.transform.position.z);
                BuildingManager.Instance.GridConstructor.GetCurrentCells(hitPos, building.Data.Size, out _buildingCells);
                building.transform.position = GridPositionHandler.CellToBuilding(_buildingCells[0]);
                OnDrag?.Invoke(_buildingCells, building);
            }

            #endregion

            #region Outcome Check

            if (Input.GetMouseButton(0)) // Places the building.
            {
                if (BuildingManager.Instance.BuildingConstructor.BuyBuilding(building.Placement.Count == 0, building, _buildingCells)) // If the building can be bought and placed.
                {
                    building.ResetCells();
                    building.Collider.enabled = true;

                    foreach (Cell cell in _buildingCells)
                    {
                        cell.Building = building;
                        building.Placement.Add(cell);
                    }

                    StopDragging(source); // Stops the dragging and resets the cells.
                }
            }

            else if (Input.GetMouseButton(1)) // Cancels the drag.
            {
                if (building.Placement.Count <= 0) Destroy(building.gameObject);

                else
                {
                    building.transform.position = GridPositionHandler.CellToBuilding(building.Placement[0]);
                    building.Collider.enabled = true;
                }

                StopDragging(source); // Stops the dragging and resets the cells.
            }

            #endregion
        }
    }
}
