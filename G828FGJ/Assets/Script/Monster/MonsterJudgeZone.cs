using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterJudgeZone : MonoBehaviour
{
    public static MonsterJudgeZone Instance { get; set; }

    [SerializeField] private GameObject Mosnter;
    [SerializeField] private GameObject moveJudgePosition;
    [SerializeField] private GameObject attackJudgePosition;
    [SerializeField] private GameObject[] objectInZone;

    private bool isInMoveZone;
    private bool isInAttackZone;
    private void Update()
    {
        objectInZone = GameObject.FindGameObjectsWithTag("Player");
    }
    private void FixedUpdate()
    {
        isInMoveZone = MovementZone();
        isInAttackZone = AttackZone();

        MonsterAction(isInMoveZone, isInAttackZone);
    }

    private void MonsterAction(bool moveJudge,bool attackJudge)
    {
        if(moveJudge == true&&attackJudge == false)
        {
            Debug.Log("Moving");
        }
        else if(moveJudge == true && attackJudge == true)
        {
            Debug.Log("Attacking");
        }
    }
    private bool MovementZone()
    {
        Vector3 monsterVector = transform.position;
        Vector3 moveJudgeVector = moveJudgePosition.transform.position;
        float moveJudgeZone = Vector3.Distance(monsterVector, moveJudgeVector);

        foreach (GameObject player in objectInZone)
        {
            // 計算玩家與moveJudgeVector的距離
            float playerDistance = Vector3.Distance(player.transform.position, monsterVector);

            // 如果玩家距離在moveJudgeZone內，則執行操作
            if (moveJudgeZone >= playerDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    private bool AttackZone()
    {
        Vector3 monsterVector = transform.position;
        Vector3 attackJudgeVector = attackJudgePosition.transform.position;
        float attackJudgeZone = Vector3.Distance(monsterVector, attackJudgeVector);

        foreach (GameObject player in objectInZone)
        {
            // 計算玩家與moveJudgeVector的距離
            float playerDistance = Vector3.Distance(player.transform.position, monsterVector);

            // 如果玩家距離在moveJudgeZone內，則執行操作
            if (attackJudgeZone >= playerDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;

        Vector3 monsterVector = transform.position;
        Vector3 moveJudgeVector = moveJudgePosition.transform.position;
        Vector3 attackJudgeVector = attackJudgePosition.transform.position;

        float moveJudgeZone = Vector3.Distance(monsterVector, moveJudgeVector);
        float attackJudgeZone = Vector3.Distance(monsterVector, attackJudgeVector);

        UnityEditor.Handles.DrawWireDisc(monsterVector, Vector3.back, moveJudgeZone);
        UnityEditor.Handles.DrawWireDisc(monsterVector, Vector3.back, attackJudgeZone);
    }
}
