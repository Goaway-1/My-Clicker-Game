using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public AttackButton attackButton;

    //애니메이션
    public Animator animator;
    public InventoryManger inven;       //추후 싱글톤 & ItemAddButton과 동시에

    //사운드
    AudioSource sound;
    bool isOnce = true;

    public void Start()
    {
        animator = GetComponent<Animator>(); //스스로를 넣는다.  
        sound = GetComponent<AudioSource>();
    }

    public void FixedUpdate()
    {
        RunAction();
    }

    public void AttackAction(int num)
    {
        Json.Instance.LoadSlot();
        switch (num)
        {
            case 1:
                animator.SetInteger("Attack", num);
                break;
            case 2:
                animator.SetInteger("Attack", num);
                break;
            case 3:
                animator.SetInteger("Attack", num);
                break;
            case 4:
                animator.SetInteger("Attack", num);
                break;
            case 5:
                animator.SetInteger("Attack", num);
                break;
            default:
                break;
        }
        StartCoroutine(Wait());
    }

    private void RunAction()
    {
        if (!EnemyManager.Instance.isMove) //안친다.
        {
            sound.Stop();
            animator.SetBool("Run", false);
            isOnce = true;
        }
        else
        {
            if (isOnce)
            {
                sound.Play();
                isOnce = false;
            }
            animator.SetBool("Run", true);
        }
    }

    IEnumerator Wait() //강제로 모션 유지 시간 --> 추후 변경예정
    {
        yield return new WaitForSeconds(0.33f);
        animator.SetInteger("Attack", 0);
    }
}
