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
	private float MoveTime = 0.6f;	//배경이 움직이는 시간

    void Update()
	{
		if (EnemyManager.Instance.isMove)  //isMove가 true일때만 배경을 움직인다.
		{
			Move();
		}
        else
        {
			currentTime = 0;
        }

		if (currentTime >= MoveTime && EnemyManager.Instance.isMove)	//일정 시간이 지나면 배경을 정지한다. 
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
