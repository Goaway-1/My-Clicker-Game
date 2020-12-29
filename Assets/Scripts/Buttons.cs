using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Buttons : MonoBehaviour
{
    public string upgradeName;
    public Text upgradeDisplay;
    public int level;

    //업그레이드 비용
    public int currentCost;
    public int startCurrentCost;

    //업글 제곱
    public float costPow;
    public float startState;

    public abstract void PurchaseUpgrade();
    public abstract void UpdateItem();
    public abstract void UpdateUI();
}
