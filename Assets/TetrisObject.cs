using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TetrisObject : MonoBehaviour
{
    private bool isAttackedMouse;

    private void Awake()
    {
        isAttackedMouse = false;
    }

    private void Update()
    {
        FollowingMousePoint(isAttackedMouse);
    }

    public void AttachMouse(bool toggle)
    {
        isAttackedMouse = toggle;
    }

    private void FollowingMousePoint(bool isAttackedMouse)
    {
        if (!isAttackedMouse) return;

        Vector2 currentPos = transform.position;
        Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 velo = Vector2.zero;

        transform.position = Vector2.SmoothDamp(currentPos, newPos, ref velo, 0.01f, 300f);
    }
}
