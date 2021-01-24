using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAddButton : MonoBehaviour
{
    public GameObject slotItem; 
    public InventoryManger inven;   //���� �̱����ϱ�
    public float i_additionalD;     //������ �߰� ������ ��
    public int i_index;             //������ ���� index��
    public string i_type;           //������ �߰� ���� ��(power,critical,money....)

    //���÷���
    public Text display;

    private void Update()
    {
        UpdateUI();
    }
     
    public void Add()   //���� ������Ʈ Ǯ������ ��������
    {
        for (int i = 0; i < inven.slots.Count; i++)   //����� �ִ´�.
        {
            if (inven.slots[i].isEmpty)
            {
                Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                inven.slots[i].isEmpty = false;
                inven.slots[i].additionalD = i_additionalD; 
                inven.slots[i].index = i_index;
                inven.slots[i].type = i_type;
                break;
            }
        }
    }

    public void UpdateCost()
    {
        inven.slots[i_index].additionalD = ++i_additionalD;
    }

    public void UpdateUI()
    {
        display.text = "Additional : " + i_additionalD + "\nindex : " + i_index + "\ntype : " + i_type;
    }
}
