using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private void OnEnable()
    {
        // ** �ʱ�ȭ

        //**���� �Լ�  = Random.Range(Min, Max)
        //Random.Range(-25, 25)
        this.transform.position = new Vector3(
            Random.Range(-25, 25),
            0.0f,
            Random.Range(-25, 25));

        //** ���̶�Ű�信 �߰��� EnemuList�� �� ���ӿ�����Ʈ�� �θ�� ����
        this.transform.parent = GameObject.Find("EnableList").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
/*
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

 */
   

}
