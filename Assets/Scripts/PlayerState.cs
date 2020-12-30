using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //싱글톤;; 하지말고 DataManager에서만 접근가능하게 하자

    //States
   // [HideInInspector]
    public float power;   //힘
   // [HideInInspector]
    public int gold;   //돈
    //[HideInInspector]
    public float criticalPer; //치명타 확률
   // [HideInInspector]
    public float criticalPow; //치명타배수
   // [HideInInspector]
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
