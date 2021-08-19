using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
[RequireComponent(typeof(Rigidbody))] //���۳�Ʈ�� ������ٵ� ��� ������ �žƳִ°�
public class MoveControl : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Force;

    private Rigidbody Rigid; 

     void Awake()
    {
        Rigid = GetComponent<Rigidbody>(); 
    } //Rigidbodey = ��������

     void Start()
    {
        Rigid.useGravity = false; //��ũ��Ʈ�� ���۳�Ʈ �޾ƿͼ� �ϴ°�

        Speed = 15.0f;
        Force = 2000.0f;

        //** ���� ���Ͽ� �̵���Ŵ.
        //Rigid.AddForce(Vector3.forward * Force);

        //** Update �Լ��� �����Ӹ��� ȣ�� �Ǳ� ������ AddForce �Լ��� Update�Լ����� ȣ���ϰԵǸ�
        //** �� ������ ���� ���� ���ϰ� �ǹǷ� �ӵ��� ���ߵ�.
    }
    
    void Update()
    {
        // this.transform.Translate
        // (vPosition * Time.deltaTime * Speed );
        // vPosition = Vector3.right

        //**���� ������Ʈ �������� �̵�. (����)
        //transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        //** ���� ��ǥ �������� �̵� (����)
        //transform.Translate(Vector3.forward * Time.deltaTime, Space.World);

        //**��ü�� ���� �������� �̵�. (����)
        //transform.Translate(0, 0, Time.deltaTime);// Translate(x, y, z)

        //**��ü�� ���� �������� �̵�. (����)
        // transform.Translate(0, 0, Time.deltaTime, Space.World); //Translate(x, y, z, Space);

        //** ī�޶� �������� ��ü�� �������� �̵�.
        //transform.Translate(Vector3.forward * Time.deltaTime, Camera.main.transform);




        //** Ű �Է¿� ���� �̵����.
        float fHor = Input.GetAxis("Horizontal"); // �¿�
        float fVer = Input.GetAxis("Vertical"); // �� �Ʒ�

        transform.Translate(
            fHor * Time.deltaTime * Speed,
            0.0f,
            fVer * Time.deltaTime * Speed);// �յڷ� �����ϰŴϱ� z���� �־���




    }
}
