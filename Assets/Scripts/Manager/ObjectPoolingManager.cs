using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;

    public GameObject D_goPrefab = null;    //���⿡ �ؽ�Ʈ�� ����.
 
    private Queue<GameObject> D_queue = new Queue<GameObject>(); //�����ų ť(�������α�)
   
    void Start()
    {
        instance = this;
        GameObject effectpos = GameObject.Find("EffectManager");
        for (int i = 0; i < 30; i++)    //���� ���� ����
        {
            GameObject D_object = Instantiate(D_goPrefab, effectpos.transform, false);   //�������� ���ӳ��� ��ü�� �����ѵ� ť�� ����
            D_queue.Enqueue(D_object);
            D_object.SetActive(false);
        }
    }

    public void InsertQueue(GameObject p_object) //����� ��ü�� Ǯ�� �ݳ��ϴ� �Լ�
    {
        D_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetQueue()    //Ǯ���� ��ü�� �ҷ��� ����ϴ� �Լ�
    {
        GameObject t_object = D_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }
}
