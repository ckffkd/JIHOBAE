using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        //** Getter = 반환만 가능
        get
        {
            if (Instance == null)
                Instance = new ObjectManager();

            return Instance;
        }
       
    }
    
    //** 생성자 private  셋팅
    private ObjectManager() { }

    //**Enemy 오브젝트 프리팹 추가
    private GameObject EnemyPrefab;

    //** Enemy를 관리할 리스트.
    private List<GameObject> EnemyList = new List<GameObject>();

    private void Awake()
    {
        //하이라키 뷰에 "EnemyList" 이름의 빈 게임 오브젝트를 추가.
        GameObject ViewObject = new GameObject("EnemyList");

        //** Resources 폴더 안에 있는 리소스를 불러옴.
        //** Resources.Load("경로") as GameObject; <=의 형태.
        EnemyPrefab = Resources.Load("Prefabs/Enemy") as GameObject;
    }

    private void Start()
    { 
        for (int i = 0; i < 5; ++i)
        {
            //** Instance = 복제함수
            //** EenmeyPrefab의 오브젝트를 복제함.
            GameObject Obj = Instantiate(EnemyPrefab);

            //** 하이라키뷰에 추가된 EnemuList의 빈 게임오브젝트를 부모로 셋팅
            Obj.transform.parent = GameObject.Find("EnemyList").transform;

            //** EnemyController 이름의 스크립트를 복제된 오브젝트에 추가.
            Obj.AddComponent<EnemyController>();
             
            
            //x = -25 ~ +25
            //z = -25 ~ +25

            //**난수 함수  = Random.Range(Min, Max)
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
