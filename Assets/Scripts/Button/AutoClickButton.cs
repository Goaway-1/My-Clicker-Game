using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickButton : Buttons
{
    private void Start()
    {
        upgradeName = "Auto";

        //시작 속성
        float startCurrentCost = 10f;

        //업글 제곱
        UpcostPow = 1.3f;
        costPow = 0.05f;    //줄어드는 쿨다임
        float currentCost = startCurrentCost;

        DataManager.Instance.LoadAutoButton(this);
        UpdateUI();
    }

    private void OnEnable()
    {
        if (DataManager.Instance.AutoC != 3)    //투명도 조절위함
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
            isPurchased = true;     //투명도 조절위함
            DataManager.Instance.gold -= currentCost;
            level++;
            DataManager.Instance.AutoC -= costPow;    //감소
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
