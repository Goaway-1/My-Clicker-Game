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
	private float MoveTime = 0.85f;	//����� �����̴� �ð�

    void Update()
	{
		if (EnemyManager.GetInstance().isMove)  //isMove�� true�϶��� ����� �����δ�.
		{
			Move();
		}
        else
        {
			currentTime = 0;
        }

		if (currentTime >= MoveTime && EnemyManager.GetInstance().isMove)	//���� �ð��� ������ ����� �����Ѵ�. 
		{
			EnemyManager.GetInstance().isMove = false;
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
