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
    public int currentCost;         //���� ���
    public int startCurrentCost;    //���� ���
    public float UpcostPow;         //������� pow

    //���� ����
    public float costPow;       //State ��ȭ pow
    public float startState;    //���� state

    //����
    protected AudioSource sound;

    public CanvasGroup canvasGroup;                 //Alpha���� �����ϱ� ���� �׷�
    public Slider slider;
    public Color upgradeAbleColor = Color.blue;     //���׷����Ҷ� ����
    public Color notUpgradeAbleColor = Color.red;   //���׷��̵� ��
    public Image colorImage;
    public bool isPurchased = false;               //������ ���ſ���

    private void Awake()
    {
        sound = GameObject.Find("ItemButtonAudio").GetComponent<AudioSource>();
    }

    public abstract void PurchaseUpgrade();
    public abstract void UpdateItem();
    public abstract void UpdateUI();

}
