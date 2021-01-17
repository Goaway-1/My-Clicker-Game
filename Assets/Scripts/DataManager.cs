using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour //끌어다 쓰는 느낌
{
    //싱글톤@@@@@@@@@@@@@@@@@@@@@@@@@
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("DataManager");
                    instance = container.AddComponent<DataManager>();
                }
            }
            return instance;
        }
    }
    //싱글톤@@@@@@@@@@@@@@@@@@@@@@@@@

    //[HideInInspector]
    public float power  //힘
    {
        get
        {
            return PlayerPrefs.GetFloat("power", 1f);
        }
        set
        {
            PlayerPrefs.SetFloat("power", value);
        }
    }
    [HideInInspector]
    public float AutoC  //자동 클릭 시간
    {
        get
        {
            return PlayerPrefs.GetFloat("auto", 1f);
        }
        set
        {
            PlayerPrefs.SetFloat("auto", value);
        }
    }
    //[HideInInspector]
    public int gold  //돈
    {
        get
        {
            return PlayerPrefs.GetInt("gold", 0);
        }
        set
        {
            PlayerPrefs.SetInt("gold", value);
        }
    }
    //[HideInInspector]
    public float criticalPer //치명타 확률
    {
        get
        {
            return PlayerPrefs.GetFloat("criticalPer", 0.1f);
        }
        set
        {
            PlayerPrefs.SetFloat("criticalPer", value);
        }
    }
    // [HideInInspector]
    public float criticalPow //치명타배수
    {
        get
        {
            return PlayerPrefs.GetFloat("criticalPow", 0);
        }
        set
        {
            PlayerPrefs.SetFloat("criticalPow", value);
        }
    }
    // [HideInInspector]
    public int stage
    {
        get
        {
            return PlayerPrefs.GetInt("stage", 1);
        }
        set
        {
            PlayerPrefs.SetInt("stage", value);
        }
    }

    //Critical 관련@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadC_Button(CriticalButton criticalButton) //critical업글 불러오기
    {
        string key = criticalButton.upgradeName;

        criticalButton.currentCost = PlayerPrefs.GetInt(key + "_cost", criticalButton.startCurrentCost);
        criticalButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveC_Button(CriticalButton criticalButton) //critical업글 저장하기
    {
        string key = criticalButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", criticalButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", criticalButton.level);
    }

    public void LoadC_Per_Button(CriticalPerButton criticalPerButton) //critical업글 불러오기
    {
        string key = criticalPerButton.upgradeName;

        criticalPerButton.currentCost = PlayerPrefs.GetInt(key + "_cost", criticalPerButton.startCurrentCost);
        criticalPerButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveC_Per_Button(CriticalPerButton criticalPerButton) //critical업글 저장하기
    {
        string key = criticalPerButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", criticalPerButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", criticalPerButton.level);
    }

    public void increasedCritical (float startPow , float costPow, int level) //CriticalPow 증가(수정)
    { 
        criticalPow += startPow * Mathf.Pow(costPow, level);
    }
    public void increasedCriticalPer(float startPer, float costPow, int level) //CriticalPer 증가(수정)
    {
        criticalPer += startPer * Mathf.Pow(costPow, level);
    }
    //Critical 관련@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //파워관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadItemButton(PowerButton powerButton) //power업글 불러오기
    {
        string key = powerButton.upgradeName;

        powerButton.currentCost = PlayerPrefs.GetInt(key + "_cost", powerButton.startCurrentCost);
        powerButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveitemButton(PowerButton powerButton) //power업글 저장하기
    {
        string key = powerButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", powerButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", powerButton.level);
    }

    public void increasedPower(float startPower,float costPow,int level) //power 증가
    {
        power += startPower * Mathf.Pow(costPow,level);
    }
    //파워관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


    //자동클릭관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadAutoButton(AutoClickButton autoClickButton) //power업글 불러오기
    {
        string key = autoClickButton.upgradeName;

        autoClickButton.currentCost = PlayerPrefs.GetInt(key + "_cost", autoClickButton.startCurrentCost);
        autoClickButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveAutoButton(AutoClickButton autoClickButton) //power업글 저장하기
    {
        string key = autoClickButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", autoClickButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", autoClickButton.level);
    }
    //자동클릭관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //Stage관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void DecreaseStage()
    {
        stage -= 9;
    }
    //stage관련 끝@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ㄴ
}
