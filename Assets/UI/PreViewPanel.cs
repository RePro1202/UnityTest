using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PreViewPanel : MonoBehaviour
{
    [SerializeField]
    private List<RectTransform> previews;

    [SerializeField]
    private List<Transform> spawningPool;

    private void Start()
    {
        foreach (RectTransform preview in previews)
        {
            Transform tetris = Instantiate(spawningPool[0], preview);

            tetris.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        
    }

    
}
