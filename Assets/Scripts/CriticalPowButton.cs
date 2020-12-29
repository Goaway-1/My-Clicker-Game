using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalPowButton : Buttons
{
    void Start()
    {
        upgradeName = "Critical";
    
        startCurrentCost = 1;

        //���� ����
        costPow = 1.08f;
        startState = 1f; //����ũ��Ƽ��

        DataManager.GetInstance().LoadC_Button(this);
        UpdateUI();
    }

    public override void PurchaseUpgrade()
    {
        //if����->������(�ڵ�����)
        if (DataManager.GetInstance().GetGold() >= currentCost)
        {
            DataManager.GetInstance().SubGold(currentCost);
            level++;
            DataManager.GetInstance().increasedPower(startState, costPow, level);
            DataManager.GetInstance().SaveC_Button(this);
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
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nCritical : " + DataManager.GetInstance().GetStrikePow() + "\nCost" + currentCost;
    }
}
