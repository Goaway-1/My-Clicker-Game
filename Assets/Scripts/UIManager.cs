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
    public float currentTime = 10f;  //���۽ð�
    const float MaxTime = 10f;      //�ִ�ð�(���� X) -->static���� ����ȴ�.
    public Text currentDisplay;    //ȭ�鿡 ������ �ð�

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

    public void GoldStageDisplay() //���� stage�� ȭ�� �� ����Ѵ�.
    {
        goldDisplay.text = "Gold : " + DataManager.Instance.gold + "\tStage : " + DataManager.Instance.stage;
        currentDisplay.text = (int)currentTime + "��";
    }
    
    public void DecreaseTime()  //�ð� ����
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
                break;
            }
        }
        if (EnemyManager.Instance.getExist()) //���� ������ �ʾҴٸ� ������, �������� �ʱ�ȭ
        {   
            Enemy.Instance.ifdead();
            DataManager.Instance.DecreaseStage();
        }
        Slider.SetActive(false);
        currentTime = 10f;  //�ٽ� �ʱ�ȭ ���ش�.
    }
}