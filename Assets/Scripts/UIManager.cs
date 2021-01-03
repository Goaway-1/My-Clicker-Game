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
    public float currentTime;  //���۽ð�
    private float MaxTime;      //�ִ�ð�
    public Text currentDisplay;    //ȭ�鿡 ������ �ð�

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

    public void GoldStageDisplay() //���� stage�� ȭ�� �� ����Ѵ�.
    {
        goldDisplay.text = "Gold : " + DataManager.GetInstance().GetGold() + "\tStage : " + DataManager.GetInstance().GetStage();
        currentDisplay.text = (int)currentTime + "��";
    }
    
    public void DecreaseTime()  //�ð� ����
    {
        Slider.SetActive(true);
        StartCoroutine(wait());
    }
    public IEnumerator wait()   //�ð� ���Ҹ� ���� ���ð��� ���� ����
    {
        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            timeSlider.value = currentTime / MaxTime; //���
            yield return new WaitForFixedUpdate();  //������ ���
            Debug.Log(currentTime);
        }
        if(currentTime <= 0)
        {
            Slider.SetActive(false);
        }
    }
}
