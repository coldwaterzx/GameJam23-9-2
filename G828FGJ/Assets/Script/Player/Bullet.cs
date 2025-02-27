using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    private float destroyTime = 5;
    
    void FixedUpdate()
    {
        if (GameManager.instance.Pause)
        {

        }
        else if (!GameManager.instance.Pause)
        {
            Move();
            Die();
        }

    }
    void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); ;
    }

    void Die()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0)
            Destroy(gameObject);
    }


}
