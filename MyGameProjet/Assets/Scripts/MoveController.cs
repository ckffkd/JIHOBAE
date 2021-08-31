using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ** �ش� ���۳�Ʈ�� ���� : ���� Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private float Speed;

    private GameObject TargetPoint;

    private bool Move;

    private Vector3 Step;
    private Rigidbody Rigid;



    // ** Enemy ������Ʈ �������� �߰�.
    public GameObject EnemyPrefab;


    void Awake()
    {
        // ** ���� ������Ʈ�� �������� ���۳�Ʈ�� �޾ƿ�
        Rigid = GetComponent<Rigidbody>();

        // ** TargetPoint ��� �̸��� ��ü�� ã�´�.
        // ** �̷��� �޾ƿö����� �̸��� �Ű����Ѵ�.
        // ** ���� �̸��� ��ü�� �ִٸ� ������ ���� �� ����.
        TargetPoint = GameObject.Find("TargetPoint");


        // ** Resources ���� �ȿ� �ִ� ���ҽ��� �ҷ���.
        // ** Resources.Load("���") as GameObject;  <= �� ���� 
        EnemyPrefab = Resources.Load("Prefab/EnemyPrefabs/TurtleShellPBR") as GameObject;
    }

    void Start()
    {
        // ** ���������� �߷��� ��Ȱ��ȭ.
        Rigid.useGravity = false;

        // ** �����Ҷ� TargetPoint ��ġ�� ���� ������Ʈ�� ��ġ�� �ʱ�ȭ
        TargetPoint.transform.position = this.transform.position;

        // ** Step = ���� : �����Ҷ����� �� ������ ���� �ʴ´�.
        Step = new Vector3(0.0f, 0.0f, 0.0f);

        // ** �̵��ӵ�
        Speed = 0.5f;

        // ** Move = �̵����� : �����Ҷ� �������·� ����
        Move = false;



        // ** ���̶�Ű �信 "EnemyList" �̸��� �� ���� ������Ʈ�� �߰�
        //GameObject ViewObject = new GameObject("EnablsList");
        new GameObject("EnableList");
        new GameObject("DisableList");


        for (int i = 0; i < 5; ++i)
        {
            // ** Instantiate = �����Լ�
            // ** EnemyPrefab �� ������Ʈ�� ������
            //GameObject Obj = Instantiate(EnemyPrefab);
            //ObjectManager.GetInstance.AddObject(Obj);

            ObjectManager.GetInstance.AddObject(
                Instantiate(EnemyPrefab));
        }
    }


    private void Update()
    {
        // ** �����̽� Ű �Է��� �޾�����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ** Stack �� �����Ͱ� �����ִ��� Ȯ���ϰ� ���»��¶�� �߰��Ѵ�.
            if (ObjectManager.GetInstance.GetDisableList.Count == 0)
                for (int i = 0; i < 5; ++i)
                    ObjectManager.GetInstance.AddObject(
                        Instantiate(EnemyPrefab));

            // ** GetDisableList �� �ִ� ��ü �ϳ��� ������
            GameObject Obj = ObjectManager.GetInstance.GetDisableList.Pop();

            // ** ������ ��ü�� Ȱ��ȭ ���� �����·� ����
            Obj.gameObject.SetActive(true);

            // ** Ȱ��ȭ�� ������Ʈ�� �����ϴ� ����Ʈ�� ���Խ�Ŵ.
            ObjectManager.GetInstance.GetEnableList.Add(Obj);
        }
        // ** ��Ȱ��ȭ ���¿��� Ȱ��ȭ ���·� �����ϰ�, ����� ������Ʈ�� 
        // ** Ȱ��ȭ�� ������Ʈ�� ���ִ� ����Ʈ���� ����� ���������� ���� �ȴ�.
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            // ** ȭ�鿡 �ִ� ���콺 ��ġ�κ��� Ray�� ���������� ������ �����.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RayPoint(ray);
        }

        // ** Move �� true�϶��� �̵� ������ ���¸� ���Ѵ�.
        if (Move == true)
            // ** Step = ����, Speed = �ӵ� 
            // ** Step �������� Speed ��ŭ �̵���Ŵ
            this.transform.position += Step * Speed;
    }

    void RayPoint(Ray _ray)
    {
        // ** Ray�� Ÿ�ٰ� �浹������ ��ȯ ���� �����ϴ� ��.
        RaycastHit hit;

        // ** Physics.Raycast( Ray���� ��ġ�� ���� , �浹�� ������ ����, Mathf.Infinity = ������)
        // ** �ؼ� : ray�� ��ġ�� �������κ��� RayPoint�� �����ϰ� �߻��ϰ� �⵿�� �Ͼ�� Hit�� ������ ������.
        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Ground")
            {
                // ** �ؼ� : ray�� ��ġ�� ���� hit�� ��ġ���� ���� �׸�. ���� ���ӿ����� �Ⱥ���.
                Debug.DrawLine(_ray.origin, hit.point);
                Debug.Log(hit.point);

                // ** hit�� ��ġ�� Ÿ�� ��ǥ�� �޾ƿ�
                TargetPoint.transform.position = hit.point;

                //** Ÿ���� �����Ǿ����� �����ϼ� �ֵ��� true�� ����
                Move = true;

                // ** Ÿ���� ������ �ٶ󺸴� ���͸� ����.
                Step = TargetPoint.transform.position - this.transform.position;

                // ** ���⸸ �����ְ�
                Step.Normalize();

                // ** ���� ���⿡ Y���� �� ������ ���ֹ���. ���۵� ����.
                Step.y = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ** �浹�� ��ü�� �̸��� TargetPoint �� �ƴ϶�� �����ϰ� TargetPoint �϶� ����.
        if (other.name == "TargetPoint")
            Move = false;

        if (other.tag == "Enemy")
        {
            // ** EnableList�� �ִ� ��ü�� DisableList �� ����
            other.transform.parent = GameObject.Find("DisableList").transform;

            // ** ��ü�� DisableList �̵�
            ObjectManager.GetInstance.GetDisableList.Push(other.gameObject);

            // ** EnableList �� �ִ� ��ü ������ ����
            ObjectManager.GetInstance.GetEnableList.Remove(other.gameObject);

            // ** �̵��� �Ϸ�Ǹ� ��ü�� ��Ȱ��ȭ
            other.gameObject.SetActive(false);
        }
    }
}


