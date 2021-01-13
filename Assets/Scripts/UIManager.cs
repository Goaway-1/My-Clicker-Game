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
    private float currentTime = 10f;  //시작시간
    const float MaxTime = 10f;      //최대시간(변경 X) -->static으로 선언된다.
    public Text currentDisplay;    //화면에 보여질 시간

    //Menu
    public Animator M_Ani;
    public Text M_text;
    private bool M_isshow = false;

    //State 표시
    public GameObject S_Panel;
    private bool S_isShow = false;

    //Menu 전환
    public GameObject UpgradeP;
    public GameObject MasterP;
    public GameObject ComboP;
    public GameObject MissonP;

    //상하 스크롤 고정
    private ScrollRect scrollRect;
    private RectTransform content;

    private void Start()
    {
        currentTime = 10f;
        Slider.SetActive(false);
        timeSlider.value = currentTime / MaxTime;
        
        //고정관련
        scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
        content = GameObject.Find("Content").GetComponent<RectTransform>();
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
    
    public void DecreaseTime()  //보스 생성시 시간 감소
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

    public void ShowMenu() //메뉴의 생성 및 소멸관리
    {
        if (!M_isshow) //보여주자
        {
            M_isshow = true;
            M_Ani.SetBool("isShow", true);
            M_text.text = "Hide";
        }
        else
        {
            M_isshow = false;
            M_Ani.SetBool("isShow", false);
            M_text.text = "Show";
        }
    }

    public void ResetButton()   //PlayerPrefs 데이터를 모두 삭제
    {
        PlayerPrefs.DeleteAll();
    }

    public void maxMoney()  //돈 급수
    {
        DataManager.Instance.gold += 9999999;
    }
    public void killEnemy() //데미지 금수
    {
        Enemy.Instance.decreased(999999999); //추후 수정 --> 싱글톤 삭제하자!
    }

    public void ShowState() //State를 표시한다.
    {
        if (!S_isShow)
        {
            S_isShow = true;
            S_Panel.SetActive(true);
        }
        else
        {
            S_isShow = false;
            S_Panel.SetActive(false);
        }
    }

    /// <summary>
    /// Menu의 전환
    /// </summary>
    public void SwitchUpgrade()    //선택하면 Active를 비/활성화 (Button창)
    {
        UpgradeP.SetActive(true);
        MasterP.SetActive(false);
        ComboP.SetActive(false);
        MissonP.SetActive(false);
    }
    public void SwitchMaster()    //선택하면 Active를 비/활성화 (Master창)
    {
        UpgradeP.SetActive(false);
        MasterP.SetActive(true);
        ComboP.SetActive(false);
        MissonP.SetActive(false);
        scrollRect.enabled = true; //스크롤 활성화
    }
    public void SwitchCombo()    //선택하면 Active를 비/활성화 (Misson창)
    {
        UpgradeP.SetActive(false);
        MasterP.SetActive(false);
        ComboP.SetActive(true);
        MissonP.SetActive(false);
        scrollRect.enabled = false; //스크롤 비활성화
        content.anchoredPosition = new Vector2(0, -100);    //초기로 고정해버림
    }
    public void SwitchMisson()    //선택하면 Active를 비/활성화 (Misson창)
    {
        UpgradeP.SetActive(false);
        MasterP.SetActive(false);
        ComboP.SetActive(false);
        MissonP.SetActive(true);
    }
    /// <summary>
    /// Menu의 전환
    /// </summary>
}