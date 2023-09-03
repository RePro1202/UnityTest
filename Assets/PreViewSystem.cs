using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PreViewSystem
{
    private int slotNum;

    public PreViewSystem(int slotNum)
    {
        this.slotNum = slotNum;
    }

    public int GetRandomNum()
    {
        return Random.Range(0, slotNum);
    }


}
