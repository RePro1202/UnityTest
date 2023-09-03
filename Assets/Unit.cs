using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    private GridPosition gridPosition;
    private bool onGrid;

    private void Awake()
    {
        onGrid = false;
    }

    private void Start()
    {
        CheckOnGrid();
    }

    private void Update()
    {
        if(!onGrid)
        {
            CheckOnGrid();
        }

        if(onGrid)
        {
            GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            if (newGridPosition != gridPosition)
            {
                LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
                gridPosition = newGridPosition;
            }
        }
    }


    public bool GetOnGrid()
    {
        return onGrid;
    }

    private void CheckOnGrid()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if (gridPosition >= (0, 0) && gridPosition <= (LevelGrid.Instance.GetWidth(), LevelGrid.Instance.GetHeight()))
        {
            LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);

            onGrid = true;
        }
    }
}
