using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour
{

    public GameObject WayPoint; //WayPoint ��� �ӹ����ִٰ� �ٸ�waypoint�� �����̴� ����
   
    private bool Move;

    private Vector3 Step;

    private float Speed;

    private Rigidbody Rigid;

    //** Enemy ������Ʈ �������� �߰�.
    public GameObject FistPrefab;

    //** �Ѿ˹߻� Ȯ��
    private bool FistallCheck;

   // private float IdelTime; Coroutine ���� �̰� ���� �ʿ����

    private void Awake()
    {
        //** ���� ������Ʈ�� �������� ���۳�Ʈ�� �޾ƿ�
        Rigid = GetComponent<Rigidbody>();

        //** WayPoint��� �̸��� ������ ��ǥ������ ����.
        WayPoint = new GameObject("WayPoint");

        //** WayPoint�� tag�� WayPoint�� ����.
        WayPoint.transform.tag = "WayPoint";

        //** ������ ��ǥ������ �ݶ��̴��� ����.
        WayPoint.AddComponent<SphereCollider>();

        //** ���Ե� �ݶ��̴��� ������ �޾ƿ�.
        SphereCollider Sphere = WayPoint.GetComponent<SphereCollider>();
        
        //** �ݶ��̴��� ũ�⸦ ����
        Sphere.radius = 0.2f;

        //** isTrigger Ȱ��ȭ
        Sphere.isTrigger = true;

        //** Resources ���� �ȿ� �ִ� ���ҽ��� �ҷ���.
        //** Resources.Load("���") as GameObject; <=�� ����.
        FistPrefab = Resources.Load("Prefabs/Fist") as GameObject;

    }


    private void Start()
    {
        //** ������ �ð�.
        //IdelTime = 3.0f;

        Speed = 0.05f;

        FistallCheck = false;

        Rigid.useGravity = false;
          

        this.transform.parent = GameObject.Find("EnableList").transform;
        
        //** ���� �ڽ��� ��ġ / ���� �Լ�  = Random.Range(Min, Max) .
        //Random.Range(-25, 25)
        this.transform.position = new Vector3(
            Random.Range(-25, 25),
            0.0f,
            Random.Range(-25, 25));

        Initialize();

        //** Coroutine ����.
        StartCoroutine("Fistall");
         
    }

    private void OnEnable()
    {
        this.transform.parent = GameObject.Find("EnableList").transform;

        //** ���� �ڽ��� ��ġ / ���� �Լ�  = Random.Range(Min, Max) .
        //Random.Range(-25, 25)
        this.transform.position = new Vector3(
            Random.Range(-25, 25),
            0.0f,
            Random.Range(-25, 25));

        Initialize(); 
    }

    private void Update()
    { 
        if(FistallCheck == true)
        {
            GameObject Obj = Instantiate(FistPrefab);
             
            //** FistController �̸��� ��ũ��Ʈ�� ������ ������Ʈ�� �߰�.
            Obj.gameObject.AddComponent<FistController>();
              
            //** �Ѿ��� �ѹ��� �߻� �ǵ��� ����.
            FistallCheck = false; 

            Obj.gameObject.transform.position = this.transform.position;

            Obj.gameObject.transform.LookAt(WayPoint.transform.position);

            //** Coroutine ����.
            StartCoroutine("Fistall"); 
        }

    }

    private void FixedUpdate()
    {
        if( Move == true )
        {
            this.transform.position += Step * Speed;
            Debug.DrawLine(
                this.transform.position, 
                WayPoint.transform.position);
        }
        
    }

    private void Initialize()
    {
        
        //** �̵���ǥ��ġ / ���� �Լ�  = Random.Range(Min, Max) .
        WayPoint.transform.position = new Vector3(
            Random.Range(-25, 25),
            0.0f,
            Random.Range(-25, 25));
         
         
        //** Ÿ���� �����Ǿ����� ������ �� �ֵ��� true�� ����
        Move = true;

        //** Ÿ���� ������ �ٶ󺸴� ���͸� ����
        Step = WayPoint.transform.position - this.transform.position;

        //** ���⸸ �����ְ�~~
        Step.Normalize();

        //** ���� ���⿡ Y���� �� ������ ���ֹ���. ���۵� ����(ĸ�� �͸�����)
        Step.y = 0;
        
        //**
        WayPoint.transform.position.Set(
                WayPoint.transform.position.x,
                0.0f, 
                WayPoint.transform.position.z);

        //** ��ü�� �ش������ �Ĵٺ�.
        this.transform.LookAt(WayPoint.transform.position); 

    }

    private void OnTriggerEnter(Collider other)
    {  
        if(other.tag == "WayPoint")
        {
            Move = false;
            StartCoroutine("EnemyState");
        }

        //�Ѿ˿� �̰� �־ �΋H���� ���Ѿ˾������Ը����
        if(other.tag == "Ground")
        {
            Destroy(other.gameObject);
        } 
    }

    IEnumerator Fistall()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));

        FistallCheck = true;
         
    }


    IEnumerator EnemyState()
    { 
        yield return new WaitForSeconds(Random.Range(3, 5));

        Initialize();
    } 
}
