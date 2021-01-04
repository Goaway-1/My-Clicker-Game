using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{
    public GameObject statePanel;
    private bool isShow = false;

    void Start()
    {
        statePanel.SetActive(false);
    }

    public void OnClick()
    {
        if (!isShow)
        {
            isShow = true;
            statePanel.SetActive(true);
        }
        else
        {
            isShow = false;
            statePanel.SetActive(false);
        }
    }
}
