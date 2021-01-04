using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //�̱���@@@@@@@@@@@@@@@@@@@@@@@
    private static EnemyManager instance;
    public static EnemyManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<EnemyManager>();
            if (instance == null)
            {
                GameObject container = new GameObject("EnemyManager");
                instance = container.AddComponent<EnemyManager>();
            }
        }
        return instance;
    }
    //�̱���@@@@@@@@@@@@@@@@@@@@@@@

    //[HideInInspector]
    public Vector3 startPos;    //���� ������-->���� ����
    public Quaternion quaternion = Quaternion.identity;
    public GameObject[] enemys;
    private bool isExist = false;
    public bool isMove = false; //����� ������
    private float curTime;
    private float spawnTime = 2f;

    private float Hp;
    private float startHp = 10f; //�ʱ� HP
    private float HpPow = 2f; //������


    //���������� ���
    public UIManager ui;                //UI�Ŵ��� ȣ��
    public bool isBoss = false;         //������ �����ǳ�?

    private void Start()
    {
        startPos = new Vector3(4, 1.7f,-1f); //���� ����
    }
    void Update()
    {
        if (isBoss)            //Ÿ�̸Ӹ� ����
        {
            isBoss = false;
            ui.DecreaseTime(); //�ð� ����
        }
        reSpawn();
    }

    public float defineHp()
    {
        if(DataManager.GetInstance().GetStage() % 10 == 0 && isBoss == false)  //10���� stage��� ���� ����
        {
            isBoss = true;
            Debug.Log("@@@@@Boss ����@@@@@");
        }
        Hp = startHp * (int)Mathf.Pow(HpPow, DataManager.GetInstance().GetStage() / 2);
        return Hp;
    }
    
    public void reSpawn() //����� ��� �ð�
    {
        if (!isExist) //�װ� 2�ʵ�
        {
            curTime += Time.deltaTime;
        }
        if (curTime >= spawnTime && !isExist)
        {
            setExist(true); //���Ͱ� �����Ѵ�.
            isMove = true;  //��� ��������
            curTime = 0;
            //Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object;
            Instantiate(enemys[randomEnemy()], startPos, quaternion);
        }
    }
    public int randomEnemy() //������ȣ ����
    {
        int a = Random.Range(0, enemys.Length);
        return a;
    }

    public bool getExist()
    {
        return isExist;
    }
    public void setExist(bool isbool)
    {
        isExist = isbool;
    }
}
