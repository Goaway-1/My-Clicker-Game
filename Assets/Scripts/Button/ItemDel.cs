using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDel : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            switch (Input.inputString)  //데이터의 삭제
            {
                case "1":
                    Json.Instance.slotSave.index_1 = 0;
                    SReset(0);
                    break;
                case "2":
                    Json.Instance.slotSave.index_2 = 0;
                    SReset(1);
                    break;
                case "3":
                    Json.Instance.slotSave.index_3 = 0;
                    SReset(2);
                    break;
                default:
                    break;
            }
            Json.Instance.SaveSlot();
            Destroy(this.gameObject);
        }
    }
    private void SReset(int i)
    {
        InventoryManger.Instance.slots[i].isEmpty = false;
        InventoryManger.Instance.slots[i].additionalD = 0;
        InventoryManger.Instance.slots[i].index = 0;
        InventoryManger.Instance.slots[i].type = null;
        InventoryManger.Instance.slots[i].level = 0;
        InventoryManger.Instance.slots[i].cost = 0;
    }
}
