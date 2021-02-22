using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    bool isMuted;
    Animator ani;

    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        isMuted = PlayerPrefs.GetInt("Muted") == 1;     //bool ���̱� ������
        ani.SetBool("isOn", !isMuted);                  //Animator�߰�
        AudioListener.pause = isMuted;
    }

    public void MutePressed()   //Ŭ����
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        ani.SetBool("isOn", !isMuted);
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }
}
