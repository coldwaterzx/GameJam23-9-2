using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Gun gun;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 movementDirection = Vector2.up;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = GetComponentInChildren<Gun>();
    }
    void Update()
    {
        Shoot();
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vetical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(Horizontal, Vetical) * speed * Time.deltaTime;
        rb.velocity = move;

        if (move != Vector2.zero)
        {
            movementDirection = move.normalized;
        }

    }
    void FaceForward()
    {
        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
            gun.Shoot();
    }



}
