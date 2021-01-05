using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Rigidbody m_myrigid = null;
    public TextMesh m_text = null;
    private float transparency = 1f; //����

    public bool isChange = false; //DamageText�� �ѹ� �ٲܶ� ���

    private void OnEnable() //Ȱ��ȭ �ɶ�����
    {
        if (m_myrigid == null)
        {
            m_myrigid = GetComponent<Rigidbody>();
        }
        transparency = 1f;
        m_text.color = new Color(0, 0, 0, 1f);
        m_myrigid.velocity = Vector3.zero; //�ʱ�ȭ �ʼ�(�ӵ���)
        m_myrigid.AddExplosionForce(100, transform.position, 1f);
        StartCoroutine(DestoryCube());
    }

    public void Update()
    {
        if (isChange)
        {
            setPower(AttackButton.damText());
            isChange = false;
        }
        transparency -= Time.deltaTime;
        m_text.color = new Color(0, 0, 0, transparency);
    }

    IEnumerator DestoryCube()
    {
        yield return new WaitForSeconds(0.7f);  //���� ����
        ObjectPoolingManager.instance.InsertQueue(gameObject);
    }

    public void setPower(float power)
    {
        m_text.text = "" + power;
    }
}
