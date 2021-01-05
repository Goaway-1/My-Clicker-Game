using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //@@@@@@@@@@@@@@@@@@½Ì±ÛÅæ
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
    //@@@@@@@@@@@@@@@@@@½Ì±ÛÅæ

    public float maxHP;
    public float currentHP;

    private Vector3 spawnPos = new Vector3(0,1.7f,-1f);  //µµÂø Æ÷Áö¼Ç (ÃßÈÄ ¼öÁ¤)
    int dropGold = 100;

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
        this.transform.position = Vector3.MoveTowards(transform.position, spawnPos,0.1f); //¼öÁ¤
    }

    public void decreased(float power) //Ã¼·Â °¨¼Ò
    {
        currentHP -= power;
    }
    
    public void ifdead()
    {
        Debug.Log("»ç¸Á");
        DataManager.Instance.gold += dropGold;
        DataManager.Instance.stage++;
        EnemyManager.Instance.setExist(false);
        Destroy(this.gameObject);
    }
    //UI°ü·Ã@@@@@
    public void showHp()
    {
        EnemyManager.Instance.hpSlider.value = currentHP / maxHP;
    }
    //UI°ü·Ã@@@@@
}
