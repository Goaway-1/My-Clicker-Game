using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalPerButton : Buttons
{
    void Start()
    {
        upgradeName = "CriticalPer";

        startCurrentCost = 20;

        //���� ����
        costPow = 1.02f;
        UpcostPow = 1.39f;
        currentCost = 20;

        DataManager.Instance.LoadC_Per_Button(this);
        UpdateUI();
    }

    private void OnEnable() //������Ʈ Ȱ��ȭ��
    {
        if (DataManager.Instance.criticalPer != 10f)    //���� ��������
        {
            isPurchased = true;
        }
    }

    private void Update()
    {
        UpdateUI();
    }

    public override void PurchaseUpgrade() //�ۼ�Ʈ
    {
        if (DataManager.Instance.gold >= currentCost && DataManager.Instance.criticalPer < 30)
        {
            isPurchased = true;
            DataManager.Instance.gold -= currentCost;
            DataManager.Instance.increasedCriticalPer();
            level++;
            UpdateItem();
            UpdateUI();
            DataManager.Instance.SaveC_Per_Button(this);
        }
    }

    public override void UpdateItem()
    {
        //currentCost = startCurrentCost * (int)Mathf.Pow(UpcostPow, level);
        currentCost += startCurrentCost + 2 * level;
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
            canvasGroup.alpha = 0.4f;
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
