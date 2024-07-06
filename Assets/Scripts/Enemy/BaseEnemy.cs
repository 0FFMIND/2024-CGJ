using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private Vector3 target;
    private Vector3 direction;

    [Header(" Ù–‘")]
    public float CurrentHealth;
    private float MaxHealth { get; set; }

    public float damage;

    public float moveSpeed;



    private void Awake()
    {
        target = PlayerController.instance.transform.position;

        direction = target - transform.position;
        direction.Normalize();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }


    public virtual void Damaged()
    {

    }

    public virtual void Attack()
    {

    }
}
