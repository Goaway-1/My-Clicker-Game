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

	//������� ����
	public int count = 0;
	public InventoryManger inven;       //���� �̱��� & ItemAddButton�� ���ÿ�

    //Misson ����
    MissonA missonA;

    private void Start()
    {
        missonA = GameObject.Find("MissonA").GetComponent<MissonA>();
        StartCoroutine(Auto());
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
            n_power = DataManager.Instance.power;
            strikePer = DataManager.Instance.criticalPer;
            strikePow = DataManager.Instance.criticalPow;

            //�������� ���ϴ���
            num1 = Random.Range(0, 100);    //���� ->(int�� ����?)
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
            playerAnimation.AttackAction(count);
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
            if (count == 3)
            {
                skillTurn();
            }
        }
        n_power = (float)System.Math.Round(n_power, 2); //2�ڸ� ���� �����Ѵ�.
    }
    private void skill()        //�⺻ ��� �ѹ��ѹ濡
    {
        if(inven.slots[count].type.Equals("Power"))
        {
            n_power += n_power * inven.slots[count].additionalD;
            Debug.Log("�߰� ���ݷ�");
        }
        else if(inven.slots[count].type.Equals("Critical"))
        {
            //if (strikePer >= rand)  //ũ��Ƽ�� ����
            //{
            //    n_power *= strikePow;  //��Ȼ����ϱ�
            //}
            //n_power *= strikePow;  
            n_power *= 3;  
            Debug.Log("�߰� ũ��Ƽ��");
        }
        else if (inven.slots[count].type.Equals("Money"))
        {
            //dropMoney�� �߰������ �߰�
        }
    }
    private void skillTurn()        //��������ǿ� �߰�
    {
        if (inven.slots[0].index == 1 && inven.slots[1].index == 2 && inven.slots[2].index == 3)    //�����̳�...?
        {
            n_power += n_power * 3;
            Debug.Log("@@3��° ��ȭ ����(*3)@@"); //����
        }
        else if (inven.slots[0].index == 1 && inven.slots[1].index == 2 && inven.slots[2].index == 4)
        {
            n_power = 99999999;
            Debug.Log("@@3��° ��ȭ ����(���)@@"); //����
        }
    }
    public static float getDamage()	//damage�� effect���� ȣ���Ҷ� ����Ѵ�. --> ���� ����(static�̱� ������)
    {
		return n_power;
    }
}
