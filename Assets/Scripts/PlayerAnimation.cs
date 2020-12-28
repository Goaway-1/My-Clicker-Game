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
        if (!attackButton.ispunch) //��ģ��.
        {
            animator.SetBool("attack", false);
        }
        else if(attackButton.ispunch)
        {
            animator.SetBool("attack", true);
        }
    }
}
