using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplay;

    //timer
    public Slider timeSlider;
    public GameObject Slider;
    public float currentTime;  //시작시간
    private float MaxTime;      //최대시간
    public Text currentDisplay;    //화면에 보여질 시간

    private void Start()
    {
        Slider.SetActive(false);
        currentTime = 10f;
        MaxTime = 10f;
        timeSlider.value = currentTime / MaxTime;  
    }

    void Update()
    {
        GoldStageDisplay();
    }

    public void GoldStageDisplay() //골드와 stage를 화면 상에 출력한다.
    {
        goldDisplay.text = "Gold : " + DataManager.GetInstance().GetGold() + "\tStage : " + DataManager.GetInstance().GetStage();
        currentDisplay.text = (int)currentTime + "초";
    }
    
    public void DecreaseTime()  //시간 감소
    {
        Slider.SetActive(true);
        StartCoroutine(wait());
    }
    public IEnumerator wait()   //시간 감소를 위한 대기시간을 위해 만듦
    {
        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            timeSlider.value = currentTime / MaxTime; //출력
            yield return new WaitForFixedUpdate();  //프레임 대기
            Debug.Log(currentTime);
        }
        if(currentTime <= 0)
        {
            Slider.SetActive(false);
        }
    }
}
