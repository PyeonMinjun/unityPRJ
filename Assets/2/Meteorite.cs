using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField]
    private int damage = 5; //� ���ݷ�

    [SerializeField]
    private GameObject explosionPrefab;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //� ������Ʈ �±� Player�̸�
        if (collision.CompareTag("Player"))
        {
            //� ���ݷ¸�ŭ �÷��̾� ü�� ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);

            //���� ����Ʈ ����
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            //����
            Destroy(gameObject);
        }
    }
}
