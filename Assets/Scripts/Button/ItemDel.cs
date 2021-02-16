using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDel : MonoBehaviour
{
    public void OnClick()
    {
        int i = int.Parse(gameObject.transform.parent.name.Substring(gameObject.transform.parent.name.IndexOf("_") + 1,1));
        switch (i)  //데이터의 삭제
        {
            case 0:
                Json.Instance.slotSave.index_1 = 0;
                SReset(i);
                break;
            case 1:
                Json.Instance.slotSave.index_2 = 0;
                SReset(i);
                break;
            case 2:
                Json.Instance.slotSave.index_3 = 0;
                SReset(i);
                break;
            default:
                break;
        }
        Json.Instance.SaveSlot();
        Destroy(this.gameObject);
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
