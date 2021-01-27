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
    public CanvasGroup canvasGroup; //투명도 조절을 위함
    private bool isfill = false;
    
    public int A_count  //AttackCount
    {
        get {
            DataManager.Instance.LoadMisson();
            return DataManager.Instance.playerMisson.count;
        }
        set {
            DataManager.Instance.playerMisson.count = value;    //굳이 이렇게?   추후 수정
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
            DataManager.Instance.playerMisson.Max_count = value;    //굳이 이렇게? 추후 수정
            DataManager.Instance.SaveMisson();
        }
    }

    private int missonGold = 10;    //보상 골드

    private void Start()
    {
        canvasGroup.alpha = 0.4f;
    }
    private void Update()
    {
        increased_A();
        UpdateUi();
    }

    private void increased_A()  //미션 A 증가
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
    //private void increased_B()  //미션 B 증가
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
