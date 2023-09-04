using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField] private Transform gridSystemVisualPrefab;

    private void Start()
    {
        for(int x = 0; x< LevelGrid.Instance.GetWidth(); x++)
        {
            for(int y = 0; y< LevelGrid.Instance.GetHeight(); y++) 
            {
                GridPosition gridPosition = new GridPosition(x, y);
                Instantiate(gridSystemVisualPrefab, LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);
            }
        }
    }
}
