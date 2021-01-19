using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackButton : MonoBehaviour
{
    public PlayerAnimation playerAnimation;

	static float n_power;
	float strikePer;
	float strikePow;
	float num1;  //정수 ->(int형 쓸까?)
	float num2;  //소수
	string num_str;
	int num_len;
	float rand;

    //애니관련(데미지 효과)
	public Effect effect;

	//순서대로 공격
	public int count = 0;
	public InventoryManger inven;       //추후 싱글톤 & ItemAddButton과 동시에

    private void Start()
    {
        StartCoroutine(Auto());
    }
    IEnumerator Auto()  //자동 클릭
    {
        while (true)
        {
            OnClick();
            yield return new WaitForSeconds(DataManager.Instance.AutoC);
        }
    }

    public void OnClick() //클릭시 Manager에서 불러옴
    {
        if (EnemyManager.Instance.getExist())
        {
            n_power = DataManager.Instance.power;
            strikePer = DataManager.Instance.criticalPer;
            strikePow = DataManager.Instance.criticalPow;

            //랜덤값을 정하는중
            num1 = Random.Range(0, 100);    //정수 ->(int형 쓸까?)
            num2 = Random.Range(0, 100);  //소수
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
            //랜덤값 종료

            sumPower();

            //실질적으로 데미지를 입히고 보여주는 곳
            playerAnimation.AttackAction(count);
            EffectManager.Instance.attckShow();
            Enemy.Instance.decreased(n_power); //추후 수정 --> 싱글톤 삭제하자!n 
            count++;
        }
    }
    private void sumPower()    //Power 계산하는법
    {
        if (strikePer >= rand)  //크리티컬 공격!
        {
            n_power *= strikePow;  //대안생각하기
            Debug.Log("크리티컬");
        }

        //Combo 순서대로 공격
        if (count == inven.slots.Count)
        {
            count = 0;
        }
        if (inven.slots[count].additionalD != 0)    //0이 아닐때만 실행
        {
            if (count != 2)  //원래는 3인데 0부터 시작했으니 2가 되야한다.
            {
                n_power += n_power * inven.slots[count].additionalD;
            }
            else        //조건이 맞다면 3타 가능
            {
                if (inven.slots[0].index == 1 && inven.slots[1].index == 2 && inven.slots[2].index == 3)    //못줄이나...?
                {
                    n_power += n_power * 3;
                    Debug.Log("@@3번째 강화 공격(*3)@@"); //삭제
                }
                else if(inven.slots[0].index == 1 && inven.slots[1].index == 2 && inven.slots[2].index == 4)
                {
                    n_power = 99999999;
                    Debug.Log("@@3번째 강화 공격(즉살)@@"); //삭제
                }
            }
        }
        n_power = (float)System.Math.Round(n_power, 2); //2자리 수로 고정한다.
    }
    public static float getDamage()	//damage를 effect에서 호출할때 사용한다. --> 추후 수정(static이기 때문에)
    {
		return n_power;
    }
}
