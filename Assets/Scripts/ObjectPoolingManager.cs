using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;

    public GameObject D_goPrefab = null;    //여기에 텍스트가 들어간다.
 
    private Queue<GameObject> D_queue = new Queue<GameObject>(); //저장시킬 큐(데미지로그)
   
    void Start()
    {
        instance = this;
        GameObject effectpos = GameObject.Find("EffectManager");
        for (int i = 0; i < 30; i++)    //추후 개수 수정
        {
            GameObject D_object = Instantiate(D_goPrefab, effectpos.transform, false);   //프리펩을 게임내의 객체로 생성한뒤 큐에 저장
            D_queue.Enqueue(D_object);
            D_object.SetActive(false);
        }
    }

    public void InsertQueue(GameObject p_object) //사용한 객체를 풀에 반납하는 함수
    {
        D_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetQueue()    //풀에서 객체를 불러와 사용하는 함수
    {
        GameObject t_object = D_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }

    //public GameObject EGetQueue()    //풀에서 객체를 불러와 사용하는 함수
    //{
    //    GameObject t_object = E_queue.Dequeue();
    //    t_object.SetActive(true);
    //    return t_object;
    //}
}
