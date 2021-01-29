using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissonB : Missons  //Stage미션!
{
    public int stage_max      //AttackCount
    {
        get
        {
            DataManager.Instance.LoadMisson();
            if (DataManager.Instance.playerMisson.S_Max_count == 0)
            {
                DataManager.Instance.playerMisson.S_Max_count = 10;
            }
            return DataManager.Instance.playerMisson.S_Max_count;
        }
        set
        {
            DataManager.Instance.playerMisson.S_Max_count = value;    
            DataManager.Instance.SaveMisson();
        }
    }
    public int isfill    //보상 조건
    {
        get
        {
            DataManager.Instance.LoadMisson();
            return DataManager.Instance.playerMisson.S_isfill;
        }
        set
        {
            DataManager.Instance.playerMisson.S_isfill = value;    
            DataManager.Instance.SaveMisson();
        }
    }

    private void Start()
    {
        canvasGroup.alpha = 0.4f;
        missonGold = 10;    //보상
    }

    private void FixedUpdate()
    {
        Increased();
        UpdateUi();
    }

    public override void Increased()  //미션 A 증가
    {
        if (stage_max <= DataManager.Instance.stage)
        {
            canvasGroup.alpha = 1.0f;
            isfill++;
            stage_max += 10;
        }
    }

    public override void GetGold()
    {
        if (isfill != 0)
        {
            canvasGroup.alpha = 0.4f;
            DataManager.Instance.gold += missonGold;
            isfill--;
            if (isfill != 0)
            {
                canvasGroup.alpha = 1.0f;
            }
        }
    }
    public override void UpdateUi()
    {
        display.text = "Max : " + stage_max + "\nStage : " + DataManager.Instance.stage;
    }
}
