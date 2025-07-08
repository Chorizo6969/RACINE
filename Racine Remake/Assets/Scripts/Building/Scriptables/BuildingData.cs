using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building/Type")]
public class BuildingData : ScriptableObject
{
    [field:SerializeField]
    public Mesh Mesh { get; set; } // The mesh used to render the building.

    [field: SerializeField]
    public Vector2Int Size { get; set; } // The size of the building in grid units.

    [field: SerializeField]
    public WorldResources Cost { get; set; } // The cost of the building in resources.

    [field: SerializeField]
    public BuildingBase Upgrade { get; set; } // The building that this one upgrades to, if any.

    [field: SerializeField]
    public string Name { get; set; } // The name of the building.

    [field: SerializeField]
    public string Description { get; set; } // A description of the building.

    [field: SerializeField]
    public int MaxPopulation { get; set; } // The maximum population this building can support.

}
