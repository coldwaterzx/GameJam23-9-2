using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private float coolTime;
    void Update()
    {
        FaceToMousePoint();
    }
    void FaceToMousePoint()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 v = mouse - obj;
        v.z = 0;
        float angle = Vector3.SignedAngle(Vector3.up, v, Vector3.forward);
        Quaternion quaternion = Quaternion.Euler(0, 0, angle);
        transform.rotation = quaternion;
    }
    void CoolDown()
    {

    }
    public void Shoot()
    {
        if (coolTime <= 0)
            Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
        else return;
    }
}
