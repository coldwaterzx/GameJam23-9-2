using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public GameObject player;

    public float moveSpeed;
    private void FixedUpdate()
    {
        bool timeToMove = MonsterJudgeZone.Instance.isInMoveZone;
        bool timeToAttack = MonsterJudgeZone.Instance.isInAttackZone;

        player = MonsterJudgeZone.Instance.objectInZone;

        if (timeToMove == true && timeToAttack == false)
        {
            this.transform.up = LookAtPlayer();
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, moveSpeed*Time.deltaTime);
            Debug.Log("moving");
        }
        else
        {
            return;
        }
    }

    private Vector3 LookAtPlayer()
    {
        Vector3 rotate = (player.transform.position - transform.position).normalized;
        return rotate;
    }
}
