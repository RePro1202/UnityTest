using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private Unit unit;

    public GridObject(GridSystem gridSystem, GridPosition girdPos)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = girdPos;
    }

    public override string ToString()
    {
        if(unit == null)
        {
            return gridPosition.ToString();
        }
        else
        {
            return gridPosition.ToString() + "\n" + unit;
        }
    }

    public void SetUnit(Unit unit)
    {
        this.unit = unit;
    }

    public Unit GetUnit()
    {
        return this.unit;
    }
}
