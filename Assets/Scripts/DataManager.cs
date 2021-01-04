using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour //끌어다 쓰는 느낌
{
    //싱글톤@@@@@@@@@@@@@@@@@@@@@@@@@
    private static DataManager instance;
    public static DataManager GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<DataManager>();
            if(instance == null)
            {
                GameObject container = new GameObject("DataManager");
                instance = container.AddComponent<DataManager>();
            }
        }
        return instance;
    }
    //싱글톤@@@@@@@@@@@@@@@@@@@@@@@@@

    public PlayerState p; //PlayerState를 불러온다.(싱글톤X)

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
        p.criticalPow += startPow * Mathf.Pow(costPow, level);
        SetCritical(p.criticalPow);
    }
    public void increasedCriticalPer(float startPer, float costPow, int level) //CriticalPer 증가(수정)
    {
        p.criticalPer += startPer * Mathf.Pow(costPow, level);
        SetCriticalPer(p.criticalPer);
    }

    public void SetCritical(float p) //CriticalPow 저장
    {
        PlayerPrefs.SetFloat("criticalPow", p);
    }

    public float GetCritical() //CriticalPow 불러오기
    {
        return p.criticalPow;
    }

    public void SetCriticalPer(float p) //CriticalPer 저장
    {
        PlayerPrefs.SetFloat("criticalPer", p);
    }

    public float GetCriticalPer()  //CriticalPer 불러오기
    {
        return p.criticalPer;
    }
    //Critical 관련@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //파워관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadItemButton(ItemButton itemButton) //power업글 불러오기
    {
        string key = itemButton.upgradeName;

        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveitemButton(ItemButton itemButton) //power업글 저장하기
    {
        string key = itemButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", itemButton.level);
    }

    public void increasedPower(float startPower,float costPow,int level) //power 증가
    {
        p.power += startPower * Mathf.Pow(costPow,level);
        SetPower(p.power);
    }

    public void SetPower(float p) //power저장
    {
        PlayerPrefs.SetFloat("Power",p);
    }

    public float GetPower() //power 불러오기
    {
        return p.power;
    }
    //파워관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //골드 관련@@@@@@@@@@@@@@@@@@@@@@@@ 시작
    public void SetGold(int nGold) //불러와 저장
    {
        PlayerPrefs.SetInt("gold", nGold);
    }

    public void SubGold(int nGold)
    {
        p.gold -= nGold;
        SetGold(p.gold);
    }

    public void AddGold(int nGold) //골드 획득
    {
        p.gold += nGold;
        SetGold(p.gold);
    }
    
    public int GetGold() //m_goldPerClick 리턴
    {
        return p.gold;
    }
    //골드 관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 끝

    //Stage관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void AddStage() //스테이지를 넘어간다.
    {
        p.stage++;
        SaveStage(p.stage);
    }
    public void DecreaseStage()
    {
        p.stage -= 10;
        SaveStage(p.stage);
    }

    public void SaveStage(int num) //PlayerPrefabs에 저장한다.
    {
        PlayerPrefs.SetInt("stage", num);
    }

    public int GetStage() //호출
    {
        return p.stage;
    }

    //stage관련 끝@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ㄴ
}
