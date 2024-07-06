using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseEnemy
{

    private Vector3 target;

    private Vector3 direction;
    
    void Start()
    {
        target = PlayerController.instance.transform.position;

        direction = target - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    public void Attack()
    {

    }

    public void Damaged()
    {

    }
}
