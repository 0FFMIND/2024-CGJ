using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyToSpawns;//��������

    public float timeToSpawn;//���ɼ��

    private float spawnCounter;//������

    public Transform minSpawn, maxSpawn;//�߽�ָ�룬��ȡ����λ��

    private Transform target;//playerλ��

    private List<GameObject> spawnedEnemies = new List<GameObject>();//���˶����

    private void Start()
    {
        spawnCounter = timeToSpawn;

        target = PlayerController.instance.transform;
    }

    private void Update()
    {
        spawnCounter -= Time.deltaTime;
        if(spawnCounter < 0)
        {
            spawnCounter = timeToSpawn;
            // ���ѡ��һ����������
            GameObject enemyToSpawn = enemyToSpawns[Random.Range(0, enemyToSpawns.Length)];

            // ���ɵ���
            Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation);
        }
    }


    //ѡ�����ĸ�λ������
    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;
        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if(spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = minSpawn.position.y;
            }

        }

        return spawnPoint;
    }
}
