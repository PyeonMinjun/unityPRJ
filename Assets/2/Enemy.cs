using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // 적 공격력

    [SerializeField]
    private int scorePoint = 100;    //적 처치시 흭득 점수
    private PlayerController playerController;  // 플레이어의 score 정보에 접근하기 위해

    [SerializeField]
    private GameObject explosionPrefab; //폭발효과

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딫힌 오브젝트의 태그가 Player이면
        if (collision.CompareTag("Player"))
        {
            // 적 공격력 만큼 플레이어 체력 감소
            collision.GetComponent <PlayerHP>().TakeDamage(damage);

            Ondie();
            
            //적사망
            //Destroy(gameObject);
        }

    }

    public void Ondie()
    {
        playerController.Score += scorePoint;

        //폭발이펙트 생성
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}
