using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDel : MonoBehaviour
{
    private void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            switch (Input.inputString)  //데이터의 삭제
            {
                case "1":
                    Json.Instance.slotSave.index_1 = 0;
                    break;
                case "2":
                    Json.Instance.slotSave.index_2 = 0;
                    break;
                case "3":
                    Json.Instance.slotSave.index_3 = 0;
                    break;
                default:
                    break;
            }
            Json.Instance.SaveSlot();
            Destroy(this.gameObject);
        }
    }
}
