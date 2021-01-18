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
    [HideInInspector]
    public float AutoC  //�ڵ� Ŭ�� �ð�
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
    [HideInInspector]
    public int goldPerTake  //ȹ��Ǵ� ����
    {
        get { return PlayerPrefs.GetInt("goldPerTake", 1); }
        set { PlayerPrefs.SetInt("goldPerTake", value); }
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
    public void LoadPowerButton(PowerButton powerButton) //power���� �ҷ�����
    {
        string key = powerButton.upgradeName;

        powerButton.costPow = PlayerPrefs.GetFloat(key + "_costPow", 1f);
        powerButton.currentCost = PlayerPrefs.GetInt(key + "_cost", powerButton.startCurrentCost);
        powerButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SavePowerButton(PowerButton powerButton) //power���� �����ϱ�
    {
        string key = powerButton.upgradeName;

        PlayerPrefs.SetFloat(key + "_costPow", powerButton.costPow);
        PlayerPrefs.SetInt(key + "_cost", powerButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", powerButton.level);
    }
    //�Ŀ����� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


    //�ڵ�Ŭ������ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadAutoButton(AutoClickButton autoClickButton) //power���� �ҷ�����
    {
        string key = autoClickButton.upgradeName;

        autoClickButton.currentCost = PlayerPrefs.GetInt(key + "_cost", autoClickButton.startCurrentCost);
        autoClickButton.level = PlayerPrefs.GetInt(key + "_level", 1);
    }

    public void SaveAutoButton(AutoClickButton autoClickButton) //power���� �����ϱ�
    {
        string key = autoClickButton.upgradeName;

        PlayerPrefs.SetInt(key + "_cost", autoClickButton.currentCost);
        PlayerPrefs.SetInt(key + "_level", autoClickButton.level);
    }
    //�ڵ�Ŭ������ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //Stage���� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void DecreaseStage()
    {
        stage -= 9;
    }
    //stage���� ��@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}
