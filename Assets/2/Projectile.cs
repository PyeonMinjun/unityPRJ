using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)

    {
        //�߻�ü�� �΋H�� ������Ʈ�� �±װ� "Enemy" �̸�
        if (collision.CompareTag("Enemy"))
        {
            // �΋H�� ������Ʈ ���ó�� (��)
            //Destroy(collision.gameObject);

            // �΋H�� ������Ʈ ���ó�� (��) �Լ� ȣ��� �߰�ó��
            collision.GetComponent<Enemy>().Ondie();

            //�� ������Ʈ ���� (�߻�ü) -������ ����
            Destroy(gameObject);
        }
        
    }
}
