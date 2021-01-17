using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //@@@@@@@@@@@@@@@@@@싱글톤
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
    //@@@@@@@@@@@@@@@@@@싱글톤

    public float maxHP;
    public float currentHP;

    private Vector3 spawnPos = new Vector3(0,1.7f,-1f);  //도착 포지션 (추후 수정)
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
        this.transform.position = Vector3.MoveTowards(transform.position, spawnPos,0.1f); //수정
    }

    public void decreased(float power) //체력 감소
    {
        currentHP -= power;
        Debug.Log("HP :" +  currentHP);
    }
    
    public void ifdead()    //일반 몬스터가 죽을때
    {
        DataManager.Instance.gold += startDropGold * DataManager.Instance.stage;    //추후 추가
        DataManager.Instance.stage++;
        EnemyManager.Instance.setExist(false);
        Destroy(this.gameObject);
    }
    public void bossNotDead()   //보스가 죽지 않았을때의 판전
    {
        EnemyManager.Instance.setExist(false);
        Destroy(this.gameObject);
    }
    //UI관련@@@@@
    public void showHp()
    {
        EnemyManager.Instance.hpSlider.value = currentHP / maxHP;
    }
    //UI관련@@@@@
}
