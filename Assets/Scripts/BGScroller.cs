using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    BGScrollData[] ScrollDatas;

    private float currentTime = 0;
    private float MoveTime = 0.6f;	//����� �����̴� �ð�

    void Update()
    {
        if (EnemyManager.Instance.isMove)  //isMove�� true�϶��� ����� �����δ�.
        {
            updateScroll();
        }
        else
        {
            currentTime = 0;
        }

        if (currentTime >= MoveTime && EnemyManager.Instance.isMove)    //���� �ð��� ������ ����� �����Ѵ�. 
        {
            EnemyManager.Instance.isMove = false;
        }
    }

    void updateScroll()
    {
        currentTime += Time.deltaTime;
        for (int i = 0; i < ScrollDatas.Length; i++)
        {
            SetTextureOffset(ScrollDatas[i]);
        }
    }

    void SetTextureOffset(BGScrollData scrollData)
    {
        //������ ���� ��Ų��.
        scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime;
        if (scrollData.OffsetX > 1)
        {
            scrollData.OffsetX = scrollData.OffsetX % 1.0f;
        }
        Vector2 offset = new Vector2(scrollData.OffsetX, 0);

        //�ؽ��� �̵�
        scrollData.RenderForScroll.material.SetTextureOffset("_MainTex", offset);
    }
}
[System.Serializable]
public class BGScrollData
{
    public Renderer RenderForScroll;
    public float Speed;
    public float OffsetX;
}
