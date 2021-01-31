using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissonA : Missons   //Click미션!
{
    public int A_count  //AttackCount
    {
        get
        {
            DataManager.Instance.LoadMisson();
            return DataManager.Instance.playerMisson.count;
        }
        set
        {
            DataManager.Instance.playerMisson.count = value;    //굳이 이렇게?   추후 수정
            DataManager.Instance.SaveMisson();
        }
    }

    public int A_count_max      //AttackCount
    {
        get
        {
            DataManager.Instance.LoadMisson();
            if(DataManager.Instance.playerMisson.Max_count == 0)
            {
                DataManager.Instance.playerMisson.Max_count = 10;
            }
            return DataManager.Instance.playerMisson.Max_count;
        }
        set
        {
            DataManager.Instance.playerMisson.Max_count = value;    //굳이 이렇게? 추후 수정
            DataManager.Instance.SaveMisson();
        }
    }
    public int isfill     //json 저장
    {
        get 
        {
            DataManager.Instance.LoadMisson();
            return DataManager.Instance.playerMisson.isfill;
        }
        set
        {
            DataManager.Instance.playerMisson.isfill = value;    //굳이 이렇게? 추후 수정
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
        display.text = "Max : " + A_count_max + "\ncount : " + A_count;
    }
}
