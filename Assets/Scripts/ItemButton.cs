using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public string upgradeName;
    public Text upgradeDisplay;
    public int level = 1;

    //���׷��̵� ���
    public int currentCost;
    public int startCurrentCost = 1;

    //���� ����
    public float costPow = 1.08f;
    public float startPower = 1f;

    private void Start()
    {
        DataManager.GetInstance().LoadItemButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        //if����->������(�ڵ�����)
        if (DataManager.GetInstance().GetGold() >= currentCost)
        {
            DataManager.GetInstance().SubGold(currentCost);
            level++;
            DataManager.GetInstance().increasedPower(startPower, costPow, level);
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
