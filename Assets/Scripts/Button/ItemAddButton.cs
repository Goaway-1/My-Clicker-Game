using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAddButton : MonoBehaviour
{
    public GameObject slotItem; 
    public InventoryManger inven;   //추후 싱글톤하기
    public float i_additionalD;     //설정할 추가 데미지 값
    public int i_index;             //설정한 고유 index값
    public string i_type;           //설정할 추가 관여 값(power,critical,money....)

    //디스플레이
    public Text display;

    private void Update()
    {
        UpdateUI();
    }
     
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
                inven.slots[i].type = i_type;
                switch (i)  //데이터의 저장
                {
                    case 0:
                        DataManager.Instance.slotSave.index_1 = i_index;
                        break;
                    case 1:
                        DataManager.Instance.slotSave.index_2 = i_index;
                        break;
                    case 2:
                        DataManager.Instance.slotSave.index_3 = i_index;
                        break;
                    default:
                        break;
                }
                DataManager.Instance.SaveSlot();
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

    //public void test()
    //{
    //    for (int i = 0; i < inven.slots.Count; i++)
    //    {
    //        switch (i)
    //        {
    //            case 0:
    //                int a = DataManager.Instance.slotSave.index_1;
    //                InventoryManger bb = GameObject.Find("Add_item" + a).GetComponent<InventoryManger>();
    //                Debug.Log(bb);
    //                Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
    //                inven.slots[i].isEmpty = false;
    //                inven.slots[i].additionalD = bb.slots[i].additionalD;
    //                inven.slots[i].type = bb.slots[i].type;
    //                inven.slots[i].index = bb.slots[i].index;
    //                break;
    //            case 1:
    //                int b = DataManager.Instance.slotSave.index_2;
    //                InventoryManger cc = GameObject.Find("Add_item" + b).GetComponent<InventoryManger>();
    //                Debug.Log(cc);
    //                Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
    //                inven.slots[i].isEmpty = false;
    //                inven.slots[i].additionalD = cc.slots[i].additionalD;
    //                inven.slots[i].type = cc.slots[i].type;
    //                inven.slots[i].index = cc.slots[i].index;
    //                break;
    //            case 2:
    //                int c = DataManager.Instance.slotSave.index_3;
    //                InventoryManger dd = GameObject.Find("Add_item" + c).GetComponent<InventoryManger>();
    //                Debug.Log(dd);
    //                Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
    //                inven.slots[i].isEmpty = false;
    //                inven.slots[i].additionalD = dd.slots[i].additionalD;
    //                inven.slots[i].type = dd.slots[i].type;
    //                inven.slots[i].index = dd.slots[i].index;
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}
}
