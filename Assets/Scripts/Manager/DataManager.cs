using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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


    public float subHp  //������ ���� ������ �� HP�� ���̱� ���� �뵵
    {
        get
        {
            Json.Instance.Load();
            return Json.Instance.playerData.subHp;
        }
        set
        {
            Json.Instance.playerData.subHp = (float)System.Math.Round(value, 2);
            Json.Instance.Save();
        }
    }
    public float fixHp  //5�� �����ϴ� ��� �뵵
    {
        get
        {
            Json.Instance.Load();
            if (Json.Instance.playerData.fixHp == 0)
            {
                Json.Instance.playerData.fixHp = 5f;
            }
            return Json.Instance.playerData.fixHp;
        }
        set
        {
            Json.Instance.playerData.fixHp = (float)System.Math.Round(value, 2);
            Json.Instance.Save();
        }
    }
    public float Hp //���������� ����
    {
        get
        {
            Json.Instance.Load();
            return Json.Instance.playerData.Hp;
        }
        set
        {
            Json.Instance.playerData.Hp = (float)System.Math.Round(value, 2);
            Json.Instance.Save();
        }
    }
    [HideInInspector]
    public float power  //��
    {
        get
        {
            Json.Instance.Load();
            if (Json.Instance.playerData.power == 0)  //�ʱⰪ ����
            {
                Json.Instance.playerData.power = 1;
            }
            return Json.Instance.playerData.power;
        }
        set
        {
            Json.Instance.playerData.power = (float)System.Math.Round(value, 2);
            Json.Instance.Save();
        }
    }
    [HideInInspector]
    public float AutoC  //�ڵ� Ŭ�� �ð�
    {
        get
        {
            Json.Instance.Load();
            if (Json.Instance.playerData.AutoC == 0)
            {
                Json.Instance.playerData.AutoC = 3f;
            }
            return Json.Instance.playerData.AutoC;
        }
        set
        {
            Json.Instance.playerData.AutoC = (float)System.Math.Round(value, 2);
            Json.Instance.Save();
        }
    }
    [HideInInspector]
    public int gold  //��
    {
        get
        {
            Json.Instance.Load();
            return Json.Instance.playerData.gold;
        }
        set
        {
            Json.Instance.playerData.gold = value;
            Json.Instance.Save();
        }
    }
    [HideInInspector]
    public int goldPerTake  //ȹ��Ǵ� ����
    {
        get
        {
            Json.Instance.Load();
            if (Json.Instance.playerData.goldPerTake == 0)
            {
                Json.Instance.playerData.goldPerTake = 1;
            }
            return Json.Instance.playerData.goldPerTake;
        }
        set
        {
            Json.Instance.playerData.goldPerTake = value;
            Json.Instance.Save();
        }
    }
    [HideInInspector]
    public float criticalPer //ġ��Ÿ Ȯ��
    {
        get
        {
            Json.Instance.Load();
            if (Json.Instance.playerData.criticalPer == 0)
            {
                Json.Instance.playerData.criticalPer = 10f;
            }
            return Json.Instance.playerData.criticalPer;
        }
        set
        {
            Json.Instance.playerData.criticalPer = (float)System.Math.Round(value, 2);
            Json.Instance.Save();
        }
    }

    [HideInInspector]
    public int stage
    {
        get
        {
            Json.Instance.Load();
            if (Json.Instance.playerData.stage == 0)
            {
                Json.Instance.playerData.stage = 1;
            }
            return Json.Instance.playerData.stage;
        }
        set
        {
            Json.Instance.playerData.stage = value;
            Json.Instance.Save();
        }
    }

    private void Awake()
    {
        Json.Instance.Load();
        Json.Instance.LoadCost();
        Json.Instance.LoadMisson();
        Json.Instance.LoadSlot();
    }

    //Critical ����@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadC_Per_Button(CriticalPerButton criticalPerButton) //critical���� �ҷ�����
    {
        Json.Instance.LoadCost();
        criticalPerButton.currentCost = Json.Instance.playerDataCost.C_P_cost;
        criticalPerButton.level = Json.Instance.playerDataCost.C_P_level;
    }

    public void SaveC_Per_Button(CriticalPerButton criticalPerButton) //critical���� �����ϱ�
    {
        Json.Instance.playerDataCost.C_P_cost = criticalPerButton.currentCost;
        Json.Instance.playerDataCost.C_P_level = criticalPerButton.level;
        Json.Instance.SaveCost();
    }

    public void increasedCriticalPer() //CriticalPer ����(����)
    {
        criticalPer += 0.25f;
    }
    //Critical ����@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //�Ŀ����� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadPowerButton(PowerButton powerButton) //power���� �ҷ�����
    {
        Json.Instance.LoadCost();
        powerButton.currentCost = Json.Instance.playerDataCost.P_cost;
        powerButton.level = Json.Instance.playerDataCost.P_level;
        powerButton.costPow = Json.Instance.playerDataCost.P_cost_pow;
    }

    public void SavePowerButton(PowerButton powerButton) //power���� �����ϱ�
    {
        Json.Instance.playerDataCost.P_cost = powerButton.currentCost;
        Json.Instance.playerDataCost.P_level = powerButton.level;
        Json.Instance.playerDataCost.P_cost_pow = (float)System.Math.Round(powerButton.costPow,2);
        Json.Instance.SaveCost();
    }
    //�Ŀ����� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


    //�ڵ�Ŭ������ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadAutoButton(AutoClickButton autoClickButton) //Auto���� �ҷ�����
    {
        Json.Instance.LoadCost();
        autoClickButton.currentCost = Json.Instance.playerDataCost.A_cost;
        autoClickButton.level = Json.Instance.playerDataCost.A_level;
    }

    public void SaveAutoButton(AutoClickButton autoClickButton) //Auto���� �����ϱ�
    {
        Json.Instance.playerDataCost.A_cost = autoClickButton.currentCost;
        Json.Instance.playerDataCost.A_level = autoClickButton.level;
        Json.Instance.SaveCost();
    }
    //�ڵ�Ŭ������ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //Stage���� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void DecreaseStage()
    {
        stage -= 9; //�������� ����

        //���� Hp����
        Hp = subHp;
        fixHp -= 45;
    }
    //stage���� ��@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}

[System.Serializable]   //����ȭ
public class PlayerData
{
    public float subHp;
    public float fixHp;
    public float Hp;
    public float power;
    public float AutoC;
    public int gold;
    public int goldPerTake;
    public float criticalPer;
    public float criticalPow;
    public int stage;
}

[System.Serializable]
public class PlayerDataCost
{
    //ũ��Ƽ�� per
    public int C_P_cost;
    public int C_P_level;

    //�Ŀ�
    public int P_cost;
    public float P_cost_pow;
    public int P_level;

    //Auto click
    public int A_cost;
    public int A_level;
}

[System.Serializable]
public class PlayerMisson
{
    //Ŭ���ϸ� ��
    public int Max_count;
    public int count;
    public int isfill;  //�� ���� �� �վ�

    //stage ���
    public int S_Max_count;
    public int S_isfill;
}