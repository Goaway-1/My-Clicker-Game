using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    bool isMuted;
    Animator ani;

    //Attack Sound
    public AudioSource[] sound;

    private void Start()
    {
        ani = GameObject.Find("SoundMute").GetComponent<Animator>();
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

    public void SoundPlay(int num)  //index 들어온다.
    {
        switch (num)
        {
            case 1:
                sound[num - 1].Play();
                break;
            case 2:
                sound[num - 1].Play();
                break;
            case 3:
                sound[num - 1].Play();
                break;
            case 4:
                sound[num - 1].Play();
                break;
            case 5:
                sound[num - 1].Play();
                break;
            default:
                break;
        }
    }
}
