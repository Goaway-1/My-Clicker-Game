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
    UIManager ui;
    private int num;

    private void OnEnable()
    {
        ui = FindObjectOfType<UIManager>();
        ui.SwitchOn();
        for (int i = 1; i <= 5; i++)
        {
            ItemAddButton skill = GameObject.Find("Add_item" + i).GetComponent<ItemAddButton>();
            
            DataManager.Instance.LoadSlot();
            switch (i)  //사실 배열로 받으면 훨씬 짧다.
            {
                case 1:
                    skill.i_additionalD = DataManager.Instance.slotSave.additionalD_1;
                    skill.i_level = DataManager.Instance.slotSave.level_1;
                    skill.i_cost = DataManager.Instance.slotSave.cost_1;
                    break;
                case 2:
                    skill.i_additionalD = DataManager.Instance.slotSave.additionalD_2;
                    skill.i_level = DataManager.Instance.slotSave.level_2;
                    skill.i_cost = DataManager.Instance.slotSave.cost_2;
                    break;
                case 3:
                    skill.i_additionalD = DataManager.Instance.slotSave.additionalD_3;
                    skill.i_level = DataManager.Instance.slotSave.level_3;
                    skill.i_cost = DataManager.Instance.slotSave.cost_3;
                    break;
                case 4:
                    skill.i_additionalD = DataManager.Instance.slotSave.additionalD_4;
                    skill.i_level = DataManager.Instance.slotSave.level_4;
                    skill.i_cost = DataManager.Instance.slotSave.cost_4;
                    break;
                case 5:
                    skill.i_additionalD = DataManager.Instance.slotSave.additionalD_5;
                    skill.i_level = DataManager.Instance.slotSave.level_5;
                    skill.i_cost = DataManager.Instance.slotSave.cost_5;
                    break;
                default:
                    break;
            }
        }
    }

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
        //Panel.SetActive(false);
        ui.SwitchUpgrade(); //비활성화
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
public class SlotData   //저장 안해도 돼 상단 example 생성용
{
    public bool isEmpty;
    public int index;           //고유 인덱스 값
    public float additionalD;   //추가 데미지
    public GameObject slotObj;  //넣을 이미지
    public string type;         //power인지 critical인지
    public int level;           //그 Slot의 레벨 값
    public int cost;           //강화 비용
}

[System.Serializable]
public class SlotSave       //이 클래스는 단지 상단에 박아 넣는 용도 --> 아니다 얘를 쓰자
{
    public int index_1;
    public int index_2;
    public int index_3;

    public float additionalD_1;   //추가 데미지
    public int level_1;           //그 Slot의 레벨 값
    public int cost_1;           //그 Slot의 돈

    public float additionalD_2;   //추가 데미지
    public int level_2;           //그 Slot의 레벨 값
    public int cost_2;           //그 Slot의 돈

    public float additionalD_3;   //추가 데미지
    public int level_3;           //그 Slot의 레벨 값
    public int cost_3;           //그 Slot의 돈

    public float additionalD_4;   //추가 데미지
    public int level_4;           //그 Slot의 레벨 값
    public int cost_4;           //그 Slot의 돈

    public float additionalD_5;   //추가 데미지
    public int level_5;           //그 Slot의 레벨 값
    public int cost_5;           //그 Slot의 돈
}