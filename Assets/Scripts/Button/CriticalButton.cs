using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalButton : Buttons
{
    void Start()
    {
        upgradeName = "Critical";
    
        startCurrentCost = 1;

        //���� ����
        costPow = 1.02f;
        startState = 1f; //����ũ��Ƽ��

        DataManager.Instance.LoadC_Button(this);
        UpdateUI();
    }

    public override void PurchaseUpgrade() // pow
    {
        //if����->������(�ڵ�����)
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
