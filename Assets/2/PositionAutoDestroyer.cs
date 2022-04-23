using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    private float destroyWeight = 2.0f;

    private void LateUpdate()
    {
        if (transform.position.y < stageData.LimitMin.y - destroyWeight ||
         transform.position.y > stageData.LimitMax.y + destroyWeight ||
         transform.position.x < stageData.LimitMin.x - destroyWeight ||
         transform.position.x > stageData.LimitMax.x + destroyWeight )
        {
            Destroy( gameObject );
        }
    }


}
// 오브젝트가 일정 범위 바깥으로 나가면 삭제