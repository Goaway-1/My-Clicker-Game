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
    public Text display;

    private int count;
    private int maxcount;

    public int A_count  //AttackCount
    {
        get {
            DataManager.Instance.LoadMisson();
            count = DataManager.Instance.playerMisson.count;
            return DataManager.Instance.playerMisson.count;
        }
        set {
            DataManager.Instance.playerMisson.count = value;    //굳이 이렇게?   추후 수정
            count = value; 
            DataManager.Instance.SaveMisson();
        }
    }

    private int A_count_max      //AttackCount
    {
        get
        {
            DataManager.Instance.LoadMisson();
            maxcount = DataManager.Instance.playerMisson.Max_count;
            return DataManager.Instance.playerMisson.Max_count;
        }
        set
        {
            DataManager.Instance.playerMisson.Max_count = value;    //굳이 이렇게? 추후 수정
            maxcount = value;
            DataManager.Instance.SaveMisson();
        }
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
            Debug.Log("A_count : " + A_count);
            A_count_max += 10;
        }
    }
   
    private void UpdateUi()
    {
        display.text = "Max : " + maxcount + "\ncount : " + count;
    }
}
