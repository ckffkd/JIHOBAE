using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager //: MonoBehaviour
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
 
    //** Enemy�� ������ ����Ʈ.
    //private List<GameObject> EnemyList = new List<GameObject>();

    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }


    private Stack<GameObject> DisableList = new Stack<GameObject>();
    public Stack<GameObject> GetDisableList
    {
        get
        {
            return DisableList;
        }
    }


   
    //** ������Ʈ�� ����Ʈ�� �߰�.
    public void AddObject(GameObject _Object)
    {
        
        //** Instance = �����Լ�
        //** EenmeyPrefab�� ������Ʈ�� ������.
        //GameObject Obj = Instantiate(EnemyPrefab);
        
        //** EnemyController �̸��� ��ũ��Ʈ�� ������ ������Ʈ�� �߰�.
        _Object.AddComponent<EnemyController>();
        
        //** ���̶�Ű�信 �߰��� EnemuList�� �� ���ӿ�����Ʈ�� �θ�� ����
        _Object.transform.parent = GameObject.Find("DisableList").transform;
        
        //** ������ Enemy�� �浹ü�� �ִ� Ʈ���� ����� ��.
        //** ��ǻ� ������ �Ǵ� �ڵ�
        _Object.GetComponent<BoxCollider>().isTrigger = true;

        //**���� �Լ�  = Random.Range(Min, Max)
        //Random.Range(-25, 25)
        _Object.transform.position = new Vector3(
            Random.Range(-25, 25),
            0.0f,
            Random.Range(-25, 25));

        //** ������ ������Ʈ�� ��Ȱ��ȭ ����.
        _Object.SetActive(false);
        
        
        //**����Ʈ�� �߰�.
        //EnemyList.Add(Obj);
        DisableList.Push(_Object);
        
    }   

}

//Destroy(this.gameObject);
