using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalPerButton : Buttons
{
    void Start()
    {
        upgradeName = "CriticalPer";

        startCurrentCost = 1;

        //���� ����
        costPow = 1.08f;
        startState = 1f; //����ũ��Ƽ��

        DataManager.GetInstance().LoadC_Per_Button(this); 
        UpdateUI();
    }

    public override void PurchaseUpgrade() //�ۼ�Ʈ
    {
        //if����->������(�ڵ�����)
        if (DataManager.GetInstance().GetGold() >= currentCost)
        {
            DataManager.GetInstance().SubGold(currentCost);
            level++;
            DataManager.GetInstance().increasedCriticalPer(startState, costPow, level);
            DataManager.GetInstance().SaveC_Per_Button(this);
            UpdateItem();
            UpdateUI();
        }
    }

    public override void UpdateItem()
    {
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public override void UpdateUI()
    {
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nCriticalPer : " + DataManager.GetInstance().GetCriticalPer() + "\nCost" + currentCost;
    }
 
}
