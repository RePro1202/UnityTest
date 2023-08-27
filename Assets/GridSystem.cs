using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private GridObject[,] gridObjectArray;

    private GridObject OutOfGrid;

    public GridSystem(int width, int height)
    {
        this.width = width;
        this.height = height;
        OutOfGrid = new GridObject(this, new GridPosition(-1, -1));

        gridObjectArray = new GridObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridObjectArray[x, y] = new GridObject(this, new GridPosition(x, y));
            }
        }
    }

    public void CreateDebugObjcet(Transform debugPrefab, Transform container)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Transform debugTransform = Transform.Instantiate(debugPrefab, GetWorldPosition(x, y), Quaternion.identity);
                debugTransform.SetParent(container);

                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(new GridPosition(x, y)));
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y, 0);
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return GetWorldPosition(gridPosition.x, gridPosition.y);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y));
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        if(gridPosition.x < 0 || gridPosition.y < 0 || gridPosition.x >= width || gridPosition.y >= height)
        {
            return OutOfGrid;
        }

        return gridObjectArray[gridPosition.x, gridPosition.y];
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }
}
