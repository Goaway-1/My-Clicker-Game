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

    //json ����
    public PlayerData playerData;
    public PlayerDataCost playerDataCost;   //���
    public PlayerMisson playerMisson;    
    public SlotSave slotSave;

    public float subHp  //������ ���� ������ �� HP�� ���̱� ���� �뵵
    {
        get
        {
            Load();
            return playerData.subHp;
        }
        set
        {
            playerData.subHp = value;
            Save();
        }
    }
    public float fixHp  //5�� �����ϴ� ��� �뵵
    {
        get
        {
            Load();
            if (playerData.fixHp == 0)
            {
                playerData.fixHp = 5f;
            }
            return playerData.fixHp;
        }
        set
        {
            playerData.fixHp = value;
            Save();
        }
    }
    public float Hp //���������� ����
    {
        get
        {
            Load();
            return playerData.Hp;
        }
        set
        {
            playerData.Hp = value;
            Save();
        }
    }
    [HideInInspector]
    public float power  //��
    {
        get
        {
            Load();
            if (playerData.power == 0)  //�ʱⰪ ����
            {
                playerData.power = 1;
            }
            return playerData.power;
        }
        set
        {
            playerData.power = value;
            Save();
        }
    }
    [HideInInspector]
    public float AutoC  //�ڵ� Ŭ�� �ð�
    {
        get
        {
            Load();
            if (playerData.AutoC == 0)
            {
                playerData.AutoC = 3f;
            }
            return playerData.AutoC;
        }
        set
        {
            playerData.AutoC = value;
            float b = (float)System.Math.Round(value, 2);   //�Ҽ��� 2�ڸ��� ����
            Save();
        }
    }
    [HideInInspector]
    public int gold  //��
    {
        get
        {
            Load();
            return playerData.gold;
        }
        set
        {
            playerData.gold = value;
            Save();
        }
    }
    [HideInInspector]
    public int goldPerTake  //ȹ��Ǵ� ����
    {
        get
        {
            Load();
            if (playerData.goldPerTake == 0)
            {
                playerData.goldPerTake = 1;
            }
            return playerData.goldPerTake;
        }
        set
        {
            playerData.goldPerTake = value;
            Save();
        }
    }
    [HideInInspector]
    public float criticalPer //ġ��Ÿ Ȯ��
    {
        get
        {
            Load();
            if (playerData.criticalPer == 0)
            {
                playerData.criticalPer = 0.1f;
            }
            return playerData.criticalPer;
        }
        set
        {
            playerData.criticalPer = value;
            Save();
        }
    }
    [HideInInspector]
    public float criticalPow //ġ��Ÿ���
    {
        get
        {
            Load();
            return playerData.criticalPow;
        }
        set
        {
            playerData.criticalPow = value;
            Save();
        }
    }
    [HideInInspector]
    public int stage
    {
        get
        {
            Load();
            if (playerData.stage == 0)
            {
                playerData.stage = 1;
            }
            return playerData.stage;
        }
        set
        {
            playerData.stage = value;
            Save();
        }
    }

    private void Awake()
    {
        if (!File.Exists("Assets/playerData.json"))    //������ ���� (���� �ε����� ����.)
        {
            Save();
            SaveCost();
            SaveMisson();
            SaveSlot();
        }
        else
        {
            Load();
            LoadCost();
            LoadMisson();
            LoadSlot();
        }
    }

    void Save()
    {
        string jsonData = JsonUtility.ToJson(playerData,true);
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }

    void Load()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }

    void SaveCost()
    {
        string jsonData = JsonUtility.ToJson(playerDataCost, true);
        string path = Path.Combine(Application.dataPath, "playerDataCost.json");
        File.WriteAllText(path, jsonData);
    }

    public void LoadCost()
    {
        string path = Path.Combine(Application.dataPath, "playerDataCost.json");
        string jsonData = File.ReadAllText(path);
        playerDataCost = JsonUtility.FromJson<PlayerDataCost>(jsonData);
    }

    public void SaveMisson()
    {
        string jsonData = JsonUtility.ToJson(playerMisson, true);
        string path = Path.Combine(Application.dataPath, "playerMisson.json");
        File.WriteAllText(path, jsonData);
    }

    public void LoadMisson()
    {
        string path = Path.Combine(Application.dataPath, "playerMisson.json");
        string jsonData = File.ReadAllText(path);
        playerMisson = JsonUtility.FromJson<PlayerMisson>(jsonData);
    }

    public void SaveSlot()
    {
        string jsonData = JsonUtility.ToJson(slotSave, true);
        string path = Path.Combine(Application.dataPath, "SlotSave.json");
        File.WriteAllText(path, jsonData);
    }
    public void LoadSlot()
    {
        string path = Path.Combine(Application.dataPath, "SlotSave.json");
        string jsonData = File.ReadAllText(path);
        slotSave = JsonUtility.FromJson<SlotSave>(jsonData);
    }

    //json ���� @@@@@@@@@@@@@@@@@@@@@@@

    //Critical ����@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadC_Button(CriticalButton criticalButton) //critical���� �ҷ�����
    {
        LoadCost();
        criticalButton.currentCost = playerDataCost.C_cost;
        criticalButton.level = playerDataCost.C_level;
    }

    public void SaveC_Button(CriticalButton criticalButton) //critical���� �����ϱ�
    {
        playerDataCost.C_cost = criticalButton.currentCost;
        playerDataCost.C_level = criticalButton.level;
        SaveCost();
    }

    public void LoadC_Per_Button(CriticalPerButton criticalPerButton) //critical���� �ҷ�����
    {
        LoadCost();
        criticalPerButton.currentCost = playerDataCost.C_P_cost;
        criticalPerButton.level = playerDataCost.C_P_level;
    }

    public void SaveC_Per_Button(CriticalPerButton criticalPerButton) //critical���� �����ϱ�
    {
        playerDataCost.C_P_cost = criticalPerButton.currentCost;
        playerDataCost.C_P_level = criticalPerButton.level;
        SaveCost();
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
        LoadCost();
        powerButton.currentCost = playerDataCost.P_cost;
        powerButton.level = playerDataCost.P_level;
        powerButton.costPow = playerDataCost.P_cost_pow;
    }

    public void SavePowerButton(PowerButton powerButton) //power���� �����ϱ�
    {
        playerDataCost.P_cost = powerButton.currentCost;
        playerDataCost.P_level = powerButton.level;
        playerDataCost.P_cost_pow = powerButton.costPow;
        SaveCost();
    }
    //�Ŀ����� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


    //�ڵ�Ŭ������ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadAutoButton(AutoClickButton autoClickButton) //Auto���� �ҷ�����
    {
        LoadCost();
        autoClickButton.currentCost = playerDataCost.A_cost;
        autoClickButton.level = playerDataCost.A_level;
    }

    public void SaveAutoButton(AutoClickButton autoClickButton) //Auto���� �����ϱ�
    {
        playerDataCost.A_cost = autoClickButton.currentCost;
        playerDataCost.A_level = autoClickButton.level;
        SaveCost();
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
    //ũ��Ƽ�� pow
    public int C_cost;
    public int C_level;

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