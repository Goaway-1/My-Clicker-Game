using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDel : MonoBehaviour
{
    private void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            Destroy(this.gameObject);
        }
    }
}
