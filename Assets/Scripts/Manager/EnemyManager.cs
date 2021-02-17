using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    //�̱���@@@@@@@@@@@@@@@@@@@@@@@
    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
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

    //HP ����
    private float n_Hp = 0f;        //�����͸� �ҷ��ö� ����Ѵ�.
    private float HpPow = 0.4f; //������

    //���������� ���
    public UIManager ui;                //UI�Ŵ��� ȣ��
    public bool isBoss = false;         //������ �����ǳ�?

    //hp �����̴� ����
    public Slider hpSlider;

    private void Start()
    {
        startPos = new Vector3(4, 1.7f,-1f); //���� ����
    }
    void FixedUpdate()
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
        n_Hp = DataManager.Instance.Hp;         //�����Ҷ� �ҷ��´�.
        if (DataManager.Instance.stage % 10 == 0 && isBoss == false)  //10���� stage��� ���� ����
        {
            isBoss = true;
        }
        if(DataManager.Instance.stage % 10 == 1)
        {
            DataManager.Instance.subHp = n_Hp;
            Debug.Log("����" + DataManager.Instance.subHp);
        }
        n_Hp += DataManager.Instance.fixHp * Mathf.Pow(DataManager.Instance.fixHp, HpPow / DataManager.Instance.stage); 
        return n_Hp;
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
            Instantiate(enemys[randomEnemy()], startPos, quaternion);
            //GameObject t_object = ObjectPoolingManager.instance.EGetQueue(); //������ƮǮ������
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