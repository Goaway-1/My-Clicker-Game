using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;    //file사용 위함

public class UIManager : MonoBehaviour
{
    public Text stageDisplay;
    public Text goldDisplay;

    //timer
    public Slider timeSlider;
    public GameObject Slider;
    public float currentTime = 10f;  //시작시간
    const float MaxTime = 10f;      //최대시간(변경 X) -->static으로 선언된다.
    public Text currentDisplay;    //화면에 보여질 시간
    public bool isCreasedTime = false;  //시간 증가 콤보 가능한가요?

    //Menu
    public Animator M_Ani;
    private bool M_isshow = false;
    public GameObject M_image;

    //Menu 전환
    public GameObject UpgradeP;
    public GameObject MasterP;
    public GameObject ComboP;
    public GameObject MissonP;

    //상하 스크롤 고정
    private ScrollRect scrollRect;
    private RectTransform content;

    //로드
    InventoryManger inventoryManger;

    private void OnEnable()
    {
        currentTime = 10f;
        Slider.SetActive(false);
        timeSlider.value = currentTime / MaxTime;

        //고정관련
        scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
        content = GameObject.Find("Content").GetComponent<RectTransform>();

        //데이터 로드
        inventoryManger = GameObject.Find("InventoryManager").GetComponent<InventoryManger>();
    }

    void FixedUpdate()
    {
        StageDisplay();
        GoldDisplay();
    }

    public void StageDisplay() //stage를 화면 상에 출력한다.
    {
        stageDisplay.text = "Stage : " + DataManager.Instance.stage;
        currentDisplay.text = (int)currentTime + "초";
    }
    public void GoldDisplay() //골드를 화면 상에 출력한다.
    {
        goldDisplay.text = "Gold\n" + DataManager.Instance.gold;
    }

    public void DecreaseTime()  //보스 생성시 시간 감소
    {
        Slider.SetActive(true);
        isCreasedTime = true; 
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
                DataManager.Instance.goldPerTake++; //골드 개수 증가
                break;
            }
        }
        if (EnemyManager.Instance.getExist()) //몬스터 뒤지지 않았다면 삭제후, 스테이지 초기화
        {   
            Enemy.Instance.bossNotDead();    //수정
            DataManager.Instance.DecreaseStage();
        }
        Slider.SetActive(false);
        currentTime = 10f;  //다시 초기화 해준다.
        isCreasedTime = false;
    }

    public void ShowMenu() //메뉴의 생성 및 소멸관리
    {
        if (!M_isshow) //보여주자
        {
            M_isshow = true;
            M_Ani.SetBool("isShow", true);
            M_image.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            M_isshow = false;
            M_Ani.SetBool("isShow", false);
            M_image.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    public void ResetButton()   //PlayerPrefs 데이터를 모두 삭제
    {
        File.Delete(Application.persistentDataPath + "/playerData.json");
        File.Delete(Application.persistentDataPath + "/playerDataCost.json");
        File.Delete(Application.persistentDataPath + "/playerMisson.json");
        File.Delete(Application.persistentDataPath + "/SlotData.json");
    }

    public void maxMoney()  //돈 급수
    {
        DataManager.Instance.gold += 9999999;
    }
    public void killEnemy() //데미지 금수
    {
        Enemy.Instance.decreased(999999999); //추후 수정 --> 싱글톤 삭제하자!
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
        scrollRect.enabled = true; //스크롤 활성화
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
        inventoryManger.Load();
    }
    public void SwitchMisson()    //선택하면 Active를 비/활성화 (Misson창)
    {
        UpgradeP.SetActive(false);
        MasterP.SetActive(false);
        ComboP.SetActive(false);
        MissonP.SetActive(true);
        scrollRect.enabled = true; //스크롤 활성화
    }

    public void SwitchOn()  //모든 창을 활성화
    {
        UpgradeP.SetActive(true);
        MasterP.SetActive(true);
        ComboP.SetActive(true);
        MissonP.SetActive(true);
    }
    /// <summary>
    /// Menu의 전환
    /// </summary>
}