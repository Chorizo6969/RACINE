using UnityEngine;
using AYellowpaper.SerializedCollections;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(BuildingPool), typeof(GridDragging))]
public class BuildingManager : MonoBehaviour
{
    #region Initialization

    public static BuildingManager Instance;

    public SerializedDictionary<BuildingType, BuildingBase> BuildingTypes = new();
    public SerializedDictionary<TileType, TileBase> TileSprites = new();

    public BuildingPool BuildingPool { get; private set; }
    public GridDragging GridPlacing { get; private set; }

    private void Awake()
    {
        #region Singleton

        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        #endregion

        BuildingPool = GetComponent<BuildingPool>();
        GridPlacing = GetComponent<GridDragging>();
    }

    #endregion
}
