using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddButton : MonoBehaviour
{
    public GameObject slotItem; 
    public InventoryManger inven;   //���� �̱����ϱ�
    public float i_additionalD;     //������ �߰� ������ ��
    public int i_index;             //������ ���� index��

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
                break;
            }
        }
    }
}
