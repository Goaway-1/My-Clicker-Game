using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButton : Buttons
{
    private void Start()
    {
        upgradeName = "Power";

        //���� �Ӽ�
        startState = 1f; 
        startCurrentCost = 1;   //�ʿ���µ�...

        //���� ����
        UpcostPow = 1.39f;
        costPow = 1.0f;    //��ȭ�Ǵ� ��
        currentCost = 1;

        DataManager.Instance.LoadPowerButton(this);
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
            DataManager.Instance.power += costPow;  //����
            DataManager.Instance.SavePowerButton(this);
            level++;
            if (level % 3 == 0)
            {
                UpdateItem();
            }
            UpdateUI();
            if (level % 10 == 0) //10�������� �����ϴ� �� ����
            {
                costPow += 0.2f;
            }
        }
    }
    public override void UpdateItem()
    {
        currentCost += 1;
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
