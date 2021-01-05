using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public AttackButton attackButton;

    //�ִϸ��̼�
    public Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>(); //�����θ� �ִ´�.
    }

    public void Update()
    {
        AttackAction();
        RunAction();
    }

    private void AttackAction()
    {
        if (!attackButton.ispunch) //��ģ��.
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
        if (!EnemyManager.Instance.isMove) //��ģ��.
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }
}
