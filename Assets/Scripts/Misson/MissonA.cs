using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissonA : Missons   //Click미션!
{
    public int A_count  //AttackCount
    {
        get
        {
            Json.Instance.LoadMisson();
            return Json.Instance.playerMisson.count;
        }
        set
        {
            Json.Instance.playerMisson.count = value;    //굳이 이렇게?   추후 수정
            Json.Instance.SaveMisson();
        }
    }

    public int A_count_max      //AttackCount
    {
        get
        {
            Json.Instance.LoadMisson();
            if(Json.Instance.playerMisson.Max_count == 0)
            {
                Json.Instance.playerMisson.Max_count = 10;
            }
            return Json.Instance.playerMisson.Max_count;
        }
        set
        {
            Json.Instance.playerMisson.Max_count = value;    //굳이 이렇게? 추후 수정
            Json.Instance.SaveMisson();
        }
    }
    public int isfill     //json 저장
    {
        get 
        {
            Json.Instance.LoadMisson();
            return Json.Instance.playerMisson.isfill;
        }
        set
        {
            Json.Instance.playerMisson.isfill = value;    //굳이 이렇게? 추후 수정
            Json.Instance.SaveMisson();
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
        UpdateUi();     //switch 할때 할까 고민중.(최적화 관련)
    }

    public override void Increased()  //미션 A 증가
    {
        if (A_count_max <= A_count)
        {
            canvasGroup.alpha = 1.0f;
            isfill++;
            A_count_max += 10;
        }
    }

    public override void GetGold()
    {
        if (isfill != 0)
        {
            canvasGroup.alpha = 0.4f;
            DataManager.Instance.gold += missonGold;
            isfill--;
            if(isfill != 0)
            {
                canvasGroup.alpha = 1.0f;
            }
        }
    }
    public override void UpdateUi()
    {
        display.text = "Objective : " + A_count_max + "\nCurrentCount : " + A_count + "\tReward : " + isfill;
    }
}
