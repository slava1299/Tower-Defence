using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{
    public Material MainMat, CanMat, CantMat;
    public GameObject TowerPrefab;
    public bool CanBuild;
    private Renderer rener;
  

    private void Start()
    {
        rener = GetComponent<Renderer>();
    }

    private void OnMouseUp()
    {
        if(CanBuild)
        {
            Instantiate(TowerPrefab, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            CanBuild = false;
        }
            
        
    }
    private void OnMouseOver()
    {
        if (CanBuild)
            rener.material = CanMat;
        else
            rener.material = CantMat;

    }
    private void OnMouseExit()
    {
        rener.material = MainMat;
    }

}
