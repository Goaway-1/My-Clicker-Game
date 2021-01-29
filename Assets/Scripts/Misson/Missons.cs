using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Missons : MonoBehaviour
{
    public Text display;
    public CanvasGroup canvasGroup; //투명도 조절을 위함

    public int missonGold = 10;    //보상 골드

    public abstract void Increased();  //미션 조건 증가

    public abstract void GetGold();     //보상 수여

    public abstract void UpdateUi();    //UI의 갱신
}
