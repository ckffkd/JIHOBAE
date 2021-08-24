using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        //** Getter = ��ȯ�� ����
        get
        {
            if (Instance == null)
                Instance = new ObjectManager();

            return Instance;
        }
       
    }
    
    //** ������ private  ����
    private ObjectManager() { }

    //**Enemy ������Ʈ ������ �߰�
    private GameObject EnemyPrefab;

    //** Enemy�� ������ ����Ʈ.
    private List<GameObject> EnemyList = new List<GameObject>();

    private void Awake()
    {
        //���̶�Ű �信 "EnemyList" �̸��� �� ���� ������Ʈ�� �߰�.
        GameObject ViewObject = new GameObject("EnemyList");

        //** Resources ���� �ȿ� �ִ� ���ҽ��� �ҷ���.
        //** Resources.Load("���") as GameObject; <=�� ����.
        EnemyPrefab = Resources.Load("Prefabs/Enemy") as GameObject;
    }

    private void Start()
    { 
        for (int i = 0; i < 5; ++i)
        {
            //** Instance = �����Լ�
            //** EenmeyPrefab�� ������Ʈ�� ������.
            GameObject Obj = Instantiate(EnemyPrefab);

            //** ���̶�Ű�信 �߰��� EnemuList�� �� ���ӿ�����Ʈ�� �θ�� ����
            Obj.transform.parent = GameObject.Find("EnemyList").transform;

            //** EnemyController �̸��� ��ũ��Ʈ�� ������ ������Ʈ�� �߰�.
            Obj.AddComponent<EnemyController>();
             
            
            //x = -25 ~ +25
            //z = -25 ~ +25

            //**���� �Լ�  = Random.Range(Min, Max)
            //Random.Range(-25, 25)

            Obj.transform.position = new Vector3(
                Random.Range(-25, 25),
                0.0f,
                Random.Range(-25, 25));

            EnemyList.Add(Obj);
        }

    }

    
}

//Destroy(this.gameObject);
