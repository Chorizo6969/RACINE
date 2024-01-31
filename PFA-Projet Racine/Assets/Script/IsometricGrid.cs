using UnityEngine;

public class IsometricGrid : MonoBehaviour
{
    public int gridSize = 1;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                Vector3 tilePosition = new Vector3(x * gridSize, 0, z * gridSize);
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = tilePosition;
                cube.transform.parent = transform; // Pour rendre le cube enfant de la grille
            }
        }
    }
}
