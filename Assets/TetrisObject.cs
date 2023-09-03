using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TetrisObject : MonoBehaviour
{
    private bool isAttackedMouse;
    private Unit[] units;

    private void Awake()
    {
        isAttackedMouse = false;
        units = GetComponentsInChildren<Unit>();
    }

    private void Update()
    {
        FollowingMousePoint(isAttackedMouse);
    }

    public void AttachMouse(bool toggle)
    {
        isAttackedMouse = toggle;

        if (isAttackedMouse)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            if(CheckAllUnitOnGrid())
            {
                // TODO : 테트리스 타일을 맵에 정상 적용됬을때 처리.
            }
            else
            {
                transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                transform.localPosition = Vector3.zero;
            }
        }
    }

    private void FollowingMousePoint(bool isAttackedMouse)
    {
        if (!isAttackedMouse) return;

        Vector2 currentPos = transform.position;
        Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        transform.position = newPos;
    }

    private bool CheckAllUnitOnGrid()
    {
        foreach (Unit unit in units)
        {
            if (!unit.GetOnGrid()) return false;
        }

        return true;
    }
}
