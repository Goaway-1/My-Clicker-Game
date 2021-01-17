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

    private Vector3 spawnPos = new Vector3(0,1.7f,-1f);  //���� ������ (���� ����)
    int startDropGold = 1;

    public void Start()
    {
        maxHP = EnemyManager.Instance.defineHp();
        currentHP = maxHP;
        Debug.Log("HP:"+maxHP);
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
        Debug.Log("HP :" +  currentHP);
    }
    
    public void ifdead()    //�Ϲ� ���Ͱ� ������
    {
        DataManager.Instance.gold += startDropGold * DataManager.Instance.stage;    //���� �߰�
        DataManager.Instance.stage++;
        EnemyManager.Instance.setExist(false);
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
