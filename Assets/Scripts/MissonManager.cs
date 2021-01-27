using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissonManager : MonoBehaviour
{
    private static MissonManager instance;

    public static MissonManager Instance
    {
        get {
            if (instance == null)
            {
                instance = FindObjectOfType<MissonManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("MissonManager");
                    instance = container.AddComponent<MissonManager>();
                }
            }
            return instance;
        }
    }

    /////////////////////////////
    public Text display_1;
    public CanvasGroup canvasGroup; //���� ������ ����
    private bool isfill = false;
    
    public int A_count  //AttackCount
    {
        get {
            DataManager.Instance.LoadMisson();
            return DataManager.Instance.playerMisson.count;
        }
        set {
            DataManager.Instance.playerMisson.count = value;    //���� �̷���?   ���� ����
            DataManager.Instance.SaveMisson();
        }
    }

    private int A_count_max      //AttackCount
    {
        get
        {
            DataManager.Instance.LoadMisson();
            return DataManager.Instance.playerMisson.Max_count;
        }
        set
        {
            DataManager.Instance.playerMisson.Max_count = value;    //���� �̷���? ���� ����
            DataManager.Instance.SaveMisson();
        }
    }

    private int missonGold = 10;    //���� ���

    private void Start()
    {
        canvasGroup.alpha = 0.4f;
    }
    private void Update()
    {
        increased_A();
        UpdateUi();
    }

    private void increased_A()  //�̼� A ����
    {
        if (A_count_max <= A_count)
        {
            canvasGroup.alpha = 1.0f;
            isfill = true;
            A_count_max += 10;
        }
    }

    public void getGold()
    {
        if (isfill)
        {
            canvasGroup.alpha = 0.4f;
            isfill = false;
            DataManager.Instance.gold += missonGold;
        }
    }
    //private void increased_B()  //�̼� B ����
    //{
    //    if (A_count_max <= A_count)
    //    {
    //        Debug.Log("count : " + A_count);
    //        A_count_max += 10;
    //    }
    //}

    private void UpdateUi()
    {
        display_1.text = "Max : " + DataManager.Instance.playerMisson.Max_count + "\ncount : " + DataManager.Instance.playerMisson.count;

        //display.text = "Max : " + DataManager.Instance.playerMisson.Max_count + "\ncount : " + DataManager.Instance.playerMisson.count;
    }
}
