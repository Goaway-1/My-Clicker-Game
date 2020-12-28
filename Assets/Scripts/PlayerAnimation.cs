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
        if (!attackButton.ispunch) //안친다.
        {
            animator.SetBool("attack", false);
        }
        else if(attackButton.ispunch)
        {
            animator.SetBool("attack", true);
        }
    }
}
