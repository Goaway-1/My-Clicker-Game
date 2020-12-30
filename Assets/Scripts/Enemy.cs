using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //½Ì±ÛÅæ@@@@@@@@@@@@@@@@@@@@@@@
    private static Enemy instance;
    public static Enemy GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<Enemy>();
            if(instance == null)
            {
                GameObject container = new GameObject("Enemy");
                instance = container.AddComponent<Enemy>();
            }
        }
        return instance;
    }
    //½Ì±ÛÅæ@@@@@@@@@@@@@@@@@@@@@@@

    private float m_HP;
    public Vector2 spawnPos = new Vector2(0,-1);  //µµÂø Æ÷Áö¼Ç

    int dropGold = 100;

    public void Start()
    {
        m_HP = EnemyManager.GetInstance().defineHp();
        Debug.Log(m_HP);
    }

    public void Update()
    {
        Move();
        if (m_HP <= 0 && EnemyManager.isExist)
        {
            ifdead();
        }
    }

    public void Move()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, spawnPos,0.1f); //¼öÁ¤
    }

    public void decreased(float power) //Ã¼·Â °¨¼Ò
    {
        m_HP -= power;
    }
    
    public void ifdead()
    {
        Debug.Log("»ç¸Á");
        DataManager.GetInstance().AddGold(dropGold);
        DataManager.GetInstance().AddStage();
        EnemyManager.isExist = false;
        Destroy(this.gameObject);
    }
}
