using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotation : MonoBehaviour
{
    private GameObject SunObject;


    private void Awake()
    {
        SunObject = GameObject.Find("Sun");
    }
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = SunObject.transform;
    }


    void Update()
    {
        this.transform.Rotate(this.transform.up * Time.deltaTime * 5.0f);
        
    }
}
