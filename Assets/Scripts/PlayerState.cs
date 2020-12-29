using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //�̱���;; �������� DataManager������ ���ٰ����ϰ� ����

    //States
    [HideInInspector]
    public float power;   //��
    [HideInInspector]
    public int gold;   //��
    [HideInInspector]
    public float criticalPer; //ġ��Ÿ Ȯ��
    [HideInInspector]
    public float criticalPow; //ġ��Ÿ���
    [HideInInspector]
    public int stage;

    private void Awake()
    {
        power = PlayerPrefs.GetFloat("Power", 1f);
        gold = PlayerPrefs.GetInt("gold", 0);
        criticalPer = PlayerPrefs.GetFloat("criticalPer", 10f);
        criticalPow = PlayerPrefs.GetFloat("criticalPow", 1.42f);
        stage = PlayerPrefs.GetInt("stage",1);
    }
}
