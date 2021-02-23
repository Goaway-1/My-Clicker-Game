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
    public int currentCost;         //지금 비용
    public int startCurrentCost;    //시작 비용
    public float UpcostPow;         //비용증가 pow

    //업글 제곱
    public float costPow;       //State 강화 pow
    public float startState;    //현재 state

    //사운드
    protected AudioSource sound;

    public CanvasGroup canvasGroup;                 //Alpha값을 조정하기 위한 그룹
    public Slider slider;
    public Color upgradeAbleColor = Color.blue;     //업그레이할때 변함
    public Color notUpgradeAbleColor = Color.red;   //업그레이드 전
    public Image colorImage;
    public bool isPurchased = false;               //아이템 구매여부

    private void Awake()
    {
        sound = GameObject.Find("ItemButtonAudio").GetComponent<AudioSource>();
    }

    public abstract void PurchaseUpgrade();
    public abstract void UpdateItem();
    public abstract void UpdateUI();

}
