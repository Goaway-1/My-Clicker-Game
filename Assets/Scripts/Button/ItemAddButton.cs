using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAddButton : MonoBehaviour
{
    public GameObject slotItem; 
    public float i_additionalD;     //������ �߰� ������ ��
    public int i_index;             //������ ���� index��
    public string i_type;           //������ �߰� ���� ��(power,critical,money....)
    public int i_level;           //������ ������
    public int i_cost;            //���

    //���÷���
    public Text display;

    //�Ҹ�
    public AudioSource sound;

    private void FixedUpdate()
    {
        UpdateUI();
    }
     
    public void Add()   //���� ������Ʈ Ǯ������ ��������
    {
        for (int i = 0; i < InventoryManger.Instance.slots.Count; i++)   //����� �ִ´�.
        {
            if (InventoryManger.Instance.slots[i].isEmpty)
            {
                int x = 0 , y = 0;
                switch (i)
                {
                    case 0:
                        x = 1;
                        y = 2;
                        break;
                    case 1:
                        x = 0;
                        y = 2;
                        break;
                    default:
                        x = 0;
                        y = 1;
                        break;
                }
                if (InventoryManger.Instance.slots[x].index == i_index || InventoryManger.Instance.slots[y].index == i_index)
                {
                    break;
                }
                Instantiate(slotItem, InventoryManger.Instance.slots[i].slotObj.transform, false);
                InventoryManger.Instance.slots[i].isEmpty = false;
                InventoryManger.Instance.slots[i].additionalD = (float)System.Math.Round(i_additionalD,2);
                InventoryManger.Instance.slots[i].index = i_index;
                InventoryManger.Instance.slots[i].type = i_type;
                InventoryManger.Instance.slots[i].level = i_level;
                InventoryManger.Instance.slots[i].cost = i_cost;
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
            sound.Play();
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
