using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : Buttons
{
    private void Start()
    {
        upgradeName = "Power";

        //시작 속성
        startState = 1f; 
        startCurrentCost = 1;

        //업글 제곱
        UpcostPow = 1.39f;
        costPow = 1.01f;
        currentCost = 2;

        DataManager.Instance.LoadItemButton(this);
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    public override void PurchaseUpgrade()
    {
        //if구문->돈빼고(자동저장)
        if (DataManager.Instance.gold >= currentCost)
        {
            DataManager.Instance.gold -= currentCost;
            level++;
            DataManager.Instance.increasedPower(startState, costPow, level);
            DataManager.Instance.SaveitemButton(this);
            UpdateItem();
            UpdateUI();
        }
    }
    public override void UpdateItem()
    {
        currentCost = startCurrentCost * (int)Mathf.Pow(UpcostPow, level);
    }
    public override void UpdateUI()
    {
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nPower : " + DataManager.Instance.power + "\nCost" + currentCost;

        slider.minValue = 0;
        slider.maxValue = currentCost;

        slider.value = DataManager.Instance.gold;

        if (isPurchased)
        {
            canvasGroup.alpha = 1.0f;
        }
        else
        {
            canvasGroup.alpha = 0.6f;
        }

        if (currentCost <= DataManager.Instance.gold)
        {
            colorImage.color = upgradeAbleColor;
        }
        else
        {
            colorImage.color = notUpgradeAbleColor;
        }
    }
}
