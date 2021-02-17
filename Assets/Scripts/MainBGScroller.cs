using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBGScroller : MonoBehaviour
{
    [SerializeField]
    BGScrollData[] ScrollDatas;

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

            //텍스쳐 이동
            scrollData.RenderForScroll.material.SetTextureOffset("_MainTex", offset);
            yield return new WaitForSeconds(0f);
        }
    }
}