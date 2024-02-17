using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform BulletPrefab;
    public float Radius, Damage=25, FireDelay;
    private float fireTimer;
    private Transform enemy, gun, firePoint;
    public LayerMask EnemyLayer;

    void Start()
    {
        fireTimer = FireDelay;
        gun = transform.GetChild(0);
        firePoint = gun.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
        else if(enemy)
            Fire();
        if(enemy)
        {
            Vector3 lookAt = enemy.position;
            lookAt.y = gun.position.y;
            gun.rotation = Quaternion.LookRotation(gun.position - lookAt);
            if (Vector3.Distance(transform.position, enemy.position) > Radius)
                enemy = null;
        }
        else
        {
           Collider[] colls = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);
            if (colls.Length > 0)
                enemy = colls[0].transform.GetChild(0);
        }

    }
    void Fire()
    {
        Transform bullet = Instantiate(BulletPrefab, firePoint.position, Quaternion.identity);
        bullet.LookAt(enemy);
        bullet.GetComponent<Bullet>().Damage = Damage;
        fireTimer = FireDelay;
    }
}
