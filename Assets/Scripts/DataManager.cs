using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    //json 파일
    public PlayerData playerData;
    public PlayerDataCost playerDataCost;   //비용
    public PlayerMisson playerMisson;

    public float subHp  //보스를 잡지 못했을 때 HP를 줄이기 위한 용도
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
    public float fixHp  //5씩 증가하는 계산 용도
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
    public float Hp //실질적으로 관련
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
    public float power  //힘
    {
        get
        {
            Load();
            if (playerData.power == 0)  //초기값 설정
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
    public float AutoC  //자동 클릭 시간
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
            float b = (float)System.Math.Round(value, 2);   //소수점 2자리로 고정
            Save();
        }
    }
    [HideInInspector]
    public int gold  //돈
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
    public int goldPerTake  //획득되는 골드양
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
    public float criticalPer //치명타 확률
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
    public float criticalPow //치명타배수
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
        if (!File.Exists("Assets/playerData.json"))    //파일의 생성 (추후 로딩으로 뺀다.)
        {
            Save();
            SaveCost();
            SaveMisson();
        }
        else
        {
            Load();
            LoadCost();
            LoadMisson();
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

    //json 파일 @@@@@@@@@@@@@@@@@@@@@@@

    //Critical 관련@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadC_Button(CriticalButton criticalButton) //critical업글 불러오기
    {
        LoadCost();
        criticalButton.currentCost = playerDataCost.C_cost;
        criticalButton.level = playerDataCost.C_level;
    }

    public void SaveC_Button(CriticalButton criticalButton) //critical업글 저장하기
    {
        playerDataCost.C_cost = criticalButton.currentCost;
        playerDataCost.C_level = criticalButton.level;
        SaveCost();
    }

    public void LoadC_Per_Button(CriticalPerButton criticalPerButton) //critical업글 불러오기
    {
        LoadCost();
        criticalPerButton.currentCost = playerDataCost.C_P_cost;
        criticalPerButton.level = playerDataCost.C_P_level;
    }

    public void SaveC_Per_Button(CriticalPerButton criticalPerButton) //critical업글 저장하기
    {
        playerDataCost.C_P_cost = criticalPerButton.currentCost;
        playerDataCost.C_P_level = criticalPerButton.level;
        SaveCost();
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
    public void LoadPowerButton(PowerButton powerButton) //power업글 불러오기
    {
        LoadCost();
        powerButton.currentCost = playerDataCost.P_cost;
        powerButton.level = playerDataCost.P_level;
        powerButton.costPow = playerDataCost.P_cost_pow;
    }

    public void SavePowerButton(PowerButton powerButton) //power업글 저장하기
    {
        playerDataCost.P_cost = powerButton.currentCost;
        playerDataCost.P_level = powerButton.level;
        playerDataCost.P_cost_pow = powerButton.costPow;
        SaveCost();
    }
    //파워관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


    //자동클릭관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadAutoButton(AutoClickButton autoClickButton) //Auto업글 불러오기
    {
        LoadCost();
        autoClickButton.currentCost = playerDataCost.A_cost;
        autoClickButton.level = playerDataCost.A_level;
    }

    public void SaveAutoButton(AutoClickButton autoClickButton) //Auto업글 저장하기
    {
        playerDataCost.A_cost = autoClickButton.currentCost;
        playerDataCost.A_level = autoClickButton.level;
        SaveCost();
    }
    //자동클릭관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //Stage관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void DecreaseStage()
    {
        stage -= 9; //스테이지 감소

        //몬스터 Hp감소
        Hp = subHp;
        fixHp -= 45;
    }
    //stage관련 끝@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}

[System.Serializable]   //직렬화
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
    //크리티컬 pow
    public int C_cost;
    public int C_level;

    //크리티컬 per
    public int C_P_cost;
    public int C_P_level;

    //파워
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
    //클릭하면 돈
    public int Max_count;
    public int count;
}