using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public bool Pause;
    void Awake()
    {
        if (manager == null)
            manager = this;
    }
    void Start()
    {
        Pause = false;
    }

  
}
