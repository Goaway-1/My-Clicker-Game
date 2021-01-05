using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
	public float speed;
	private float x;
	public float PontoDeDestino;
	public float PontoOriginal;

	private float currentTime = 0;
	private float MoveTime = 0.6f;	//����� �����̴� �ð�

    void Update()
	{
		if (EnemyManager.Instance.isMove)  //isMove�� true�϶��� ����� �����δ�.
		{
			Move();
		}
        else
        {
			currentTime = 0;
        }

		if (currentTime >= MoveTime && EnemyManager.Instance.isMove)	//���� �ð��� ������ ����� �����Ѵ�. 
		{
			EnemyManager.Instance.isMove = false;
		}
	}

    void Move()
    {
		currentTime += Time.deltaTime;
		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3(x, transform.position.y, transform.position.z);

		if (x <= PontoDeDestino)
		{
			x = PontoOriginal;
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}
	}
}
