using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PreViewPanel : MonoBehaviour
{
    private PreViewSystem preViewSystem;

    [SerializeField]
    private List<RectTransform> previewSlots;

    [SerializeField]
    private List<Transform> spawningPrefabs;

    private void Awake()
    {
        preViewSystem = new PreViewSystem(previewSlots.Count);
    }


    private void Start()
    {
        foreach (RectTransform preview in previewSlots)
        {
            Transform tetris = Instantiate(spawningPrefabs[preViewSystem.GetRandomNum()], preview);

            tetris.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        
    }

    
}
