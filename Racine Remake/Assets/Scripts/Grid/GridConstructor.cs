using AYellowpaper.SerializedCollections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GridConstructor : MonoBehaviour
{
    #region Initialization

    public event Action OnGridEnabled;
    public Dictionary<Vector2, Cell> Grid { get; set; } = new();
    [field:SerializeField]
    public SerializedDictionary<CellStates, Material> CellMaterials { get; private set; } = new();

    [SerializeField]
    private Vector2Int _gridSize;
    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private GameObject _cellPrefab;

    private void Awake()
    {
        InitializeGrid(_gridSize);
    }

    #endregion

    public void InitializeGrid(Vector2Int size) //Create a grid of the specified size.
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                GameObject cellObject = Instantiate(_cellPrefab);
                cellObject.transform.SetParent(_container.transform);

                cellObject.transform.localPosition = new Vector3(x, 0, y);
                cellObject.name = $"Cell_{x}_{y}";

                Cell cell = cellObject.GetComponent<Cell>();
                Vector2Int pos = new Vector2Int((int)cellObject.transform.position.x, (int)cellObject.transform.position.z);
                Grid[pos] = cell;
            }
        }

        ActivateGrid(false); // Initially, the grid is not active.
    }

    public void ActivateGrid(bool state)
    {
        _container.SetActive(state);
        OnGridEnabled?.Invoke();
    }

    public bool IsGridActive()
    {
        return _container.activeInHierarchy;
    }

    public void GetCurrentCells(Vector2Int currentPos, Vector2Int size, out List<Cell> usedCells)
    {
        usedCells = new();
        if (BuildingManager.Instance.GridConstructor.Grid.ContainsKey(currentPos))
        {
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    Vector2Int offsetPos = new Vector2Int(currentPos.x + i, currentPos.y + j);
                    if (BuildingManager.Instance.GridConstructor.Grid.TryGetValue(offsetPos, out Cell cell))
                    {
                        usedCells.Add(cell);
                    }
                }
            }

        }
    }
}
