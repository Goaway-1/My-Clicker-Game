using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterButton : MonoBehaviour
{
    public void maxMoney()
    {
        DataManager.Instance.gold += 9999999;
    }
    public void killEnemy()
    {
        Enemy.Instance.decreased(999999999); //���� ���� --> �̱��� ��������!
    }
}
