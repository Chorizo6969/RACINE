using System.Collections.Generic;
using UnityEngine;

public class CellPainting : MonoBehaviour
{
    private List<Cell> _leftCells = new();

    private void Start()
    {
        BuildingManager.Instance.GridDragging.OnDrag += CellPaint;
    }

    private void CellPaint(List<Cell> cells, BuildingBase building)
    {
        if (cells == null) return;

        foreach (Cell cell in cells)
        {
            cell.PaintCell(cell.Building != null); // Paints the cell based on whether it is occupied.
            cell.CheckOtherCells(cells, out _leftCells);
            _leftCells.ForEach(cell => cell.ResetCell());
        }

    }
}
