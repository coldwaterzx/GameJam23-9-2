using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int GameLevel;
    [SerializeField] private GameObject[] levelTrigger;
    [SerializeField] private int[] enemyCount;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        GameLevel = 0;
        for (int i = 0; i < levelTrigger.Length; i++)
        {
            levelTrigger[i].gameObject.SetActive(false);
        }
      

    }
    void Update()
    {
        DetectLevelAndEnemy();
    }
    void DetectLevelAndEnemy()
    {
        int e = GameManager.instance.enemyDie;
        int currentCount = enemyCount[GameLevel];
        if (e >= currentCount)
        {
            levelTrigger[GameLevel].gameObject.SetActive(true);
            GameLevel += 1;

         

        }
    }
}
