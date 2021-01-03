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
	private float MoveTime = 0.7f;	//����� �����̴� �ð�

    void Update()
	{
        if (EnemyManager.GetInstance().isMove)
        {
			Debug.Log("����̵� ");
			Move();
		}

		if (currentTime >= MoveTime)
		{
			Debug.Log("����̵�22222 ");
			EnemyManager.GetInstance().isMove = false;
			currentTime = 0;
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
