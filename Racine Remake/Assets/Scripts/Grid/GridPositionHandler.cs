using UnityEngine;

public static class GridPositionHandler // Helps with building offsets.
{
    public static Vector2Int BuildingToCell(BuildingBase building)
    {
        return new Vector2Int((int)(building.transform.position.x + 0.5f), (int)building.transform.position.z);
    }

    public static Vector3 CellToBuilding(Cell cell)
    {
        return new Vector3(cell.transform.position.x - 0.5f, BuildingManager.Instance.transform.position.y, cell.transform.position.z - 0.5f);
    }
}
