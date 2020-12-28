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

    public Transform spawnPos;
    public GameObject[] enemys;
    public static bool isExist = false;
    private float curTime;
    private float spawnTime = 2f;

    private float Hp;
    private float startHp = 10f; //�ʱ� HP
    private float HpPow = 2f; //������


    void Update()
    {
        reSpawn();
    }

    public float defineHp()
    {
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
            isExist = true;
            curTime = 0;
            Instantiate(enemys[randomEnemy()], spawnPos);
        }
    }
    public int randomEnemy() //������ȣ ����
    {
        int a = Random.Range(0, 2);
        return a;
    }
}
