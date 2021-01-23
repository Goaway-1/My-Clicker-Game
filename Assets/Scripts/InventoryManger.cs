using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManger : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 3;
    public GameObject slotPrefab;
    public GameObject Panel;    //Panel�� setactive�� ����ϱ� ����

    public void Start()
    {
        Panel.SetActive(true);  //Panel�� Ȱ��ȭ �Ǿ� ���� ������ itemâ�� �������� �ʾƼ� �״ٰ� ���� �������.
        GameObject slotPanel = GameObject.Find("Slot_Panel");
        for (int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            SlotData slot = new SlotData();
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

    //���2

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

    //���1
}
