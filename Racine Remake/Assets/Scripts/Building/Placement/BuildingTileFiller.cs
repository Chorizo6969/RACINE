using UnityEngine;

public class BuildingTileFiller : MonoBehaviour
{
    private void Start()
    {
        BuildingManager.Instance.GridPlacing.OnPositionChanged += UpdatePosition;
    }

    private void UpdatePosition(Vector3Int cellPos) // Updates the floodfill depending on the building's position.
    {

    }
}
