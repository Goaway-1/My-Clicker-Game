using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthManager : MonoBehaviour
{
    public void Rebirth()  //�ʱ�ȭ ���� ���� Stage 100 ���� �� ���� stage�� ���
    {
        if(DataManager.Instance.stage >= 100)
        {
            //Rebirth.json ������ �� ���� --> �⺻ ��� �� ���� --> ������ ���� --> ���� ���� �ؾߵɰ�!
            //Rebirth.json ���� ������ �� ����
            //���� �ٽ� �ҷ���

        }
        else
        {
            Debug.Log("ȯ�� �Ұ��� : 100stage ����");
        }
    }
}
