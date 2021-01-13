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

            if (strikePer >= rand)  //ũ��Ƽ�� ����!
            {
                n_power *= strikePow;  //��Ȼ����ϱ�
            }
            //������ ����

            //Combo ������� ����
            if (count == inven.slots.Count)
            {
                count = 0;
            }
            if (inven.slots[count].additionalD != 0)    //0�� �ƴҶ��� ����
            {
                n_power += n_power * inven.slots[count].additionalD;
                Debug.Log("@@��ȭ ����@@"); //����
            }

            //���������� �������� ������ �����ִ� ��
            playerAnimation.AttackAction(count);
            EffectManager.Instance.attckShow();
            Enemy.Instance.decreased(n_power); //���� ���� --> �̱��� ��������!n 
            count++;
        }
    }

    public static float getDamage()	//damage�� effect���� ȣ���Ҷ� ����Ѵ�. --> ���� ����(static�̱� ������)
    {
		return n_power;
    }
}
