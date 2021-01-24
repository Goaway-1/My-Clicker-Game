using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalButton : Buttons
{
    void Start()
    {
        upgradeName = "Critical";

        //시작 속성
        startState = 1f; //시작크리티컬
        startCurrentCost = 1;

        //업글 제곱
        costPow = 1.02f;
        UpcostPow = 1.39f;
        currentCost = 1;
        
        DataManager.Instance.LoadC_Button(this);
        UpdateUI();
    }
    private void OnEnable()
    {
        if (DataManager.Instance.criticalPow != 0)    //투명도 조절위함
        {
            isPurchased = true;
        }
    }

    private void Update()
    {
        UpdateUI();
    }

    public override void PurchaseUpgrade() // pow
    {
        //if구문->돈빼고(자동저장)
        if (DataManager.Instance.gold >= currentCost)
        {
            isPurchased = true;
            DataManager.Instance.gold -= currentCost;
            DataManager.Instance.increasedCritical(startState, costPow, level);
            level++;
            UpdateItem();
            UpdateUI();
            DataManager.Instance.SaveC_Button(this);
        }
    }

    public override void UpdateItem()
    {
        currentCost = startCurrentCost * (int)Mathf.Pow(UpcostPow, level);
    }

    public override void UpdateUI()
    {
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nCriticalPow : " + DataManager.Instance.criticalPow + "\nCost" + currentCost;
 
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
