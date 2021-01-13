using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public AttackButton attackButton;

    //애니메이션
    public Animator animator;
    public InventoryManger inven;       //추후 싱글톤 & ItemAddButton과 동시에

    public void Start()
    {
        animator = GetComponent<Animator>(); //스스로를 넣는다.
    }

    public void Update()
    {
        RunAction();
    }

    public void AttackAction(int num)
    {
        switch (inven.slots[num].index)
        {
            case 1:
                animator.SetInteger("Attack", 1);
                break;
            case 2:
                animator.SetInteger("Attack", 2);
                break;
            case 3:
                animator.SetInteger("Attack", 3);
                break;
            case 4:
                animator.SetInteger("Attack", 4);
                break;
            case 5:
                animator.SetInteger("Attack", 5);
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
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }

    IEnumerator Wait() //강제로 모션 유지 시간 --> 추후 변경예정
    {
        yield return new WaitForSeconds(0.08f);
        animator.SetInteger("Attack", 0);
    }
}
