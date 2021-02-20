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


    public float subHp  //보스를 잡지 못했을 때 HP를 줄이기 위한 용도
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
    public float fixHp  //5씩 증가하는 계산 용도
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
    public float Hp //실질적으로 관련
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
    public float power  //힘
    {
        get
        {
            Json.Instance.Load();
            if (Json.Instance.playerData.power == 0)  //초기값 설정
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
    public float AutoC  //자동 클릭 시간
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
    public int gold  //돈
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
    public int goldPerTake  //획득되는 골드양
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
    public float criticalPer //치명타 확률
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

    //Critical 관련@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadC_Per_Button(CriticalPerButton criticalPerButton) //critical업글 불러오기
    {
        Json.Instance.LoadCost();
        criticalPerButton.currentCost = Json.Instance.playerDataCost.C_P_cost;
        criticalPerButton.level = Json.Instance.playerDataCost.C_P_level;
    }

    public void SaveC_Per_Button(CriticalPerButton criticalPerButton) //critical업글 저장하기
    {
        Json.Instance.playerDataCost.C_P_cost = criticalPerButton.currentCost;
        Json.Instance.playerDataCost.C_P_level = criticalPerButton.level;
        Json.Instance.SaveCost();
    }

    public void increasedCriticalPer() //CriticalPer 증가(수정)
    {
        criticalPer += 0.25f;
    }
    //Critical 관련@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    //파워관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadPowerButton(PowerButton powerButton) //power업글 불러오기
    {
        Json.Instance.LoadCost();
        powerButton.currentCost = Json.Instance.playerDataCost.P_cost;
        powerButton.level = Json.Instance.playerDataCost.P_level;
        powerButton.costPow = Json.Instance.playerDataCost.P_cost_pow;
    }

    public void SavePowerButton(PowerButton powerButton) //power업글 저장하기
    {
        Json.Instance.playerDataCost.P_cost = powerButton.currentCost;
        Json.Instance.playerDataCost.P_level = powerButton.level;
        Json.Instance.playerDataCost.P_cost_pow = (float)System.Math.Round(powerButton.costPow,2);
        Json.Instance.SaveCost();
    }
    //파워관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


    //자동클릭관련 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public void LoadAutoButton(AutoClickButton autoClickButton) //Auto업글 불러오기
    {
        Json.Instance.LoadCost();
        autoClickButton.currentCost = Json.Instance.playerDataCost.A_cost;
        autoClickButton.level = Json.Instance.playerDataCost.A_level;
    }

    public void SaveAutoButton(AutoClickButton autoClickButton) //Auto업글 저장하기
    {
        Json.Instance.playerDataCost.A_cost = autoClickButton.currentCost;
        Json.Instance.playerDataCost.A_level = autoClickButton.level;
        Json.Instance.SaveCost();
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
    public int isfill;  //돈 받을 수 잇어

    //stage 비례
    public int S_Max_count;
    public int S_isfill;
}