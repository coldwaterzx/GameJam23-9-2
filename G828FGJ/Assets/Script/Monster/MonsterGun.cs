using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGun : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private float coolTime = 0.25f;
    private float currentCoolTime;

    void Start()
    {
        currentCoolTime = 0;
    }
    void Update()
    {
        CoolDown();
    }
    void CoolDown()
    {
        if (currentCoolTime >= 0)
        {
            currentCoolTime -= Time.deltaTime;
        }
        else return;

    }
    public void Shoot()
    {
        if (currentCoolTime < 0)
        {
            Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
            currentCoolTime = coolTime;
        }
        else return;
    }
}
