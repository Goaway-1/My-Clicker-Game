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
    private int num;

    private void OnEnable()
    {
        for (int i = 0; i < 5; i++)
        {
            ItemAddButton aa = GameObject.Find("Add_item" + i).GetComponent<ItemAddButton>();
            //json�ε� ---> ������ ���� �����ؾߵǴµ�.... --> ���ο� ���� ������ �����?
            DataManager.Instance.LoadCombo();
            aa.i_additionalD = DataManager.Instance.slotData.additionalD;
            aa.i_index = DataManager.Instance.slotData.index;  //����?
            aa.i_type = DataManager.Instance.slotData.type;    //����?
            aa.i_level = DataManager.Instance.slotData.level;
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
        Panel.SetActive(false);
    }
    public void Load()  //�������� �ε�
    {
        DataManager.Instance.LoadSlot();    //ȣ��
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
public class SlotData   //������ ���߳�...?
{
    public bool isEmpty;
    public int index;           //���� �ε��� ��
    public float additionalD;   //�߰� ������
    public GameObject slotObj;  //���� �̹���
    public string type;         //power���� critical����
    public int level;           //�� Slot�� ���� ��
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