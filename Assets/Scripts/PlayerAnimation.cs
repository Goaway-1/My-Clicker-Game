using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public AttackButton attackButton;

    //�ִϸ��̼�
    public Animator animator;
    public InventoryManger inven;       //���� �̱��� & ItemAddButton�� ���ÿ�

    public void Start()
    {
        animator = GetComponent<Animator>(); //�����θ� �ִ´�.
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
        if (!EnemyManager.Instance.isMove) //��ģ��.
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }

    IEnumerator Wait() //������ ��� ���� �ð� --> ���� ���濹��
    {
        yield return new WaitForSeconds(0.08f);
        animator.SetInteger("Attack", 0);
    }
}
