using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
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
        _task = DragBuilding(_source.Token, building);
        OnDragStart.Invoke();
    }

    public void StopDragging()
    {
        _buildingCells.ForEach(cell => cell.ResetCell()); // Paints the cells as occupied.
        _buildingCells.Clear();

        _source?.Cancel();
        _task.Forget();

        OnDragStop?.Invoke();

        return;
    }

    #endregion

    private async UniTask DragBuilding(CancellationToken token, BuildingBase building)
    {
        await UniTask.Yield();

        while (!token.IsCancellationRequested)
        {
            await UniTask.WaitUntil(() => !EventSystem.current.IsPointerOverGameObject());

            #region Raycast Check

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
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
                //if (BuildingManager.Instance.BuildingConstructor.BuyBuilding(building.Placement.Count == 0, building, _buildingCells)) // If the building can be bought and placed.
                //{
                //    building.ResetCells();
                //    building.Collider.enabled = true;

                //    foreach (Cell cell in _buildingCells)
                //    {
                //        cell.Building = building;
                //        building.Placement.Add(cell);
                //    }

                //}
                PlaceBuilding(building);
                StopDragging(); // Stops the dragging and resets the cells.
            }

            else if (Input.GetMouseButton(1)) // Cancels the drag.
            {
                if (building.Placement.Count <= 0) Destroy(building.gameObject);

                else
                {
                    building.transform.position = GridPositionHandler.CellToBuilding(building.Placement[0]);
                    building.Collider.enabled = true;
                }

                StopDragging(); // Stops the dragging and resets the cells.
            }

            #endregion
        }
    }

    public bool PlaceBuilding(BuildingBase building, bool isUpgrade = false)
    {
        // TEMPORAIRE (nécessaire pour la 3e condition)
        if (isUpgrade) _buildingCells.ForEach(value => value.Building = null);

        if (BuildingManager.Instance.BuildingConstructor.BuyBuilding(building.Placement.Count == 0, building, _buildingCells)) // If the building can be bought and placed.
        {
            building.ResetCells();
            building.Collider.enabled = true;

            // NE PAS UTILISER QUAND ON CREE LE BATIMENT, QUE QUAND ON LUPGRADE
            if (isUpgrade)
            {
                Vector2Int truc = new((int)building.transform.position.x, (int)building.transform.position.z);
                BuildingManager.Instance.GridConstructor.GetCurrentCells(truc, building.Data.Size, out _buildingCells);
                print($"[GridDragging] new _buildingCells.Count : {_buildingCells.Count}");
            }

            foreach (Cell cell in _buildingCells)
            {
                cell.Building = building;
                print("[GridDragging] cell : " + cell.transform.position + " cellBuilding ? : " + cell.Building);
                building.Placement.Add(cell);
            }

            return true;
        }

        return false;
    }

    public void ChangerBuildingCellsTemporairement(BuildingBase building)
    {
        print($"[GridDragging] _buildingCells former count : {_buildingCells.Count}, new : {building.Placement.Count}");
        _buildingCells = building.Placement;
    }
}
