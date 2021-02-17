using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    BGScrollData[] ScrollDatas;

    private float currentTime = 0;
    private float MoveTime = 0.6f;	//����� �����̴� �ð�

    private void Start()
    {
        for (int i = 0; i < ScrollDatas.Length; i++)
        {
            if (ScrollDatas[i].Always)
            {
                StartCoroutine(set(ScrollDatas[i]));
            }
        }
    }

    void FixedUpdate()
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
            if (!ScrollDatas[i].Always)
            {
                SetTextureOffset(ScrollDatas[i]);
            }
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
    IEnumerator set(BGScrollData scrollData)
    {
        while (true)
        {
            scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime;
            if (scrollData.OffsetX > 1)
            {
                scrollData.OffsetX = scrollData.OffsetX % 1.0f;
            }
            Vector2 offset = new Vector2(scrollData.OffsetX, 0);

            //�ؽ��� �̵�
            scrollData.RenderForScroll.material.SetTextureOffset("_MainTex", offset);
            yield return new WaitForSeconds(0f);
        }
    }
}
[System.Serializable]
public class BGScrollData
{
    public Renderer RenderForScroll;
    public float Speed;
    public float OffsetX;
    public bool Always;
}
