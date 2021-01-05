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
        costPow = 1.02f;
        startState = 1f; //시작크리티컬

        DataManager.Instance.LoadC_Button(this);
        UpdateUI();
    }

    public override void PurchaseUpgrade() // pow
    {
        //if구문->돈빼고(자동저장)
        if (DataManager.Instance.gold >= currentCost)
        {
            DataManager.Instance.gold -= currentCost;
            level++;
            DataManager.Instance.increasedCritical(startState, costPow, level);
            DataManager.Instance.SaveC_Button(this);
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
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nCriticalPow : " + DataManager.Instance.criticalPow + "\nCost" + currentCost;
    }
}
