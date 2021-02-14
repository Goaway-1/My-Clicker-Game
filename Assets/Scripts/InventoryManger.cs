using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InventoryManger : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 3;
    public GameObject slotPrefab;
    public GameObject Panel;    //Panel�� setactive�� ����ϱ� ����

    //�ε�
    ItemAddButton itemAddButton;
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
            
            switch (i)  //��� �迭�� ������ �ξ� ª��.
            {
                case 1:
                    if(Json.Instance.slotSave.additionalD_1 == 0)    //�ʱⰪ ����
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
        ui.SwitchUpgrade(); //��Ȱ��ȭ
    }
    public void Load()  //�������� �ε�
    {
        Json.Instance.LoadSlot();    //ȣ��
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    num = Json.Instance.slotSave.index_1;
                    itemAddButton = GameObject.Find("Add_item" + num).GetComponent<ItemAddButton>();
                    itemAddButton.Add();
                    break;
                case 1:
                    num = Json.Instance.slotSave.index_2;
                    itemAddButton = GameObject.Find("Add_item" + num).GetComponent<ItemAddButton>();
                    itemAddButton.Add();
                    break;
                case 2:
                    num = Json.Instance.slotSave.index_3;
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
public class SlotData   //���� ���ص� �� ��� example ������
{
    public bool isEmpty;
    public int index;           //���� �ε��� ��
    public float additionalD;   //�߰� ������
    public GameObject slotObj;  //���� �̹���
    public string type;         //power���� critical����
    public int level;           //�� Slot�� ���� ��
    public int cost;           //��ȭ ���
}

[System.Serializable]
public class SlotSave       //�� Ŭ������ ���� ��ܿ� �ھ� �ִ� �뵵 --> �ƴϴ� �긦 ����
{
    public int index_1;
    public int index_2;
    public int index_3;

    public float additionalD_1;   //�߰� ������
    public int level_1;           //�� Slot�� ���� ��
    public int cost_1;           //�� Slot�� ��

    public float additionalD_2;   //�߰� ������
    public int level_2;           //�� Slot�� ���� ��
    public int cost_2;           //�� Slot�� ��

    public float additionalD_3;   //�߰� ������
    public int level_3;           //�� Slot�� ���� ��
    public int cost_3;           //�� Slot�� ��

    public float additionalD_4;   //�߰� ������
    public int level_4;           //�� Slot�� ���� ��
    public int cost_4;           //�� Slot�� ��

    public float additionalD_5;   //�߰� ������
    public int level_5;           //�� Slot�� ���� ��
    public int cost_5;           //�� Slot�� ��
}