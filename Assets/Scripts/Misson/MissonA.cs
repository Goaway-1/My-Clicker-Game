using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissonA : Missons   //Click�̼�!
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
            DataManager.Instance.playerMisson.count = value;    //���� �̷���?   ���� ����
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
            DataManager.Instance.playerMisson.Max_count = value;    //���� �̷���? ���� ����
            DataManager.Instance.SaveMisson();
        }
    }
    public int isfill     //json ����
    {
        get 
        {
            DataManager.Instance.LoadMisson();
            return DataManager.Instance.playerMisson.isfill;
        }
        set
        {
            DataManager.Instance.playerMisson.isfill = value;    //���� �̷���? ���� ����
            DataManager.Instance.SaveMisson();
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
        display.text = "Max : " + A_count_max + "\ncount : " + A_count;
    }
}
