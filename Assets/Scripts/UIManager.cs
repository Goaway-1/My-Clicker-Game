using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplay;

    void Update()
    {
        goldDisplay.text = "Gold : " + DataManager.GetInstance().GetGold() + "\nStage : " +DataManager.GetInstance().GetStage();
    }
}
