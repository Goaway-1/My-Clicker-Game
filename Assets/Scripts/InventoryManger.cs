using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InventoryManger : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 3;
    public GameObject slotPrefab;
    public GameObject Panel;    //Panel의 setactive를 사용하기 위함

    public void Start()
    {
        Panel.SetActive(true);  //Panel이 활성화 되어 있지 않으면 item창이 생성되지 않아서 켰다가 끄게 만들었다.
        GameObject slotPanel = GameObject.Find("Slot_Panel");
        for (int i = 0; i < maxSlot; i++)
        {
            SlotData slot = new SlotData();
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            slot.isEmpty = true;
            slot.index = 0;
            slot.additionalD = 0;
            slot.slotObj = go;
            slot.type = null;
            slot.level = 0;
            slots.Add(slot);
        }
        Panel.SetActive(false);
        //DataManager.Instance.LoadSlot();
    }
}


[System.Serializable]
public class SlotData
{
    public bool isEmpty;
    public int index;           //고유 인덱스 값
    public float additionalD;   //추가 데미지
    public GameObject slotObj;  //넣을 이미지
    public string type;         //power인지 critical인지
    public int level;           //그 Slot의 레벨 값
}

[System.Serializable]
public class SlotSave
{
    public int index_1;
    public int index_2;
    public int index_3;
}