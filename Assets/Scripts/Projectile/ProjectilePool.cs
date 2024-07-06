using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    // �򵥵ĵ���д����д��һ�������
    public static ProjectilePool Instance { get; private set; }

    [SerializeField]

    private GameObject projectilePrefab; // �ӵ�Ԥ����

    private Queue<GameObject> projectiles = new Queue<GameObject>();  // Ԥ�������

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
