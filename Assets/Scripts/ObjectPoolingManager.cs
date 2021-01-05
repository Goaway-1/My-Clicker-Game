using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;

    public GameObject m_goPrefab = null;    //���⿡ �ؽ�Ʈ�� ����.
    private Queue<GameObject> m_queue = new Queue<GameObject>(); //�����ų ť(���)

    void Start()
    {
        instance = this;
        for (int i = 0; i < 30; i++)    //���� ���� ����
        {
            GameObject t_object = Instantiate(m_goPrefab, Vector3.zero, Quaternion.identity);   //�������� ���ӳ��� ��ü�� �����ѵ� ť�� ����
            m_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }
    }

    public void InsertQueue(GameObject p_object) //����� ��ü�� Ǯ�� �ݳ��ϴ� �Լ�
    {
        m_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetQueue()    //Ǯ���� ��ü�� �ҷ��� ����ϴ� �Լ�
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }
}
