using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    Vector3 direction;



    public Transform gunTrans;

    public float projectileSpeed;
    
    public float fireCD;

    private float fireCounter;

    public static PlayerController instance;

    void Awake()
    {
        instance = this;

        gunTrans = transform.Find("gun");

        fireCounter = fireCD;
    }

    void Update()
    {
        LookatMounse();
        fireCounter -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (fireCounter < 0)
            {
                Fire();
                fireCounter = fireCD;
            }
        }
    }


    private void Fire()
    {
        GameObject obj = ProjectilePool.Instance.GetProjectile();
        obj.transform.position = gunTrans.position;
        Vector3 dir = transform.TransformDirection(new Vector3(0,1,0));
        dir.Normalize();
        obj.GetComponent<Rigidbody2D>().velocity = dir* projectileSpeed;
    }

    //面向鼠标，平滑转动
    private void LookatMounse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        direction = worldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.DORotateQuaternion(targetRotation, 0.5f);
    }
}
