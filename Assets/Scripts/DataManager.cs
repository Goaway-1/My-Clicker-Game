using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour //����� ���� ����
{
    //�̱���@@@@@@@@@@@@@@@@@@@@@@@@@
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
    //�̱���@@@@@@@@@@@@@@@@@@@@@@@@@

    //[HideInInspector]
    public float power  //��
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
    //[HideInInspector]
    public int gold  //��
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
    public float criticalPer //ġ��Ÿ Ȯ��
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
    public float criticalPow //ġ��Ÿ���
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
        criticalPow += startPow * Mathf.Pow(costPow, level);
    }
    public void increasedCriticalPer(float startPer, float costPow, int level) //CriticalPer ����(����)
    {
        criticalPer += startPer * Mathf.Pow(costPow, level);
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
        power += startPower * Mathf.Pow(costPow,level);
    }
    //�Ŀ����� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //Stage���� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void DecreaseStage()
    {
        stage -= 10;
    }
    //stage���� ��@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@��
}
