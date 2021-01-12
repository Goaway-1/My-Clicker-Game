using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddButton : MonoBehaviour
{
    public GameObject slotItem; 
    public InventoryManger inven;   //추후 싱글톤하기
    public float i_additionalD;     //설정할 추가 데미지 값
    public int i_index;             //설정한 고유 index값

    public void Add()   //추후 오브젝트 풀링으로 변경하자
    {
        for (int i = 0; i < inven.slots.Count; i++)   //빈곳에 넣는다.
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
