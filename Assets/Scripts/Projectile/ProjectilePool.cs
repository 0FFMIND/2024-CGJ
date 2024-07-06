using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    // 简单的单例写法，写了一个对象池
    public static ProjectilePool Instance { get; private set; }

    [SerializeField]

    private GameObject projectilePrefab; // 子弹预制体

    private Queue<GameObject> projectiles = new Queue<GameObject>();  // 预制体队列

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetProjectile()
    {
        if (projectiles.Count > 0)
        {
            GameObject projectile = projectiles.Dequeue();
            projectile.SetActive(true);
            return projectile;
        }
        else
        {
            return Instantiate(projectilePrefab);
        }

    }

    public void ReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
        projectiles.Enqueue(projectile);
    }
}
