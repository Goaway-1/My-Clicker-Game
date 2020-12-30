using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour //����� ���� ����
{
    //�̱���@@@@@@@@@@@@@@@@@@@@@@@@@
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
    //�̱���@@@@@@@@@@@@@@@@@@@@@@@@@

    public PlayerState p; //PlayerState�� �ҷ��´�.(�̱���X)

    //Critical ����@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadC_Button(CriticalButton criticalButton) //critical���� �ҷ�����
    {
        string key = criticalButton.upgradeName;

        criticalButton.currentCost = PlayerPrefs.GetInt(key + "_cost", criticalButton.startCurrentCost);
        criticalButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveC_Button(CriticalButton criticalButton) //critical���� �����ϱ�
    {
        string key = criticalButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", criticalButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", criticalButton.level);
    }

    public void LoadC_Per_Button(CriticalPerButton criticalPerButton) //critical���� �ҷ�����
    {
        string key = criticalPerButton.upgradeName;

        criticalPerButton.currentCost = PlayerPrefs.GetInt(key + "_cost", criticalPerButton.startCurrentCost);
        criticalPerButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveC_Per_Button(CriticalPerButton criticalPerButton) //critical���� �����ϱ�
    {
        string key = criticalPerButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", criticalPerButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", criticalPerButton.level);
    }

    public void increasedCritical (float startPow , float costPow, int level) //CriticalPow ����(����)
    { 
        p.criticalPow += startPow * Mathf.Pow(costPow, level);
        SetCritical(p.criticalPow);
    }
    public void increasedCriticalPer(float startPer, float costPow, int level) //CriticalPer ����(����)
    {
        p.criticalPer += startPer * Mathf.Pow(costPow, level);
        SetCriticalPer(p.criticalPer);
    }

    public void SetCritical(float p) //CriticalPow ����
    {
        PlayerPrefs.SetFloat("criticalPow", p);
    }

    public float GetCritical() //CriticalPow �ҷ�����
    {
        return p.criticalPow;
    }

    public void SetCriticalPer(float p) //CriticalPer ����
    {
        PlayerPrefs.SetFloat("criticalPer", p);
    }

    public float GetCriticalPer()  //CriticalPer �ҷ�����
    {
        return p.criticalPer;
    }
    //Critical ����@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //�Ŀ����� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadItemButton(ItemButton itemButton) //power���� �ҷ�����
    {
        string key = itemButton.upgradeName;

        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveitemButton(ItemButton itemButton) //power���� �����ϱ�
    {
        string key = itemButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", itemButton.level);
    }

    public void increasedPower(float startPower,float costPow,int level) //power ����
    {
        p.power += startPower * Mathf.Pow(costPow,level);
        SetPower(p.power);
    }

    public void SetPower(float p) //power����
    {
        PlayerPrefs.SetFloat("Power",p);
    }

    public float GetPower() //power �ҷ�����
    {
        return p.power;
    }
    //�Ŀ����� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //��� ����@@@@@@@@@@@@@@@@@@@@@@@@ ����
    public void SetGold(int nGold) //�ҷ��� ����
    {
        PlayerPrefs.SetInt("gold", nGold);
    }

    public void SubGold(int nGold)
    {
        p.gold -= nGold;
        SetGold(p.gold);
    }

    public void AddGold(int nGold) //��� ȹ��
    {
        p.gold += nGold;
        SetGold(p.gold);
    }
    
    public int GetGold() //m_goldPerClick ����
    {
        return p.gold;
    }
    //��� ���� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ ��

    //Stage���� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void AddStage() //���������� �Ѿ��.
    {
        p.stage++;
        SaveStage(p.stage);
    }

    public void SaveStage(int num) //PlayerPrefabs�� �����Ѵ�.
    {
        PlayerPrefs.SetInt("stage", num);
    }

    public int GetStage() //ȣ��
    {
        return p.stage;
    }

    //stage���� ��@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@��
}
