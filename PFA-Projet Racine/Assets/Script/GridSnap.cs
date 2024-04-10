using UnityEngine;

public class GridSnap : MonoBehaviour
{
    private Grid m_Grid;
    [SerializeField] private float height = 0.7f;

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
