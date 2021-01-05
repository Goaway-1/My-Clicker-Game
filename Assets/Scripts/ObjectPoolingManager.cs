using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;

    public GameObject m_goPrefab = null;    //여기에 텍스트가 들어간다.
    private Queue<GameObject> m_queue = new Queue<GameObject>(); //저장시킬 큐(장소)

    void Start()
    {
        instance = this;
        for (int i = 0; i < 30; i++)    //추후 개수 수정
        {
            GameObject t_object = Instantiate(m_goPrefab, Vector3.zero, Quaternion.identity);   //프리펩을 게임내의 객체로 생성한뒤 큐에 저장
            m_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }
    }

    public void InsertQueue(GameObject p_object) //사용한 객체를 풀에 반납하는 함수
    {
        m_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetQueue()    //풀에서 객체를 불러와 사용하는 함수
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }
}
