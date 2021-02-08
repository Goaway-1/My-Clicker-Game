using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthManager : MonoBehaviour
{
    public void Rebirth()  //초기화 또한 진행 Stage 100 도달 시 가능 stage에 비례
    {
        if(DataManager.Instance.stage >= 100)
        {
            //Rebirth.json 데이터 값 수정 --> 기본 상승 값 조절 --> 변수로 선언 --> 가장 먼저 해야될것!
            //Rebirth.json 외의 데이터 값 삭제
            //게임 다시 불러옴

        }
        else
        {
            Debug.Log("환생 불가능 : 100stage 이하");
        }
    }
}
