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
    public Vector2 startPos;    //시작 포지션-->추후 수정
    public Quaternion quaternion = Quaternion.identity;
    public GameObject[] enemys;
    public static bool isExist = false;
    private float curTime;
    private float spawnTime = 2f;

    private float Hp;
    private float startHp = 10f; //초기 HP
    private float HpPow = 2f; //제곱비

    private void Start()
    {
        startPos = new Vector2(4, -1);
    }
    void Update()
    {
        reSpawn();
    }

    public float defineHp()
    {
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
            isExist = true;
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
}
