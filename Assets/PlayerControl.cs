using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.Log("PlayerControl Instance already exist");
            Destroy(gameObject);
            return;
        }
    }


}
