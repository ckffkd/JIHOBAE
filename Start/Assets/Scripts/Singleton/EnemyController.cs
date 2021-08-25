using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private void OnEnable()
    {
        // ** 초기화

        //**난수 함수  = Random.Range(Min, Max)
        //Random.Range(-25, 25)
        this.transform.position = new Vector3(
            Random.Range(-25, 25),
            0.0f,
            Random.Range(-25, 25));

        //** 하이라키뷰에 추가된 EnemuList의 빈 게임오브젝트를 부모로 셋팅
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
