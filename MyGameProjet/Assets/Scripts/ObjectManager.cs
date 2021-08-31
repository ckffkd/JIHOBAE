using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    // ** �̱��� ���� 
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance 
    {
        // ** Getter = ��ȯ�� ����
        get
        {
            if (Instance == null)
                Instance = new ObjectManager();

            return Instance;
        }
    }


    // ** ������ private ���� : �ܺλ����� ������� ����.
    private ObjectManager() { }

    

    // ** Enemy�� ������ ����Ʈ.
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

    // ** ������Ʈ�� ����Ʈ�� �߰�.
    public void AddObject(GameObject _Object) 
    {
        // ** EnemyController �̸��� ��ũ��Ʈ�� ������ ������Ʈ�� �߰�
        _Object.AddComponent<EnemyController>();

        // ** ���̶�Ű�ο� �߰��� EnemyList�� �� ���ӿ�����Ʈ�� �θ�� ���� : ��������
        _Object.transform.parent = GameObject.Find("DisableList").transform;

        // ** ������ Enemy�� �浹ü�� �ִ� Trigger ����� ��.
        _Object.GetComponent<BoxCollider>().isTrigger = true;

        // ** ������ ������Ʈ�� ��Ȱ��ȭ ����
        _Object.gameObject.SetActive(false);

        // ** ����Ʈ�� �߰�
        //EnemyList.Add(Obj);
        DisableList.Push(_Object);
    }
}
