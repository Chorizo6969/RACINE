using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridDragging : MonoBehaviour
{
    #region Initialization

    public event Action<Vector3Int> OnPositionChanged;

    [field:SerializeField]
    public GridLayout GridLayout { get; private set; }
    [field: SerializeField]
    public Tilemap MainTilemap { get; private set; }
    [field: SerializeField]
    public Tilemap ConstructionTilemap { get; private set; }
    private BuildingMain _currentBuilding; // The building that is currently being placed.

    #endregion

    public void InitializeBuilding(BuildingData data)
    {
        // Checks if the player can afford the building or not before letting them place it.
        if(!ResourcesHandler.HasEnoughResources(data.Cost)) return;

        ResourcesHandler.RemoveResources(data.Cost);
        _currentBuilding = BuildingManager.Instance.BuildingPool.GetFromPool(data);
        _currentBuilding.transform.localPosition = DragBuilding(GridLayout, _currentBuilding);
    }

    public Vector3 DragBuilding(GridLayout grid, BuildingMain building) // Moves the building in the grid based on mouse position.  
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);

        if (hit.collider.CompareTag("Ground"))
        {
            Vector3 pos = new Vector3(hit.point.x, 0, hit.point.z);
            Vector3 localPos = building.transform.localPosition;

            localPos = grid.CellToLocalInterpolated(grid.WorldToCell(pos));
            localPos.z = (int)hit.transform.position.y;

            if (_currentBuilding.transform.position == localPos) return Vector3.zero; // Prevents unnecessary updates if the position hasn't changed.

            return localPos;
        }

        return Vector3.zero;
    }

    private void Update()
    {
        if (!_currentBuilding) return;

        if (!Input.GetMouseButton(0)) // Start dragging behaviour.
        {
            if (EventSystem.current.IsPointerOverGameObject()) return; // Ignores UI.

            if (DragBuilding(GridLayout, _currentBuilding) != Vector3.zero)
            {
                _currentBuilding.transform.localPosition = DragBuilding(GridLayout, _currentBuilding);
                Vector3Int cellPos = GridLayout.LocalToCell(_currentBuilding.transform.localPosition);

                OnPositionChanged?.Invoke(cellPos);
            }
        }

        // Stop dragging behaviour.
        else if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) _currentBuilding = null;
    }
}
