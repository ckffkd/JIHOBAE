using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{
    private GameObject EarthObject;


    private void Awake()
    {
        EarthObject = GameObject.Find("Earth");
    }
   
    void Start()
    {
        this.transform.parent = EarthObject.transform;
    }

   
    void Update()
    {
        
    }
}
