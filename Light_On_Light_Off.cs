using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_On_Light_Off : MonoBehaviour
{
    private Light myLight;
    public Material[] material;
    public int flash_trigger;
    Renderer rend;
    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames;
    private float fps;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = material[0];
        // Game0bject go = GameObject.Find("Directional Light");
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
        GUIStyle _style = new GUIStyle();
        _style.fontSize = 110;

    }
    void OnGUI()
    {
       
        GUILayout.Label("" + fps.ToString("f2"));
        
    }
 
    void Update()
    {
        var flashVal = Day_Night.flash;
        //if (Input.GetKeyUp(KeyCode.Space))
        if(flashVal>0 & flashVal!=flash_trigger)
        {
            myLight.enabled = !myLight.enabled;
            flash_trigger++;
            if(rend.sharedMaterial ==material[0])
            {
                rend.sharedMaterial = material[1];
            }
            else
            {
                rend.sharedMaterial = material[0];
            }
        }
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }

    }
}
