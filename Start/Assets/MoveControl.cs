using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
[RequireComponent(typeof(Rigidbody))] //컴퍼넌트에 리지드바디 없어도 강제로 꼽아넣는거
public class MoveControl : MonoBehaviour
{
    [SerializeField] private float Speed;
    private bool Move;
    private Vector3 TargetPoint;
    private Vector3 Step;
    //[SerializeField] private float Force;

    private Rigidbody Rigid; 

     void Awake() //컴퍼넌트를 먼저 받아옴 생성자와 비슷함.
    {
        Rigid = GetComponent<Rigidbody>(); 
    } //Rigidbodey = 물리엔진

     void Start() //수치값은 스타트에서. 이니셜라이즈와 비슷함.
    {
        Rigid.useGravity = false; //스크립트로 컴퍼넌트 받아와서 하는고

        TargetPoint = this.transform.position;
        Step = new Vector3(0.0f, 0.0f, 0.0f);
        Speed = 15.0f;
        Move = false;
        //Force = 2000.0f;

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
        /*
        float fHor = Input.GetAxis("Horizontal"); // 좌우
        float fVer = Input.GetAxis("Vertical"); // 위 아래

        transform.Translate(
            fHor * Time.deltaTime * Speed,
            0.0f,
            fVer * Time.deltaTime * Speed);// 앞뒤로 움직일거니까 z값에 넣어줌
         */


        /*
        //** 마우스 입력 방법.
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("좌 클릭");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("우 클릭");
        }

        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("휠 클릭");
        }
         */

        if (Input.GetMouseButton(1))  
        {
            
             
            
            //** 화면에 있는 마우스 위치로부터 레이저(Ray)를 보내기위해 정보를 기록함.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //** Ray가 타겟과 충돌했을때 반환값을 저장하는 곳.
            RaycastHit hit;

            //** Physics.Raycast(Ray 시작위치와 방향, 충돌한 지점의 정보out hit, Mathf.Infinity== 무한한)
            //** 해석 : ray의 위치와 방향으로부터 RayPoint를 무한하게 발사하고 충돌이 일어나면 hit에 정보를 저장함. 
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.tag == "Ground")
                { 
                    //**해석 : ray의 위치로부터 hit된 위치까지 선을 그림. 
                    Debug.DrawLine(ray.origin, hit.point);
                    Debug.Log(hit.point);

                    //transform.position = new Vector3(hit.point.x, 1.0f, hit.point.z);
                    
                    TargetPoint = hit.point;

                    /*
                    Vector3 Temp = hit.point - ray.origin;
                    Vector3.Normalize(Temp);

                    Temp.x *= 100;
                    Temp.y *= 100;
                    Temp.z *= 100;

                    Debug.DrawLine(ray.origin, Temp, Color.green);
                    */

                    if (this.transform.position.x > TargetPoint.x - 0.5f &&
                        this.transform.position.x < TargetPoint.x + 0.5f &&
                        this.transform.position.z > TargetPoint.z - 0.5f &&
                        this.transform.position.z < TargetPoint.z + 0.5f)
                    {
                        Move = false;
                    }

                    else
                    {
                        Move = true;

                        Step = TargetPoint - this.transform.position;
                        Step.Normalize();
                        Step.y = 0;
                    }
                }
                
            }

        }
         
         
        if(Move == true)
        { 
            this.transform.position += Step;
            
            if (this.transform.position.x > TargetPoint.x - 0.5f &&
                this.transform.position.x < TargetPoint.x + 0.5f &&
                this.transform.position.z > TargetPoint.z - 0.5f &&
                this.transform.position.z < TargetPoint.z + 0.5f)
            {
                Move = false;
                
            } 
        } 
    }
}
