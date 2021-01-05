using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalPerButton : Buttons
{
    void Start()
    {
        upgradeName = "CriticalPer";

        startCurrentCost = 1;

        //업글 제곱
        costPow = 1.08f;
        startState = 1f; //시작크리티컬

        DataManager.Instance.LoadC_Per_Button(this); 
        UpdateUI();
    }

    public override void PurchaseUpgrade() //퍼센트
    {
        //if구문->돈빼고(자동저장)
        if (DataManager.Instance.gold >= currentCost)
        {
            DataManager.Instance.gold -= currentCost;
            level++;
            DataManager.Instance.increasedCriticalPer(startState, costPow, level);
            DataManager.Instance.SaveC_Per_Button(this);
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
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nCriticalPer : " + DataManager.Instance.criticalPer + "\nCost" + currentCost;
    }
 
}
