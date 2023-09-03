using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnBox : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        SpwanTetris();
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponentInChildren<TetrisObject>().AttachMouse(false);
    }

    private void SpwanTetris()
    {
        GetComponentInChildren<TetrisObject>().AttachMouse(true);
    }
}
