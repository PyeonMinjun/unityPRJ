using UnityEngine;


public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }


    //이동 방향설정

    // 플레이어 오브젝트이동
    // 이동 속도 이동방향 인스펙터뷰에서 설정할수있도록 시리얼필드


}