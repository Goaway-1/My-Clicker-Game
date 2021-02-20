using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissonA : Missons   //Click�̼�!
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
            Json.Instance.playerMisson.count = value;    //���� �̷���?   ���� ����
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
            Json.Instance.playerMisson.Max_count = value;    //���� �̷���? ���� ����
            Json.Instance.SaveMisson();
        }
    }
    public int isfill     //json ����
    {
        get 
        {
            Json.Instance.LoadMisson();
            return Json.Instance.playerMisson.isfill;
        }
        set
        {
            Json.Instance.playerMisson.isfill = value;    //���� �̷���? ���� ����
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
        UpdateUi();     //switch �Ҷ� �ұ� �����.(����ȭ ����)
    }

    public override void Increased()  //�̼� A ����
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
