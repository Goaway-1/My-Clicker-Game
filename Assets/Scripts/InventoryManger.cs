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

    //로드
    ItemAddButton itemAddButton;
    int num;

    public void Start()
    {
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
    }
    public void Load()  //데이터의 로드
    {
        DataManager.Instance.LoadSlot();    //호출
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    num = DataManager.Instance.slotSave.index_1;
                    itemAddButton = GameObject.Find("Add_item" + num).GetComponent<ItemAddButton>();
                    itemAddButton.Add();
                    break;
                case 1:
                    num = DataManager.Instance.slotSave.index_2;
                    itemAddButton = GameObject.Find("Add_item" + num).GetComponent<ItemAddButton>();
                    itemAddButton.Add();
                    break;
                case 2:
                    num = DataManager.Instance.slotSave.index_3;
                    itemAddButton = GameObject.Find("Add_item" + num).GetComponent<ItemAddButton>();
                    itemAddButton.Add();
                    break;
                default:
                    break;
            }
        }
    }
}


[System.Serializable]
public class SlotData   //저장은 안했네...?
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
    public float additionalD1;
    public string type1;
    public int level1;

    public int index_2;
    public int index_3;
}