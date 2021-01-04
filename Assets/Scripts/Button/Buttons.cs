using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Buttons : MonoBehaviour
{
    public string upgradeName;
    public Text upgradeDisplay;
    public int level;

    //���׷��̵� ���
    public int currentCost;
    public int startCurrentCost;

    //���� ����
    public float costPow;
    public float startState;

    public abstract void PurchaseUpgrade();
    public abstract void UpdateItem();
    public abstract void UpdateUI();
}
