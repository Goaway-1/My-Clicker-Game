using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //�̱���;; �������� DataManager������ ���ٰ����ϰ� ����

    //States
    [HideInInspector]
    public int power;   //��
    [HideInInspector]
    public int gold;   //��
    [HideInInspector]
    public float strikePer; //ġ��Ÿ Ȯ��
    [HideInInspector]
    public float strikePow; //ġ��Ÿ���
    [HideInInspector]
    public int stage;

    private void Awake()
    {
        power = PlayerPrefs.GetInt("Power", 1);
        gold = PlayerPrefs.GetInt("gold", 0);
        strikePer = PlayerPrefs.GetFloat("strikePer", 10f);
        strikePow = PlayerPrefs.GetFloat("strikePow", 1.42f);
        stage = PlayerPrefs.GetInt("stage",1);
    }
}
