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
    public ItemAddButton itemAddButton;
    public void Start()
    {
        Panel.SetActive(true);  //Panel�� Ȱ��ȭ �Ǿ� ���� ������ itemâ�� �������� �ʾƼ� �״ٰ� ���� �������.
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
        ////�ε�
        DataManager.Instance.LoadSlot();
        //itemAddButton.test();
    }
}


[System.Serializable]
public class SlotData
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
    public int index_2;
    public int index_3;
}