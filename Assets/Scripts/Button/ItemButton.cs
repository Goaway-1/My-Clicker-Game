using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : Buttons
{

    private void Start()
    {
        upgradeName = "Power";

        startCurrentCost = 1;

        //업글 제곱
        costPow = 1.08f;
        startState = 1f; //시작크리티컬

        DataManager.GetInstance().LoadItemButton(this);
        UpdateUI();
    }

    public override void PurchaseUpgrade()
    {
        //if구문->돈빼고(자동저장)
        if (DataManager.GetInstance().GetGold() >= currentCost)
        {
            DataManager.GetInstance().SubGold(currentCost);
            level++;
            DataManager.GetInstance().increasedPower(startState, costPow, level);
            DataManager.GetInstance().SaveitemButton(this);
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
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nPower : " + DataManager.GetInstance().GetPower() + "\nCost" + currentCost;
    }
}
