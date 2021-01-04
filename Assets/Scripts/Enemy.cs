using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //@@@@@@@@@@@@@@@@@@�̱���
    private static Enemy instance;
    public static Enemy GetInstance()
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
    //@@@@@@@@@@@@@@@@@@�̱���

    private float maxHP;
    private float currentHP;

    private Vector3 spawnPos = new Vector3(0,1.7f,-1f);  //���� ������ (���� ����)
    int dropGold = 100;

    //hp �����̴� ����
    public Slider hpSlider;
    public GameObject Slider;

    public void Start()
    {
        maxHP = EnemyManager.GetInstance().defineHp();
        currentHP = maxHP;
        Debug.Log("HP:"+maxHP);
    }

    public void Update()
    {
        if (this.transform.position != spawnPos)
        {
            Move();
        }

        if (currentHP <= 0 && EnemyManager.GetInstance().getExist())
        {
            ifdead();
        }
    }

    public void Move()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, spawnPos,0.1f); //����
    }

    public void decreased(float power) //ü�� ����
    {
        currentHP -= power;
    }
    
    public void ifdead()
    {
        Debug.Log("���");
        DataManager.GetInstance().AddGold(dropGold);
        DataManager.GetInstance().AddStage();
        EnemyManager.GetInstance().setExist(false);
        Destroy(this.gameObject);
    }
}
