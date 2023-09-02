using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int GameLevel;

    public bool Pause;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        Pause = false;
        GameLevel = 0;
    }


}
