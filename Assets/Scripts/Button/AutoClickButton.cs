using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoClickButton : Buttons
{
    [SerializeField]
    private Text mainDisplay;

    private void Start()
    {
        upgradeName = "Auto";

        //시작 속성
        startCurrentCost = 10;

        //업글 제곱
        UpcostPow = 1.3f;
        costPow = 0.05f;    //줄어드는 쿨다임
        currentCost = startCurrentCost;

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

    private void FixedUpdate()
    {
        UpdateUI();
    }

    public override void PurchaseUpgrade()
    {
        //if구문->돈빼고(자동저장)
        if (DataManager.Instance.gold >= currentCost)
        {
            sound.Play();
            isPurchased = true;     //투명도 조절위함
            DataManager.Instance.gold -= currentCost;
            DataManager.Instance.AutoC -= costPow;    //감소
            level++;
            UpdateItem();
            UpdateUI();
            DataManager.Instance.SaveAutoButton(this);
        }
    }
    public override void UpdateItem()
    {
        //currentCost = startCurrentCost * (int)Mathf.Pow(UpcostPow, level);
        currentCost += startCurrentCost + 5 * level;
    }
    public override void UpdateUI()
    {
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nAutoClick : " + DataManager.Instance.AutoC + "\nCost" + currentCost;
        mainDisplay.text = "Atuo\n" + DataManager.Instance.AutoC;

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
