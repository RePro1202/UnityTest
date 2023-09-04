using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class PreViewPanel : MonoBehaviour
{
    private PreViewSystem preViewSystem;

    [SerializeField]
    private List<RectTransform> previewSlots;

    [SerializeField]
    private List<Transform> spawningPrefabs;

    private List<Transform> tetrisList;

    private void Awake()
    {
        preViewSystem = new PreViewSystem(previewSlots.Count);
        tetrisList = new List<Transform>();
    }


    private void Start()
    {
        foreach (RectTransform preview in previewSlots)
        {
            Transform tetris = Instantiate(spawningPrefabs[preViewSystem.GetRandomNum()], preview);
            tetris.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            tetrisList.Add(tetris);
        }

        EventManager.Instance.applyTetris += ReplaceSlot;
    }

    private void ReplaceSlot(TetrisObject tetrisObject)
    {
       
    }
}
