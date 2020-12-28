using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public string upgradeName;
    public Text upgradeDisplay;
    public int level = 1;

    //업그레이드 비용
    public int currentCost;
    public int startCurrentCost = 1;

    //업글 제곱
    public float costPow = 1.14f;

    private void Start()
    {
        DataManager.GetInstance().LoadItemButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        //if구문->돈빼고(자동저장)
        if (DataManager.GetInstance().GetGold() >= currentCost)
        {
            DataManager.GetInstance().SubGold(currentCost);
            level++;
            DataManager.GetInstance().increasedPower();
            DataManager.GetInstance().SaveitemButton(this);
            UpdateItem();
            UpdateUI();
        }
    }
    public void UpdateItem()
    {
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }
    public void UpdateUI()
    {
        upgradeDisplay.text = upgradeName + "\nLevel : " + level + "\nPower : " + DataManager.GetInstance().GetPower() + "\nCost" + currentCost;
    }
}
