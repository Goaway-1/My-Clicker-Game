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
    public float currentTime = 10f;  //시작시간
    const float MaxTime = 10f;      //최대시간(변경 X) -->static으로 선언된다.
    public Text currentDisplay;    //화면에 보여질 시간

    private void Start()
    {
        currentTime = 10f;
        Slider.SetActive(false);
        timeSlider.value = currentTime / MaxTime;  
    }

    void Update()
    {
        GoldStageDisplay();
    }

    public void GoldStageDisplay() //골드와 stage를 화면 상에 출력한다.
    {
        goldDisplay.text = "Gold : " + DataManager.Instance.gold + "\tStage : " + DataManager.Instance.stage;
        currentDisplay.text = (int)currentTime + "초";
    }
    
    public void DecreaseTime()  //시간 감소
    {
        Slider.SetActive(true);
        StartCoroutine(wait());
    }
    IEnumerator wait()   //시간 감소를 위한 대기시간을 위해 만듦
    {
        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            timeSlider.value = currentTime / MaxTime; //출력
            yield return new WaitForFixedUpdate();  //프레임 대기
            if (!EnemyManager.Instance.getExist()) //몬스터 뒤짐
            {
                break;
            }
        }
        if (EnemyManager.Instance.getExist()) //몬스터 뒤지지 않았다면 삭제후, 스테이지 초기화
        {   
            Enemy.Instance.ifdead();
            DataManager.Instance.DecreaseStage();
        }
        Slider.SetActive(false);
        currentTime = 10f;  //다시 초기화 해준다.
    }
}