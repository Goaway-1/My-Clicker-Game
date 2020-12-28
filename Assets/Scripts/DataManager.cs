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

    public void LoadItemButton(ItemButton itemButton) //power업글 불러오기
    {
        string key = itemButton.upgradeName;

        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.level = PlayerPrefs.GetInt(key + "_level",1);
    }

    public void SaveitemButton(ItemButton itemButton) //power업글 저장하기
    {
        string key = itemButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", itemButton.level);
    }

    //파워관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    
    public void increasedPower() //power 증가
    {
        SetPower(++p.power);
    }

    public void SetPower(int p) //power저장
    {
        PlayerPrefs.SetInt("Power",p);
    }

    public int GetPower() //power 불러오기
    {
        return p.power;
    }
    //파워관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //크리티컬관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void SetStrikePer()
    {

    }
    public void SetStrikePow()
    {

    }

    public float GetStrikePer() //퍼센트
    {
        return p.strikePer;
    }

    public float GetStrikePow() //배수
    {
        return p.strikePow;
    }

    //크리티컬관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


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
