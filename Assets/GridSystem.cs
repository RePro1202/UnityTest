using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray;

    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridObjectArray[x, y] = new GridObject(this, new Vector2Int(x, y));
            }
        }
    }

    public void CreateDebugObjcet(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Transform debugTransform = Transform.Instantiate(debugPrefab, GetWorldPosition(x, y), Quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(new Vector2Int(x, y)));
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y, 0) * cellSize;
    }

    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        return new Vector2Int(Mathf.RoundToInt(worldPosition.x / cellSize), Mathf.RoundToInt(worldPosition.y / cellSize));
    }

    public GridObject GetGridObject(Vector2Int girdPosition)
    {
        return gridObjectArray[girdPosition.x, girdPosition.y];
    }
}
