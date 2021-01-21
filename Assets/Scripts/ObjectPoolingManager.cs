using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;

    public GameObject D_goPrefab = null;    //���⿡ �ؽ�Ʈ�� ����.
 
    private Queue<GameObject> D_queue = new Queue<GameObject>(); //�����ų ť(�������α�)
    //private Queue<GameObject> E_queue = new Queue<GameObject>(); //�����ų ť(����)  //������������ EnemyManager���� �ҷ��´�.

    void Start()
    {
        instance = this;
        for (int i = 0; i < 30; i++)    //���� ���� ����
        {
            GameObject D_object = Instantiate(D_goPrefab, Vector3.zero, Quaternion.identity);   //�������� ���ӳ��� ��ü�� �����ѵ� ť�� ����
            D_queue.Enqueue(D_object);
            D_object.SetActive(false);
        }

        //for (int i = 0; i < EnemyManager.Instance.enemys.Length; i++)  //����
        //{
        //    GameObject E_object = Instantiate(EnemyManager.Instance.enemys[i], Vector3.zero, Quaternion.identity);
        //    E_queue.Enqueue(E_object);
        //    E_object.SetActive(false);
        //}
    }

    public void InsertQueue(GameObject p_object) //����� ��ü�� Ǯ�� �ݳ��ϴ� �Լ�
    {
        D_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }
    
    //public void EInsertQueue(GameObject p_object)
    //{
    //    E_queue.Enqueue(p_object);
    //    p_object.SetActive(false);
    //}

    public GameObject GetQueue()    //Ǯ���� ��ü�� �ҷ��� ����ϴ� �Լ�
    {
        GameObject t_object = D_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }

    //public GameObject EGetQueue()    //Ǯ���� ��ü�� �ҷ��� ����ϴ� �Լ�
    //{
    //    GameObject t_object = E_queue.Dequeue();
    //    t_object.SetActive(true);
    //    return t_object;
    //}
}
