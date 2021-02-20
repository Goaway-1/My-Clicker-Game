using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;    //file��� ����

public class UIManager : MonoBehaviour
{
    public Text stageDisplay;
    public Text goldDisplay;

    //timer
    public Slider timeSlider;
    public GameObject Slider;
    public float currentTime = 10f;  //���۽ð�
    const float MaxTime = 10f;      //�ִ�ð�(���� X) -->static���� ����ȴ�.
    public Text currentDisplay;    //ȭ�鿡 ������ �ð�
    public bool isCreasedTime = false;  //�ð� ���� �޺� �����Ѱ���?

    //Menu
    public Animator M_Ani;
    private bool M_isshow = false;
    public GameObject M_image;

    //Menu ��ȯ
    public GameObject UpgradeP;
    public GameObject MasterP;
    public GameObject ComboP;
    public GameObject MissonP;

    //���� ��ũ�� ����
    private ScrollRect scrollRect;
    private RectTransform content;

    //�ε�
    InventoryManger inventoryManger;

    private void OnEnable()
    {
        currentTime = 10f;
        Slider.SetActive(false);
        timeSlider.value = currentTime / MaxTime;

        //��������
        scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
        content = GameObject.Find("Content").GetComponent<RectTransform>();

        //������ �ε�
        inventoryManger = GameObject.Find("InventoryManager").GetComponent<InventoryManger>();
    }

    void FixedUpdate()
    {
        StageDisplay();
        GoldDisplay();
    }

    public void StageDisplay() //stage�� ȭ�� �� ����Ѵ�.
    {
        stageDisplay.text = "Stage : " + DataManager.Instance.stage;
        currentDisplay.text = (int)currentTime + "��";
    }
    public void GoldDisplay() //��带 ȭ�� �� ����Ѵ�.
    {
        goldDisplay.text = "Gold\n" + DataManager.Instance.gold;
    }

    public void DecreaseTime()  //���� ������ �ð� ����
    {
        Slider.SetActive(true);
        isCreasedTime = true; 
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
        isCreasedTime = false;
    }

    public void ShowMenu() //�޴��� ���� �� �Ҹ����
    {
        if (!M_isshow) //��������
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

    public void ResetButton()   //PlayerPrefs �����͸� ��� ����
    {
        File.Delete(Application.persistentDataPath + "/playerData.json");
        File.Delete(Application.persistentDataPath + "/playerDataCost.json");
        File.Delete(Application.persistentDataPath + "/playerMisson.json");
        File.Delete(Application.persistentDataPath + "/SlotData.json");
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
        inventoryManger.Load();
    }
    public void SwitchMisson()    //�����ϸ� Active�� ��/Ȱ��ȭ (Missonâ)
    {
        UpgradeP.SetActive(false);
        MasterP.SetActive(false);
        ComboP.SetActive(false);
        MissonP.SetActive(true);
        scrollRect.enabled = true; //��ũ�� Ȱ��ȭ
    }

    public void SwitchOn()  //��� â�� Ȱ��ȭ
    {
        UpgradeP.SetActive(true);
        MasterP.SetActive(true);
        ComboP.SetActive(true);
        MissonP.SetActive(true);
    }
    /// <summary>
    /// Menu�� ��ȯ
    /// </summary>
}