using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickButton : Buttons
{
    private void Start()
    {
        upgradeName = "Auto";

        //���� �Ӽ�
        startCurrentCost = 10;

        //���� ����
        UpcostPow = 1.3f;
        costPow = 0.05f;    //�پ��� �����
        currentCost = startCurrentCost;

        DataManager.Instance.LoadAutoButton(this);
        UpdateUI();
    }

    private void OnEnable()
    {
        if (DataManager.Instance.AutoC != 3)    //���� ��������
        {
            isPurchased = true;
        }
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
            isPurchased = true;     //���� ��������
            DataManager.Instance.gold -= currentCost;
            DataManager.Instance.AutoC -= costPow;    //����
            level++;
            UpdateItem();
            UpdateUI();
            DataManager.Instance.SaveAutoButton(this);
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
