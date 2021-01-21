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

    int r_gold;     //random Gold

    private Vector3 spawnPos = new Vector3(0,1.7f,-1f);  //도착 포지션 (추후 수정)

    public void OnEnable()
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
        this.transform.position = Vector3.MoveTowards(transform.position, spawnPos,0.1f); //수정
    }

    public void decreased(float power) //체력 감소
    {
        currentHP -= power;
    }
    
    public void ifdead()    //일반 몬스터가 죽을때
    {
        r_gold = Random.Range(DataManager.Instance.goldPerTake, DataManager.Instance.goldPerTake + 2);   //+1까지만 지원
        DataManager.Instance.gold += r_gold;    //추후 추가
        DataManager.Instance.stage++;
        EnemyManager.Instance.setExist(false);

        //Hp 관련
        DataManager.Instance.Hp = maxHP;
        DataManager.Instance.fixHp += 5;    //Hp 증가
        Destroy(this.gameObject);
        //ObjectPoolingManager.instance.EInsertQueue(gameObject); //오브젝트풀링수정 
    }
    public void bossNotDead()   //보스가 죽지 않았을때의 판전
    {
        EnemyManager.Instance.setExist(false);
        Destroy(this.gameObject);
        //ObjectPoolingManager.instance.EInsertQueue(gameObject);  //오브젝트풀링수정
    }
    //UI관련@@@@@
    public void showHp()
    {
        EnemyManager.Instance.hpSlider.value = currentHP / maxHP;
    }
    //UI관련@@@@@
}
