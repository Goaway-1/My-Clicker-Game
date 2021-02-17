using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private void Awake()
    {
        Camera camera = gameObject.GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)9 / 16);    //내 스마트폰의 기록을 가져온다.
        float scalewidth = 1f / scaleheight;
        if( scaleheight < 1)    //상하로 긴 경우
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else        //좌우로 긴 경우
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }
}
