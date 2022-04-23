using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject alertLinePrifab;
    [SerializeField]
    private GameObject meteoritePrefab;
    [SerializeField]
    private float minSpawnTime = 1.0f;
    [SerializeField]
    private float maxSpawnTime = 4.0f;


    private void Awake()
    {
        StartCoroutine("SpawnMeteorite");
    }

    private IEnumerator SpawnMeteorite()
    {
        while (true)
        {
            // x위치는 스테이지의 크기 범위 내에서 임의 값
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);

            //경고선 오브젝트 생성
            GameObject alertLineClone = Instantiate(alertLinePrifab, new Vector3(positionX, 0, 0), Quaternion.identity);
            
            //1초대기
            yield return new WaitForSeconds(1.0f);

            //경고선 옵젝 삭제
            Destroy(alertLineClone);

            //메테오 오브젝트 생성
            Vector3 meteoritePosition = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0);
            Instantiate(meteoritePrefab, meteoritePosition, Quaternion.identity);

            //대기시간 설정 반복
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(spawnTime);

        }
    }


}
