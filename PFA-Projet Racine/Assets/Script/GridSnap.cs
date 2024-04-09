using UnityEngine;

public class GridSnap : MonoBehaviour
{
    private Grid m_Grid;

    void Start()
    {
        m_Grid = FindAnyObjectByType<Grid>();
    }

    void Update()
    {
        Vector3Int cp = m_Grid.LocalToCell(transform.localPosition);
        transform.localPosition = m_Grid.GetCellCenterLocal(cp);
    }
}
