using UnityEngine;

/// <summary>
/// Scrit qui permet de snap les bâtiments à la grille
/// </summary>
public class GridSnap : MonoBehaviour
{
    /// <summary>
    /// lien vers le component Grid de la scène
    /// </summary>
    private Grid m_Grid;

    /// <summary>
    /// float qui gère la hauteur à laquelle l'objet devra spawn.
    /// </summary>
    [SerializeField] 
    private float height = 0.7f;

    void Start()
    {
        m_Grid = FindAnyObjectByType<Grid>();
    }

    void Update()
    {
        Vector3Int cp = m_Grid.LocalToCell(transform.localPosition);
        transform.localPosition = m_Grid.GetCellCenterLocal(cp);
        transform.position = new Vector3(cp.x, height, cp.y);
    }
}
