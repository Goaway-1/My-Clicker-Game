using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�̱���@@@@@@@@@@@@@@@@@@@@@@@
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
    //�̱���@@@@@@@@@@@@@@@@@@@@@@@

    private float m_HP;

    int dropGold = 100;

    public void Start()
    {
        m_HP = EnemyManager.GetInstance().defineHp();
        Debug.Log(m_HP);
    }

    public void decreased(float power) //ü�� ����
    {
        m_HP -= power;
        if (m_HP <= 0 && EnemyManager.isExist)
        {
            ifdead();
        }
    }
    
    public void ifdead()
    {
        Debug.Log("���");
        DataManager.GetInstance().AddGold(dropGold);
        DataManager.GetInstance().AddStage();
        EnemyManager.isExist = false;
        Destroy(this.gameObject);
    }
}
