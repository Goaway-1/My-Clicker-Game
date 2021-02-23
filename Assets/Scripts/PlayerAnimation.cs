using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public AttackButton attackButton;

    //�ִϸ��̼�
    public Animator animator;
    public InventoryManger inven;       //���� �̱��� & ItemAddButton�� ���ÿ�

    //����
    AudioSource sound;
    bool isOnce = true;

    public void Start()
    {
        animator = GetComponent<Animator>(); //�����θ� �ִ´�.  
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
        if (!EnemyManager.Instance.isMove) //��ģ��.
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

    IEnumerator Wait() //������ ��� ���� �ð� --> ���� ���濹��
    {
        yield return new WaitForSeconds(0.33f);
        animator.SetInteger("Attack", 0);
    }
}
