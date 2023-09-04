using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class PreViewPanel : MonoBehaviour
{
    private PreViewSystem preViewSystem;

    [SerializeField]
    private List<RectTransform> slots;

    [SerializeField]
    private List<Transform> spawningPrefabs;

    private List<Transform> tetrisList;

    private void Awake()
    {
        preViewSystem = new PreViewSystem(slots.Count);
        tetrisList = new List<Transform>();
    }


    private void Start()
    {
        foreach (RectTransform slot in slots)
        {
            Transform tetris = Instantiate(spawningPrefabs[preViewSystem.GetRandomNum()], slot);
            tetris.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            tetrisList.Add(tetris);
        }

        EventManager.Instance.applyTetris += ReplaceSlot;
    }

    private void ReplaceSlot(TetrisObject tetrisObject)
    {
        tetrisList.Remove(tetrisObject.transform);
        tetrisList.Add(Instantiate(spawningPrefabs[preViewSystem.GetRandomNum()]));

        int count = 0;

        foreach(Transform tetris in tetrisList)
        {
            tetris.SetParent(slots[count]);
            tetris.localPosition = Vector3.zero;
            tetris.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            count++;
        }
    }
}
