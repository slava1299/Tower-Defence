using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night : MonoBehaviour
{
    public int fps;
    public static float flash;
   
    void Start()
    {
        Vector3 rotaion = transform.rotation.eulerAngles;
    }

    
    void Update()
    {
        transform.Rotate(1f* Time.deltaTime, 0f, 0f);
        fps++;
        if (fps == 1000)
        { flash++; fps = 0; }

    }
}
