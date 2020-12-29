using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalButton : Buttons
{
    void Start()
    {
        upgradeName = "Critical";
    
        startCurrentCost = 1;

        //업글 제곱
        costPow = 1.08f;
        startState = 1f; //시작크리티컬

        DataManager.GetInstance().LoadC_Button(this);
        UpdateUI();
    }

    public override void PurchaseUpgrade() // pow
    {
        //if구문->돈빼고(자동저장)
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
    public void PurchaseUpgradePer() //퍼센트
    {
        //if구문->돈빼고(자동저장)
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
    public void UpdateItemPer() //per
    {
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }
    public override void UpdateUI()
    {
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nCritical : " + DataManager.GetInstance().GetCritical() + "\nCost" + currentCost;
    }
}
