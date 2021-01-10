using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    public RectTransform showMenu;
    private bool isshow = false;

    public void OnClick()
    {
        if (isshow) //보여주자
        {
            isshow = true;
            showMenu.anchoredPosition = new Vector3(0, 0, 0);
            //showMenu.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            isshow = false;
            //showMenu.transform.position = new Vector3(0, 950, 0);
        }
    }
}
