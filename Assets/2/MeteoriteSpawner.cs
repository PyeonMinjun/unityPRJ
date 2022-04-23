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
            // x��ġ�� ���������� ũ�� ���� ������ ���� ��
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);

            //����� ������Ʈ ����
            GameObject alertLineClone = Instantiate(alertLinePrifab, new Vector3(positionX, 0, 0), Quaternion.identity);
            
            //1�ʴ��
            yield return new WaitForSeconds(1.0f);

            //����� ���� ����
            Destroy(alertLineClone);

            //���׿� ������Ʈ ����
            Vector3 meteoritePosition = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0);
            Instantiate(meteoritePrefab, meteoritePosition, Quaternion.identity);

            //���ð� ���� �ݺ�
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(spawnTime);

        }
    }


}