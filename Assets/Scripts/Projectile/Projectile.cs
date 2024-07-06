using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float lifetime = 5f;
    private void OnEnable()
    {
        Invoke("Deactivate", lifetime);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }


    private void Deactivate()
    {
        ProjectilePool.Instance.ReturnProjectile(this.gameObject);
    }

}
