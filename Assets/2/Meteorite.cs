using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField]
    private int damage = 5; //운석 공격력

    [SerializeField]
    private GameObject explosionPrefab;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //운석 오브젝트 태그 Player이면
        if (collision.CompareTag("Player"))
        {
            //운석 공격력만큼 플레이어 체력 감소
            collision.GetComponent<PlayerHP>().TakeDamage(damage);

            //폭발 이팩트 생성
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            //운석사망
            Destroy(gameObject);
        }
    }
}
