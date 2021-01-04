using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    private Vector3 spwanPos; //effect의 발생 위치pos

    private void Start()
    {
        instance = this;
    }

    public void attckShow()
    {
        GameObject t_object = ObjectPoolingManager.instance.GetQueue();
        t_object.transform.position = randPos();
    }

    private Vector3 randPos()   //pos의 위치를 랜덤으로 한다.
    {
        float a = Random.Range(-0.5f, 0.5f);
        float b = Random.Range(1f, 2f);
        return new Vector3(a, b, -1.1f);
    }
}
