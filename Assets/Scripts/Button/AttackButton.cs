using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public PlayerAnimation playerAnimation;

	static float n_power;
	float strikePer;
	float strikePow;
	float num1;  //���� ->(int�� ����?)
	float num2;  //�Ҽ�
	string num_str;
	int num_len;
	float rand;

    //�ִϰ���(������ ȿ��)
	public Effect effect;
    public SoundManager soundManager;

	//������� ����
	public int count = 0;
	public InventoryManger inven;       //���� �̱��� & ItemAddButton�� ���ÿ�

    //Misson ����
    MissonA missonA;

    //BossTime ���� ����
    UIManager uiManager;

    private void Start()
    {
        missonA = GameObject.Find("AData").GetComponent<MissonA>();
        StartCoroutine(Auto());

        //skill����
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    IEnumerator Auto()  //�ڵ� Ŭ��
    {
        while (true)
        {
            OnClick();
            yield return new WaitForSeconds(DataManager.Instance.AutoC);
        }
    }

    public void OnClick() //Ŭ���� Manager���� �ҷ���
    {
        if (EnemyManager.Instance.getExist())
        {
            Json.Instance.LoadSlot();   //�߰�
            n_power = DataManager.Instance.power;
            strikePer = DataManager.Instance.criticalPer;

            //�������� ���ϴ���
            num1 = Random.Range(0, 100);    //����
            num2 = Random.Range(0, 100);  //�Ҽ�
            num_str = num2.ToString();
            num_len = num_str.Length;

            switch (num_len)
            {
                case 1:
                    num2 /= 10;
                    break;
                case 2:
                    num2 /= 100;
                    break;
                default:
                    break;
            }
            rand = num1 + num2;
            //������ ����

            sumPower();

            //���������� �������� ������ �����ִ� ��
            soundManager.SoundPlay(inven.slots[count].index);
            playerAnimation.AttackAction(inven.slots[count].index);
            EffectManager.Instance.attckShow();
            missonA.A_count++;  //�̼� ����
            Enemy.Instance.decreased(n_power); //���� ���� --> �̱��� ��������!n 
            count++;
        }
    }
    private void sumPower()    //Power ����ϴ¹�
    {
        //Combo ������� ����
        if (count == inven.slots.Count)
        {
            count = 0;
        }
        if (inven.slots[count].index != 0)    //0�� �ƴҶ��� ����
        {
            skill();
            if (count == 2)
            {
                skillTurn();
            }
        }
        n_power = (float)System.Math.Round(n_power, 2); //2�ڸ� ���� �����Ѵ�.
    }
    private void skill()        //�⺻ ��� �ѹ��ѹ濡
    {
        switch (inven.slots[count].type)
        {
            case "Power":
                n_power += inven.slots[count].additionalD;
                break;
            case "Critical":
                if (strikePer >= rand)  //ũ��Ƽ�� ����
                {
                    n_power += n_power * inven.slots[count].additionalD;
                }
                break;
            case "Gold":
                if(Random.Range(0, 2) == 1)
                {
                    DataManager.Instance.gold += (int)inven.slots[count].additionalD;
                }
                break;
            case "BossTime":
                if (uiManager.isCreasedTime)
                {
                    uiManager.currentTime += inven.slots[count].additionalD;
                }
                break;
            default:    
                Debug.Log("�⺻����");
                break;
        }
    }
    private void skillTurn()        //3Ÿ �޺�
    {
        if (inven.slots[0].index == 1 && inven.slots[1].index == 2 && inven.slots[2].index == 3)  
        {
            n_power += n_power * 2.1f;
        }
        else if (inven.slots[0].index == 3 && inven.slots[1].index == 2 && inven.slots[2].index == 1)
        {
            n_power += n_power * 1.4f;
        }
        else if (inven.slots[0].index == 5 && inven.slots[1].index == 4 && inven.slots[2].index == 3)
        {
            n_power += n_power * 3.2f;
        }
        else if (inven.slots[0].index == 3 && inven.slots[1].index == 5 && inven.slots[2].index == 2)
        {
            n_power += n_power * 4.7f;
        }
    }

    public static float getDamage()	//damage�� effect���� ȣ���Ҷ� ����Ѵ�. --> ���� ����(static�̱� ������)
    {
		return n_power;
    }
}
