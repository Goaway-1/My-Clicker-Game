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
    private float currentTime = 10f;  //���۽ð�
    const float MaxTime = 10f;      //�ִ�ð�(���� X) -->static���� ����ȴ�.
    public Text currentDisplay;    //ȭ�鿡 ������ �ð�

    //Menu
    public Animator M_Ani;
    public Text M_text;
    private bool M_isshow = false;

    //Menu ��ȯ
    public GameObject UpgradeP;
    public GameObject MasterP;
    public GameObject ComboP;
    public GameObject MissonP;

    //���� ��ũ�� ����
    private ScrollRect scrollRect;
    private RectTransform content;

    private void Start()
    {
        currentTime = 10f;
        Slider.SetActive(false);
        timeSlider.value = currentTime / MaxTime;
        
        //��������
        scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
        content = GameObject.Find("Content").GetComponent<RectTransform>();
    }

    void Update()
    {
        GoldStageDisplay();
    }

    public void GoldStageDisplay() //���� stage�� ȭ�� �� ����Ѵ�.
    {
        goldDisplay.text = "Gold : " + DataManager.Instance.gold + "\tStage : " + DataManager.Instance.stage;
        currentDisplay.text = (int)currentTime + "��";
    }
    
    public void DecreaseTime()  //���� ������ �ð� ����
    {
        Slider.SetActive(true);
        StartCoroutine(wait());
    }
    IEnumerator wait()   //�ð� ���Ҹ� ���� ���ð��� ���� ����
    {
        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            timeSlider.value = currentTime / MaxTime; //���
            yield return new WaitForFixedUpdate();  //������ ���
            if (!EnemyManager.Instance.getExist()) //���� ����
            {
                DataManager.Instance.goldPerTake++; //��� ���� ����
                break;
            }
        }
        if (EnemyManager.Instance.getExist()) //���� ������ �ʾҴٸ� ������, �������� �ʱ�ȭ
        {   
            Enemy.Instance.bossNotDead();    //����
            DataManager.Instance.DecreaseStage();
        }
        Slider.SetActive(false);
        currentTime = 10f;  //�ٽ� �ʱ�ȭ ���ش�.
    }

    public void ShowMenu() //�޴��� ���� �� �Ҹ����
    {
        if (!M_isshow) //��������
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

    public void ResetButton()   //PlayerPrefs �����͸� ��� ����
    {
        PlayerPrefs.DeleteAll();
    }

    public void maxMoney()  //�� �޼�
    {
        DataManager.Instance.gold += 9999999;
    }
    public void killEnemy() //������ �ݼ�
    {
        Enemy.Instance.decreased(999999999); //���� ���� --> �̱��� ��������!
    }
    /// <summary>
    /// Menu�� ��ȯ
    /// </summary>
    public void SwitchUpgrade()    //�����ϸ� Active�� ��/Ȱ��ȭ (Buttonâ)
    {
        UpgradeP.SetActive(true);
        MasterP.SetActive(false);
        ComboP.SetActive(false);
        MissonP.SetActive(false);
        scrollRect.enabled = true; //��ũ�� Ȱ��ȭ
    }
    public void SwitchMaster()    //�����ϸ� Active�� ��/Ȱ��ȭ (Masterâ)
    {
        UpgradeP.SetActive(false);
        MasterP.SetActive(true);
        ComboP.SetActive(false);
        MissonP.SetActive(false);
        scrollRect.enabled = true; //��ũ�� Ȱ��ȭ
    }
    public void SwitchCombo()    //�����ϸ� Active�� ��/Ȱ��ȭ (Missonâ)
    {
        UpgradeP.SetActive(false);
        MasterP.SetActive(false);
        ComboP.SetActive(true);
        MissonP.SetActive(false);
        scrollRect.enabled = false; //��ũ�� ��Ȱ��ȭ
        content.anchoredPosition = new Vector2(0, -100);    //�ʱ�� �����ع���
    }
    public void SwitchMisson()    //�����ϸ� Active�� ��/Ȱ��ȭ (Missonâ)
    {
        UpgradeP.SetActive(false);
        MasterP.SetActive(false);
        ComboP.SetActive(false);
        MissonP.SetActive(true);
        scrollRect.enabled = true; //��ũ�� Ȱ��ȭ
    }
    /// <summary>
    /// Menu�� ��ȯ
    /// </summary>
}