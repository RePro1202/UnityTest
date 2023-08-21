using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    GridSystem gridSystem;
    Vector2Int girdPos;

    public GridObject(GridSystem gridSystem, Vector2Int girdPos)
    {
        this.gridSystem = gridSystem;
        this.girdPos = girdPos;
    }

}
