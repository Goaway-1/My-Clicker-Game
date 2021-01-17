using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickButton : Buttons
{
    private void Start()
    {
        upgradeName = "Auto";

        //���� �Ӽ�
        startState = 1f;
        startCurrentCost = 1;

        //���� ����
        UpcostPow = 1.39f;
        costPow = 1.01f;
        currentCost = 2;

        DataManager.Instance.LoadAutoButton(this);
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    public override void PurchaseUpgrade()
    {
        //if����->������(�ڵ�����)
        if (DataManager.Instance.gold >= currentCost)
        {
            DataManager.Instance.gold -= currentCost;
            level++;
            DataManager.Instance.AutoC -= 0.02f;    //����
            DataManager.Instance.SaveAutoButton(this);
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
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nAutoClick : " + DataManager.Instance.AutoC + "\nCost" + currentCost;

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
