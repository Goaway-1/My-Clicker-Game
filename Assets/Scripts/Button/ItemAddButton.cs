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
    public int i_level;           //업글할 레벨값

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
                inven.slots[i].level = i_level;
                switch (i)  //데이터의 저장   --> 추가
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

    public void UpdateCost()    //수정
    {
        inven.slots[i_index].additionalD = ++i_additionalD;
        DataManager.Instance.slotData.additionalD++;
        DataManager.Instance.slotData.level++;
        DataManager.Instance.SaveCombo();
    }

    public void UpdateUI()
    {
        display.text = "Additional : " + i_additionalD + "\nindex : " + i_index + "\ntype : " + i_type;
    }
}
