using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed, Damage;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Speed*Time.deltaTime );
    }
}
