using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalPerButton : Buttons
{
    void Start()
    {
        upgradeName = "CriticalPer";

        startState = 1f; //����ũ��Ƽ��
        startCurrentCost = 1;

        //���� ����
        costPow = 1.02f;
        UpcostPow = 1.39f;
        currentCost = 1;

        DataManager.Instance.LoadC_Per_Button(this);
        UpdateUI();
    }
    private void Update()
    {
        UpdateUI();
    }

    public override void PurchaseUpgrade() //�ۼ�Ʈ
    {
        //if����->������(�ڵ�����)
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
        currentCost = startCurrentCost * (int)Mathf.Pow(UpcostPow, level);
    }

    public override void UpdateUI()
    {
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nCriticalPer : " + DataManager.Instance.criticalPer + "\nCost" + currentCost;
        slider.value = DataManager.Instance.gold;

        slider.minValue = 0;
        slider.maxValue = currentCost;

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
