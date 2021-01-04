using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //@@@@@@@@@@@@@@@@@@싱글톤
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
    //@@@@@@@@@@@@@@@@@@싱글톤

    private float maxHP;
    private float currentHP;

    private Vector3 spawnPos = new Vector3(0,1.7f,-1f);  //도착 포지션 (추후 수정)
    int dropGold = 100;

    //hp 슬라이더 관련
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
        this.transform.position = Vector3.MoveTowards(transform.position, spawnPos,0.1f); //수정
    }

    public void decreased(float power) //체력 감소
    {
        currentHP -= power;
    }
    
    public void ifdead()
    {
        Debug.Log("사망");
        DataManager.GetInstance().AddGold(dropGold);
        DataManager.GetInstance().AddStage();
        EnemyManager.GetInstance().setExist(false);
        Destroy(this.gameObject);
    }
}
