using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SphereMoveController : MonoBehaviour
{ 
    private Rigidbody Rigid;

    void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Rigid.useGravity = false;
        Rigid.AddForce(Vector3.forward * 500.0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }
     */
}
