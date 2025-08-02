using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    #region Initialization

    public BuildingBase Building { get; set; }
    public Vector2Int CellPos => new Vector2Int((int)transform.position.x, (int)transform.position.z);
    private MeshRenderer _render;
    private Material _defaultMat;

    private void Awake()
    {
        TryGetComponent(out _render);
        _defaultMat = _render.material;
    }

    #endregion

    public void CheckOtherCells(List<Cell> buildingCells, out List<Cell> leftCells)
    {
        leftCells = new();

        foreach(Cell cell in BuildingManager.Instance.GridConstructor.Grid.Values)
        {
            if (!buildingCells.Contains(cell) && cell._render.material != _defaultMat) leftCells.Add(cell); // Lists every cells that needs to be updated.
        }
    }

    public void PaintCell(bool occupied)
    {
        BuildingManager.Instance.GridConstructor.CellMaterials.TryGetValue(occupied ? CellStates.Occupied : CellStates.Empty, out Material material);
        _render.material = material;
    }

    public void ResetCell()
    {
        _render.material = _defaultMat;
    }
}
