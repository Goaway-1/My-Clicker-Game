using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    private Vector3 spwanPos; //effect�� �߻� ��ġpos

    private void Awake()
    {
        Instance = this;
    }
    public void attckShow() //DamageText�� EnQueue�Ѵ�.
    {
        GameObject t_object = ObjectPoolingManager.instance.GetQueue();
        t_object.transform.position = randPos();
    }

    private Vector3 randPos()   //pos�� ��ġ�� �������� �Ѵ�.
    {
        float a = Random.Range(-0.5f, 0.5f);
        float b = Random.Range(1f, 2f);
        return new Vector3(a, b, -1.1f);
    }
}
