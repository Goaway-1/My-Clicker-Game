using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Rigidbody m_myrigid = null;
    public TextMesh tt = null;
    private float transparency = 1f; //투명도

    private void OnEnable() //활성화 될때마다
    {
        if (m_myrigid == null)
        {
            m_myrigid = GetComponent<Rigidbody>();
        }

        transparency = 1f;
        tt.color = new Color(0, 0, 0, 1f);
        m_myrigid.velocity = Vector3.zero; //초기화 필수(속도값)
        m_myrigid.AddExplosionForce(100, transform.position, 1f);
        StartCoroutine(DestoryCube());
    }

    public void Update()
    {
        transparency -= Time.deltaTime;
        tt.color = new Color(0, 0, 0, transparency);
    }

    IEnumerator DestoryCube()
    {
        yield return new WaitForSeconds(0.7f);  //추후 수정
        ObjectPoolingManager.instance.InsertQueue(gameObject);
    }

    public void setPower(float power)
    {
        tt.text = "" + power;
    }
}
