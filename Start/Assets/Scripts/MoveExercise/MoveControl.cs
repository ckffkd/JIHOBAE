using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class MoveControl : MonoBehaviour
{
    [SerializeField] private float Speed;

    private GameObject TargetPoint;
    private bool Move;
    private Vector3 Step;
    private Rigidbody Rigid;
     
    void Awake()
    {
        Rigid = GetComponent<Rigidbody>();

        TargetPoint = GameObject.Find("TargetPoint");
    }

    void Start()
    {
        Rigid.useGravity = false;
        TargetPoint.transform.position = this.transform.position;
        Step = new Vector3(0.0f, 0.0f, 0.0f);
        Speed = 15.0f;
        Move = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            // ** ȭ�鿡 �ִ� ���콺 ��ġ�κ��� Ray�� ���������� ������ �����.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ** Ray�� Ÿ�ٰ� �浹������ ��ȯ ���� �����ϴ� ��.
            RaycastHit hit;

            // ** Physics.Raycast( Ray���� ��ġ�� ���� , �浹�� ������ ����, Mathf.Infinity = ������)
            // ** �ؼ� : ray�� ��ġ�� �������κ��� RayPoint�� �����ϰ� �߻��ϰ� �⵿�� �Ͼ�� Hit�� ������ ������.
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Ground")
                {
                    // ** �ؼ� : ray�� ��ġ�� ���� hit�� ��ġ���� ���� �׸�. ���� ���ӿ����� �Ⱥ���.
                    Debug.DrawLine(ray.origin, hit.point);
                    Debug.Log(hit.point);

                    TargetPoint.transform.position = hit.point;


                    Move = true;
                    Step = TargetPoint.transform.position - this.transform.position;
                    Step.Normalize();
                    Step.y = 0;
                }
            }
        }

        if (Move == true)
            this.transform.position += Step * Time.deltaTime * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Move = false;
    }
}
