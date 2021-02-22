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
        isMuted = PlayerPrefs.GetInt("Muted") == 1;     //bool 값이기 때문에
        ani.SetBool("isOn", !isMuted);                  //Animator추가
        AudioListener.pause = isMuted;
    }

    public void MutePressed()   //클릭시
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        ani.SetBool("isOn", !isMuted);
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }
}
