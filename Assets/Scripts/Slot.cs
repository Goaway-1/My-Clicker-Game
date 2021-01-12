using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    InventoryManger inventory;
    public int num;
    private void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<InventoryManger>();    //이렇게 받을 수도 있군 
        num = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_") + 1));   //번호 추출
    }
    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.slots[num].isEmpty = true;
        }
    }
}
