using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButton : Buttons
{
    [SerializeField]
    private Text mainDisplay;

    private void Start()
    {
        upgradeName = "Power";

        //���� �Ӽ�
        startState = 1f; 

        //���� ����
        UpcostPow = 1.39f;
        costPow = 1.0f;    //��ȭ�Ǵ� ��
        currentCost = 1;

        DataManager.Instance.LoadPowerButton(this);
        UpdateUI();
    }
    private void OnEnable()
    {
        if (DataManager.Instance.power != 1)    //���� ��������
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
        //if���� -> ������(�ڵ�����)
        if (DataManager.Instance.gold >= currentCost)
        {
            isPurchased = true;
            DataManager.Instance.gold -= currentCost;
            DataManager.Instance.power += costPow;  //����
            if (level % 3 == 0)
            {
                UpdateItem();
            }
            UpdateUI();
            if (level % 10 == 0) //10�������� �����ϴ� �� ����
            {
                costPow += 0.2f;
            }
            level++;
            DataManager.Instance.SavePowerButton(this);
        }
    }

    public override void UpdateItem()
    {
        currentCost += 1;
    }
    public override void UpdateUI()
    {
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nPower : " + DataManager.Instance.power + "\nCost" + currentCost;
        mainDisplay.text = "Power\n" + DataManager.Instance.power;

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
