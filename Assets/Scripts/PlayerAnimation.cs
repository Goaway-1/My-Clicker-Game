using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public AttackButton attackButton;

    //애니메이션
    public Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>(); //스스로를 넣는다.
    }

    public void Update()
    {
        AttackAction();
        RunAction();
    }

    private void AttackAction()
    {
        if (!attackButton.ispunch) //안친다.
        {
            animator.SetBool("Attack", false);
        }
        else
        {
            animator.SetBool("Attack", true);
        }
    }

    private void RunAction()
    {
        if (!EnemyManager.Instance.isMove) //안친다.
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }
}
