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
	private float MoveTime = 0.7f;	//배경이 움직이는 시간

    void Update()
	{
        if (EnemyManager.GetInstance().isMove)
        {
			Debug.Log("배경이동 ");
			Move();
		}

		if (currentTime >= MoveTime)
		{
			Debug.Log("배경이동22222 ");
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
