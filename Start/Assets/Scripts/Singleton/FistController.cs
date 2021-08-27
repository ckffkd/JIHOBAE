using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ** �ش� ���۳�Ʈ�� ���� : ���� Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class FistController : MonoBehaviour
{
    private Rigidbody Rigid;


    private void Awake()
    {
        // ** ���� ������Ʈ�� �������� ���۳�Ʈ�� �޾ƿ�
        Rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Rigid.useGravity = false;

        Collider CollObj = GetComponent<SphereCollider>();

        CollObj.isTrigger = true;
        
        Rigid.AddForce(this.transform.forward * 500.0f);
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}