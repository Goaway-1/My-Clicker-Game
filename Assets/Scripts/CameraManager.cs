using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private void Awake()
    {
        Camera camera = gameObject.GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)9 / 16);    //�� ����Ʈ���� ����� �����´�.
        float scalewidth = 1f / scaleheight;
        if( scaleheight < 1)    //���Ϸ� �� ���
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else        //�¿�� �� ���
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }
}
