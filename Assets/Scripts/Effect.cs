using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Rigidbody m_myrigid = null;
    public TextMesh m_text = null;
    private float transparency = 1f; //투명도

    private void OnEnable() //활성화 될때마다
    {
        if (m_myrigid == null)
        {
            m_myrigid = GetComponent<Rigidbody>();
        }
        transparency = 1f;
        m_text.color = new Color(0, 0, 0, 1f);
        m_myrigid.velocity = Vector3.zero;  //초기화 필수(속도값)
        setDamageText(AttackButton.getDamage());    //데미지를 설정한다.  
        m_myrigid.AddExplosionForce(100, transform.position, 1f);
        StartCoroutine(DestoryCube());
    }

    public void Update()
    {
        transparency -= Time.deltaTime;
        m_text.color = new Color(0, 0, 0, transparency);
    }

    IEnumerator DestoryCube()
    {
        yield return new WaitForSeconds(0.7f);  //추후 수정
        ObjectPoolingManager.instance.InsertQueue(gameObject);
    }

    public void setDamageText(float power)       //DamageText 설정
    {
        m_text.text = "" + power;
    }
}
