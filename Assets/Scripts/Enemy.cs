using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //@@@@@@@@@@@@@@@@@@�̱���
    private static Enemy instance;
    public static Enemy Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Enemy>();
                if (instance == null)
                {
                    GameObject container = new GameObject("Enemy");
                    instance = container.AddComponent<Enemy>();
                }
            }
            return instance;
        }
    }
    //@@@@@@@@@@@@@@@@@@�̱���

    public float maxHP;
    public float currentHP;

    int r_gold;     //random Gold

    private Vector3 spawnPos = new Vector3(0,1.7f,-1f);  //���� ������ (���� ����)

    public void Start()
    {
        maxHP = EnemyManager.Instance.defineHp();
        currentHP = maxHP;
        Debug.Log(maxHP);
    }

    public void Update()
    {
        if (this.transform.position != spawnPos)
        {
            Move();
        }

        if (currentHP <= 0 && EnemyManager.Instance.getExist())
        {
            ifdead();
        }
        showHp();
    }

    public void Move()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, spawnPos,0.1f); //����
    }

    public void decreased(float power) //ü�� ����
    {
        currentHP -= power;
    }
    
    public void ifdead()    //�Ϲ� ���Ͱ� ������
    {
        r_gold = Random.Range(DataManager.Instance.goldPerTake, DataManager.Instance.goldPerTake + 2);   //+1������ ����
        DataManager.Instance.gold += r_gold;    //���� �߰�
        DataManager.Instance.stage++;
        EnemyManager.Instance.setExist(false);

        //Hp ����
        DataManager.Instance.Hp = maxHP;
        DataManager.Instance.fixHp += 5;    //Hp ����
        Destroy(this.gameObject);
    }
    public void bossNotDead()   //������ ���� �ʾ������� ����
    {
        EnemyManager.Instance.setExist(false);
        Destroy(this.gameObject);
    }
    //UI����@@@@@
    public void showHp()
    {
        EnemyManager.Instance.hpSlider.value = currentHP / maxHP;
    }
    //UI����@@@@@
}
