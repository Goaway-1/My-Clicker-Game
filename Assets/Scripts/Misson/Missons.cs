using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Missons : MonoBehaviour
{
    public Text display;
    public CanvasGroup canvasGroup; //���� ������ ����

    public int missonGold = 10;    //���� ���

    public abstract void Increased();  //�̼� ���� ����

    public abstract void GetGold();     //���� ����

    public abstract void UpdateUi();    //UI�� ����
}
