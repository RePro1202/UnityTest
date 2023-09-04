using Unity.VisualScripting.Dependencies.Sqlite;
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
        CheckEnterGrid();
    }

    private void Update()
    {
        if(onGrid)
        {
            CheckMoveGridPosition();
        }
        else
        {
            CheckEnterGrid();
        }

        onGrid = LevelGrid.Instance.CheckOnGrid(transform.position);
    }


    private void CheckMoveGridPosition()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if (newGridPosition != gridPosition)
        {
            MoveGridPosition(newGridPosition);
        }
    }

    private void MoveGridPosition(GridPosition newGridPosition)
    {
        bool isMoveInGrid = LevelGrid.Instance.CheckOnGrid(newGridPosition);

        if (isMoveInGrid)
        {
            MoveTo(newGridPosition);
        }
        else
        {
            ExitGrid();
        }
    }

    private void MoveTo(GridPosition newGridPosition)
    {
        LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
        gridPosition = newGridPosition;
    }

    private void ExitGrid()
    {
        LevelGrid.Instance.RemoveUnitAtGridPosition(gridPosition, this);
    }

    private void CheckEnterGrid()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if (LevelGrid.Instance.CheckOnGrid(gridPosition))
            LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }

    
    public bool GetOnGrid()
    {
        return onGrid;
    }
}
