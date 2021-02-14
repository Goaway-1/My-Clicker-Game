using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissonB : Missons  //Stage�̼�!
{
    public int stage_max      //AttackCount
    {
        get
        {
            Json.Instance.LoadMisson();
            if (Json.Instance.playerMisson.S_Max_count == 0)
            {
                Json.Instance.playerMisson.S_Max_count = 10;
            }
            return Json.Instance.playerMisson.S_Max_count;
        }
        set
        {
            Json.Instance.playerMisson.S_Max_count = value;
            Json.Instance.SaveMisson();
        }
    }
    public int isfill    //���� ����
    {
        get
        {
            Json.Instance.LoadMisson();
            return Json.Instance.playerMisson.S_isfill;
        }
        set
        {
            Json.Instance.playerMisson.S_isfill = value;
            Json.Instance.SaveMisson();
        }
    }

    private void Start()
    {
        canvasGroup.alpha = 0.4f;
        missonGold = 10;    //����
    }

    private void FixedUpdate()
    {
        Increased();
        UpdateUi();
    }

    public override void Increased()  //�̼� A ����
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
