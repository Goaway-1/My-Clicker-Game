using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
	//애니관련
	public bool ispunch = false;

    public void OnClick() //클릭시 Manager에서 불러옴
    {
        if (EnemyManager.isExist)
        {
			ispunch = true;
            float power = DataManager.GetInstance().GetPower();
			float strikePer = DataManager.GetInstance().GetCriticalPer();
			float strikePow = DataManager.GetInstance().GetCritical();

			//1번 시안 (시작)  @@@@@@@@@@@@@@@@@@@@@@@ 나중에 전역 변수로 돌리자
			//float num1 = Random.Range(0, 1000);
			////float num1 = GetRandom(Random.Range(0, 1000), Random.Range(0, 1000)); -->대안
			//Debug.Log("num1 : " + num1);
			//float num2 = Random.Range(10,100);
			////float num2 = GetRandom(Random.Range(10, 100), Random.Range(10, 100)); -->대안
			//Debug.Log("num2 : " + num2);
			//float rand = num1/num2;
			//Debug.Log("rand : " + rand);

			//1번 시안 (종료)  @@@@@@@@@@@@@@@@@@@@@@@

			//2번 시안 (시작)  @@@@@@@@@@@@@@@@@@@@@@@ 나중에 전역 변수로 돌리자
			float num1 = Random.Range(0, 100);	//정수 ->(int형 쓸까?)
			float num2 = Random.Range(0, 100);  //소수
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
			//2번 시안 (종료)  @@@@@@@@@@@@@@@@@@@@@@@

			if (strikePer >= rand)
            {
				power = power * strikePow;  //대안생각하기
				Debug.Log("크리티컬 공격 : " + power);
            }
            else
            {
				Debug.Log("공격 : " + power);
			}

            Enemy.GetInstance().decreased(power); //추후 수정 -> 싱글톤 삭제하자

			StartCoroutine(Wait());
		}
	}
	
	IEnumerator Wait() //모션 유지 시간 --> 추후 변경예정
    {
		yield return new WaitForSeconds(0.43f);
		ispunch = false;
	}

	public float GetRandom(int xMinusOneSeed, int xMinusTwoSeed) //조금 더 구체화 한것
	{
		int xMinusOne = xMinusOneSeed;
		int xMinusTwo = xMinusTwoSeed;
		int randomNumber = 0;

		//시리즈는 끝이 없기에 제한한다.
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
