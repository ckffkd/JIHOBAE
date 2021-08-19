using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
[RequireComponent(typeof(Rigidbody))] //컴퍼넌트에 리지드바디 없어도 강제로 꼽아넣는거
public class MoveControl : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Force;

    private Rigidbody Rigid; 

     void Awake()
    {
        Rigid = GetComponent<Rigidbody>(); 
    } //Rigidbodey = 물리엔진

     void Start()
    {
        Rigid.useGravity = false; //스크립트로 컴퍼넌트 받아와서 하는고

        Speed = 15.0f;
        Force = 2000.0f;

        //** 힘을 가하여 이동시킴.
        //Rigid.AddForce(Vector3.forward * Force);

        //** Update 함수는 프레임마다 호출 되기 때문에 AddForce 함수를 Update함수에서 호출하게되면
        //** 매 프레임 마다 힘을 가하게 되므로 속도가 가중됨.
    }
    
    void Update()
    {
        // this.transform.Translate
        // (vPosition * Time.deltaTime * Speed );
        // vPosition = Vector3.right

        //**게임 오브젝트 기준으로 이동. (로컬)
        //transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        //** 절대 좌표 기준으로 이동 (월드)
        //transform.Translate(Vector3.forward * Time.deltaTime, Space.World);

        //**물체를 앞쪽 방향으로 이동. (로컬)
        //transform.Translate(0, 0, Time.deltaTime);// Translate(x, y, z)

        //**물체를 앞쪽 방향으로 이동. (월드)
        // transform.Translate(0, 0, Time.deltaTime, Space.World); //Translate(x, y, z, Space);

        //** 카메라를 기준으로 개체를 앞쪽으로 이동.
        //transform.Translate(Vector3.forward * Time.deltaTime, Camera.main.transform);




        //** 키 입력에 의한 이동방법.
        float fHor = Input.GetAxis("Horizontal"); // 좌우
        float fVer = Input.GetAxis("Vertical"); // 위 아래

        transform.Translate(
            fHor * Time.deltaTime * Speed,
            0.0f,
            fVer * Time.deltaTime * Speed);// 앞뒤로 움직일거니까 z값에 넣어줌




    }
}
