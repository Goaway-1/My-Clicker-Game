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
    public int i_level;           //������ ������
    public int i_cost;            //���

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
                inven.slots[i].level = i_level;
                inven.slots[i].cost = i_cost;
                switch (i)  //�������� ����   --> �߰�
                {
                    case 0:
                        Json.Instance.slotSave.index_1 = i_index;
                        break;
                    case 1:
                        Json.Instance.slotSave.index_2 = i_index;
                        break;
                    case 2:
                        Json.Instance.slotSave.index_3 = i_index;
                        break;
                    default:
                        break;
                }
                Json.Instance.SaveSlot();
                break;
            }
        }
    }

    public void UpdateCost()    //����
    {
        if(DataManager.Instance.gold > i_cost)
        {
            switch (int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("m") + 1)))
            {
                case 1: //power
                    i_additionalD += 0.1f;    
                    i_cost += 10;
                    Json.Instance.slotSave.additionalD_1 = i_additionalD;
                    Json.Instance.slotSave.level_1 = ++i_level;
                    Json.Instance.slotSave.cost_1 = i_cost;
                    break;
                case 2: //power
                    i_additionalD += 0.5f;
                    i_cost += 10;
                    Json.Instance.slotSave.additionalD_2 = i_additionalD;
                    Json.Instance.slotSave.level_2 = ++i_level;
                    Json.Instance.slotSave.cost_2 = i_cost;
                    break;
                case 3: //Critical
                    i_additionalD += 0.01f;
                    i_cost += 10;
                    Json.Instance.slotSave.additionalD_3 = i_additionalD;
                    Json.Instance.slotSave.level_3 = ++i_level;
                    Json.Instance.slotSave.cost_3 = i_cost;
                    break;
                case 4: //BossTime
                    i_additionalD += 0.1f;
                    i_cost += 10;
                    Json.Instance.slotSave.additionalD_4 = i_additionalD;
                    Json.Instance.slotSave.level_4 = ++i_level;
                    Json.Instance.slotSave.cost_4 = i_cost;
                    break;
                case 5: //Gold
                    i_additionalD++;
                    i_cost += 10;
                    Json.Instance.slotSave.additionalD_5 = i_additionalD;
                    Json.Instance.slotSave.level_5 = ++i_level;
                    Json.Instance.slotSave.cost_5 = i_cost;
                    break;
                default:
                    break;
            }
            Json.Instance.SaveSlot();
        }
    }

    public void UpdateUI()
    {
        display.text = "Additional : " + i_additionalD + "\ntype : " + i_type + "  Cost : " + i_cost;
    }
}
