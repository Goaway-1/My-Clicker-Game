using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButton : Buttons
{
    private void Start()
    {
        upgradeName = "Power";

        //시작 속성
        startState = 1f; 
        startCurrentCost = 1;   //필요없는데...

        //업글 제곱
        UpcostPow = 1.39f;
        costPow = 1.0f;    //진화되는 양
        currentCost = 1;

        DataManager.Instance.LoadPowerButton(this);
        UpdateUI();
    }
    private void OnEnable()
    {
        if (DataManager.Instance.power != 1)    //투명도 조절위함
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
        //if구문->돈빼고(자동저장)
        if (DataManager.Instance.gold >= currentCost)
        {
            isPurchased = true;
            DataManager.Instance.gold -= currentCost;
            DataManager.Instance.power += costPow;  //수정
            if (level % 3 == 0)
            {
                UpdateItem();
            }
            UpdateUI();
            if (level % 10 == 0) //10레벨마다 증가하는 폭 증가
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
