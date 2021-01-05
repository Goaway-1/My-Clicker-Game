using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
	//애니관련
	public bool ispunch = false;

	//데미지 효과
	public Effect effect;

	static float n_power;
	float strikePer;
	float strikePow;

	public void OnClick() //클릭시 Manager에서 불러옴
    {
        if (EnemyManager.Instance.getExist())
        {
			ispunch = true;
            n_power = DataManager.Instance.power;
			strikePer = DataManager.Instance.criticalPer;
			strikePow = DataManager.Instance.criticalPow;

			//나중에 전역 변수로 돌리자
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
			//

			if (strikePer >= rand)	//크리티컬 공격!
            {
				n_power *= strikePow;  //대안생각하기
            }

			effect.isChange = true;
			EffectManager.Instance.attckShow();
			Enemy.Instance.decreased(n_power); //추후 수정 --> 싱글톤 삭제하자!

			StartCoroutine(Wait());
		}
	}

	public static float damText()	//damage를 effect에서 호출할때 사용한다. --> 추후 수정(static이기 때문에)
    {
		return n_power;
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
