using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyToSpawns;//怪物类型

    public float timeToSpawn;//生成间隔

    private float spawnCounter;//计数器

    public Transform minSpawn, maxSpawn;//边界指针，获取生成位置

    private Transform target;//player位置

    private List<GameObject> spawnedEnemies = new List<GameObject>();//敌人对象池

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
            // 随机选择一个敌人类型
            GameObject enemyToSpawn = enemyToSpawns[Random.Range(0, enemyToSpawns.Length)];

            // 生成敌人
            Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation);
        }
    }


    //选择在哪个位置生成
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
