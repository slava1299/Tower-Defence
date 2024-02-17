using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Crabmonster CrabmonsterPrefab;
    public float SpawnDelay;
    public Transform[] Points;
    private float timer;
    public float volna;
    public float mob_destroy;
    void Start()
    {

        timer = SpawnDelay;


    }

   
    void Update()
    {

        var mob_destr = Crabmonster.destroy_mob;
        mob_destroy = mob_destr;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Crabmonster crabmonster = Instantiate(CrabmonsterPrefab, transform.position, Quaternion.identity);
            crabmonster.Points = Points;
            timer = SpawnDelay;
        }

    }
}
