using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //싱글톤@@@@@@@@@@@@@@@@@@@@@@@
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
    //싱글톤@@@@@@@@@@@@@@@@@@@@@@@

    //[HideInInspector]
    public Vector3 startPos;    //시작 포지션-->추후 수정
    public Quaternion quaternion = Quaternion.identity;
    public GameObject[] enemys;
    private bool isExist = false;
    public bool isMove = false; //배경의 움직임
    private float curTime;
    private float spawnTime = 2f;

    private float Hp;
    private float startHp = 10f; //초기 HP
    private float HpPow = 2f; //제곱비


    //보스생성시 사용
    public UIManager ui;                //UI매니저 호출
    public bool isBoss = false;         //보스가 생성되냐?

    private void Start()
    {
        startPos = new Vector3(4, 1.7f,-1f); //추후 수정
    }
    void Update()
    {
        if (isBoss)            //타이머를 실행
        {
            isBoss = false;
            ui.DecreaseTime(); //시간 감소
        }
        reSpawn();
    }

    public float defineHp()
    {
        if(DataManager.GetInstance().GetStage() % 10 == 0 && isBoss == false)  //10단위 stage라면 보스 출현
        {
            isBoss = true;
            Debug.Log("@@@@@Boss 출현@@@@@");
        }
        Hp = startHp * (int)Mathf.Pow(HpPow, DataManager.GetInstance().GetStage() / 2);
        return Hp;
    }
    
    public void reSpawn() //재생성 대기 시간
    {
        if (!isExist) //죽고 2초뒤
        {
            curTime += Time.deltaTime;
        }
        if (curTime >= spawnTime && !isExist)
        {
            setExist(true); //몬스터가 존재한다.
            isMove = true;  //배경 움직여라
            curTime = 0;
            //Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object;
            Instantiate(enemys[randomEnemy()], startPos, quaternion);
        }
    }
    public int randomEnemy() //랜덤번호 지정
    {
        int a = Random.Range(0, enemys.Length);
        return a;
    }

    public bool getExist()
    {
        return isExist;
    }
    public void setExist(bool isbool)
    {
        isExist = isbool;
    }
}
