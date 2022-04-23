using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // �� ���ݷ�

    [SerializeField]
    private int scorePoint = 100;    //�� óġ�� ŉ�� ����
    private PlayerController playerController;  // �÷��̾��� score ������ �����ϱ� ����

    [SerializeField]
    private GameObject explosionPrefab; //����ȿ��

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �΋H�� ������Ʈ�� �±װ� Player�̸�
        if (collision.CompareTag("Player"))
        {
            // �� ���ݷ� ��ŭ �÷��̾� ü�� ����
            collision.GetComponent <PlayerHP>().TakeDamage(damage);

            Ondie();
            
            //�����
            //Destroy(gameObject);
        }

    }

    public void Ondie()
    {
        playerController.Score += scorePoint;

        //��������Ʈ ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}
