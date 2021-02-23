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
    public SoundManager soundManager;

	//순서대로 공격
	public int count = 0;
	public InventoryManger inven;       //추후 싱글톤 & ItemAddButton과 동시에

    //Misson 관련
    MissonA missonA;

    //BossTime 증가 관련
    UIManager uiManager;

    private void Start()
    {
        missonA = GameObject.Find("AData").GetComponent<MissonA>();
        StartCoroutine(Auto());

        //skill관련
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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
            Json.Instance.LoadSlot();   //추가
            n_power = DataManager.Instance.power;
            strikePer = DataManager.Instance.criticalPer;

            //랜덤값을 정하는중
            num1 = Random.Range(0, 100);    //정수
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
            soundManager.SoundPlay(inven.slots[count].index);
            playerAnimation.AttackAction(inven.slots[count].index);
            EffectManager.Instance.attckShow();
            missonA.A_count++;  //미션 관련
            Enemy.Instance.decreased(n_power); //추후 수정 --> 싱글톤 삭제하자!n 
            count++;
        }
    }
    private void sumPower()    //Power 계산하는법
    {
        //Combo 순서대로 공격
        if (count == inven.slots.Count)
        {
            count = 0;
        }
        if (inven.slots[count].index != 0)    //0이 아닐때만 실행
        {
            skill();
            if (count == 2)
            {
                skillTurn();
            }
        }
        n_power = (float)System.Math.Round(n_power, 2); //2자리 수로 고정한다.
    }
    private void skill()        //기본 모션 한방한방에
    {
        switch (inven.slots[count].type)
        {
            case "Power":
                n_power += inven.slots[count].additionalD;
                break;
            case "Critical":
                if (strikePer >= rand)  //크리티컬 공격
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
                Debug.Log("기본공격");
                break;
        }
    }
    private void skillTurn()        //3타 콤보
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

    public static float getDamage()	//damage를 effect에서 호출할때 사용한다. --> 추후 수정(static이기 때문에)
    {
		return n_power;
    }
}
