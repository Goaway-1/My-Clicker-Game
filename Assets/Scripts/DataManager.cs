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
    public void LoadC_Button(CriticlaButton criticlaButton) //power���� �ҷ�����
    {
        string key = criticlaButton.upgradeName;

        criticlaButton.currentCost = PlayerPrefs.GetInt(key + "_cost", criticlaButton.startCurrentCost);
        criticlaButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveC_Button(CriticlaButton criticlaButton) //power���� �����ϱ�
    {
        string key = criticlaButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", criticlaButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", criticlaButton.level);
    }
    public void increasedCritical (float startPower, float costPow, int level) //power ����
    {
        p.power += startPower * Mathf.Pow(costPow, level);
        SetPower(p.power);
    }

    public void SetCritical(float p) //power����
    {
        PlayerPrefs.SetFloat("Critical", p);
    }

    public float GetCritical() //power �ҷ�����
    {
        return p.power;
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

    //ũ��Ƽ�ð��� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void SetStrikePer()
    {

    }

    public void SetStrikePow()
    {

    }

    public float GetStrikePer() //�ۼ�Ʈ
    {
        return p.criticalPer;
    }

    public float GetStrikePow() //���
    {
        return p.criticalPow;
    }

    //ũ��Ƽ�ð��� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


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
