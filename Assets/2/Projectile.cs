using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)

    {
        //발사체에 부딫힌 오브젝트의 태그가 "Enemy" 이면
        if (collision.CompareTag("Enemy"))
        {
            // 부딫힌 오브젝트 사망처리 (적)
            //Destroy(collision.gameObject);

            // 부딫힌 오브젝트 사망처리 (적) 함수 호출로 추가처리
            collision.GetComponent<Enemy>().Ondie();

            //내 오브젝트 삭제 (발사체) -없으면 관통
            Destroy(gameObject);
        }
        
    }
}
