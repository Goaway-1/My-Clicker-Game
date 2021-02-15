using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InventoryManger : MonoBehaviour
{
    private static InventoryManger instance;
    
    public static InventoryManger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManger>();
                if (instance == null)
                {
                    GameObject container = new GameObject("InventoryManger");
                    instance = container.AddComponent<InventoryManger>();
                }
            }
            return instance;
        }
    }


    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 3;
    public GameObject slotPrefab;
    public GameObject Panel;    //Panel의 setactive를 사용하기 위함

    //로드
    ItemAddButton[] itemAddButton = new ItemAddButton[3];
    UIManager ui;
    private int num;

    private void OnEnable()
    {
        ui = FindObjectOfType<UIManager>();
        Json.Instance.LoadSlot();
        ui.SwitchOn();
        for (int i = 1; i <= 5; i++)
        {
            ItemAddButton skill = GameObject.Find("Add_item" + i).GetComponent<ItemAddButton>();
            
            switch (i)  //사실 배열로 받으면 훨씬 짧다.
            {
                case 1:
                    if(Json.Instance.slotSave.additionalD_1 == 0)    //초기값 설정
                    {
                        Json.Instance.slotSave.additionalD_1 = 0.1f;
                    }
                    skill.i_additionalD = Json.Instance.slotSave.additionalD_1;
                    skill.i_level = Json.Instance.slotSave.level_1;
                    skill.i_cost = Json.Instance.slotSave.cost_1;
                    break;
                case 2:
                    if (Json.Instance.slotSave.additionalD_2 == 0)
                    {
                        Json.Instance.slotSave.additionalD_2 = 0.5f;
                    }
                    skill.i_additionalD = Json.Instance.slotSave.additionalD_2;
                    skill.i_level = Json.Instance.slotSave.level_2;
                    skill.i_cost = Json.Instance.slotSave.cost_2;
                    break;
                case 3:
                    if (Json.Instance.slotSave.additionalD_3 == 0)
                    {
                        Json.Instance.slotSave.additionalD_3 = 0.05f;
                    }
                    skill.i_additionalD = Json.Instance.slotSave.additionalD_3;
                    skill.i_level = Json.Instance.slotSave.level_3;
                    skill.i_cost = Json.Instance.slotSave.cost_3;
                    break;
                case 4:
                    if (Json.Instance.slotSave.additionalD_4 == 0)
                    {
                        Json.Instance.slotSave.additionalD_4 = 0.1f;
                    }
                    skill.i_additionalD = Json.Instance.slotSave.additionalD_4;
                    skill.i_level = Json.Instance.slotSave.level_4;
                    skill.i_cost = Json.Instance.slotSave.cost_4;
                    break;
                case 5:
                    if (Json.Instance.slotSave.additionalD_5 == 0)
                    {
                        Json.Instance.slotSave.additionalD_5 = 1f;
                    }
                    skill.i_additionalD = Json.Instance.slotSave.additionalD_5;
                    skill.i_level = Json.Instance.slotSave.level_5;
                    skill.i_cost = Json.Instance.slotSave.cost_5;
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
            //추후 3가지의 스킬을 불러와 로드할때 쓴다.
            itemAddButton[i] = GameObject.Find("Add_item" + (i + 1)).GetComponent<ItemAddButton>();

            //초기값 생성시 사용
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
        Load();
        Panel.SetActive(false);
        ui.SwitchUpgrade(); //비활성화
    }
    public void Load()  //데이터의 로드
    {
        Json.Instance.LoadSlot();    //호출
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    num = Json.Instance.slotSave.index_1;
                    if (num == 0)
                    {
                        break;
                    }
                    itemAddButton[i].Add();
                    break;
                case 1:
                    num = Json.Instance.slotSave.index_2;
                    if(num == 0)
                    {
                        break;
                    }
                    itemAddButton[i].Add();
                    break;
                case 2:
                    num = Json.Instance.slotSave.index_3;
                    if (num == 0)
                    {
                        break;
                    }
                    itemAddButton[i].Add();
                    break;
                default:
                    break;
            }
        }
    }
}


[System.Serializable]
public class SlotData   //저장 x 상단 example 생성용
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
public class SlotSave       //생성된 것
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