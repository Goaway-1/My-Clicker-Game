using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterButton : MonoBehaviour
{
    public void maxMoney()
    {
        DataManager.GetInstance().SetGold(9999999);
    }
    public void killEnemy()
    {
        Enemy.GetInstance().decreased(999999999999); //���� ���� --> �̱��� ��������!
    }
}
