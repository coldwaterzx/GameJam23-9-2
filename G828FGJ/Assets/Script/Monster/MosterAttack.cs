using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterAttack : MonoBehaviour
{
    [SerializeField] private MonsterGun MonsterAttack;
    private void Awake()
    {
        MonsterAttack = GetComponentInChildren<MonsterGun>();
    }
    private void FixedUpdate()
    {
        bool timeToMove = MonsterJudgeZone.Instance.isInMoveZone;
        bool timeToAttack = MonsterJudgeZone.Instance.isInAttackZone;

        if (timeToMove == true && timeToAttack == true)
        {
            MonsterAttack.Shoot();
            Debug.Log("attacking");
        }
        else
        {
            return;
        }
    }
}
