using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
	//�ִϰ���
	public bool ispunch = false;

    public void OnClick() //Ŭ���� Manager���� �ҷ���
    {
        if (EnemyManager.isExist)
        {
			ispunch = true;
            float power = DataManager.GetInstance().GetPower();
			float strikePer = DataManager.GetInstance().GetStrikePer();
			float strikePow = DataManager.GetInstance().GetStrikePow();

			//1�� �þ� (����)  @@@@@@@@@@@@@@@@@@@@@@@ ���߿� ���� ������ ������
			//float num1 = Random.Range(0, 1000);
			////float num1 = GetRandom(Random.Range(0, 1000), Random.Range(0, 1000)); -->���
			//Debug.Log("num1 : " + num1);
			//float num2 = Random.Range(10,100);
			////float num2 = GetRandom(Random.Range(10, 100), Random.Range(10, 100)); -->���
			//Debug.Log("num2 : " + num2);
			//float rand = num1/num2;
			//Debug.Log("rand : " + rand);

			//1�� �þ� (����)  @@@@@@@@@@@@@@@@@@@@@@@

			//2�� �þ� (����)  @@@@@@@@@@@@@@@@@@@@@@@ ���߿� ���� ������ ������
			float num1 = Random.Range(0, 100);	//���� ->(int�� ����?)
			float num2 = Random.Range(0, 100);  //�Ҽ�
			string num_str = num2.ToString();
			int num_len = num_str.Length;

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

            float rand = num1 + num2;
			//2�� �þ� (����)  @@@@@@@@@@@@@@@@@@@@@@@

			if (strikePer >= rand)
            {
				power = Mathf.Pow(power, strikePow); 
				Debug.Log("Critical : " + rand + " @@@@");
            }

			Debug.Log("���� : " + power);
            Enemy.GetInstance().decreased(power); //���� ���� -> �̱��� ��������

			StartCoroutine(Wait());
		}
	}
	
	IEnumerator Wait() //��� ���� �ð� --> ���� ���濹��
    {
		yield return new WaitForSeconds(0.43f);
		ispunch = false;
	}

	public float GetRandom(int xMinusOneSeed, int xMinusTwoSeed) //���� �� ��üȭ �Ѱ�
	{
		int xMinusOne = xMinusOneSeed;
		int xMinusTwo = xMinusTwoSeed;
		int randomNumber = 0;

		//�ø���� ���� ���⿡ �����Ѵ�.
		int m = int.MaxValue;
		Debug.Log("m:" + m);

		for (int i = 0; i < 5; i++)
		{
			int sum = xMinusOne + xMinusTwo;

			if (xMinusOne + xMinusTwo < 0)
			{
				sum = int.MaxValue;
			}

			randomNumber = sum % m % 10;

			xMinusTwo = xMinusOne;
			xMinusOne = randomNumber;
		}
		return randomNumber;
	}
}
