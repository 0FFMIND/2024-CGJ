using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    Vector3 direction;

    public CameraShake cameraShake;
    public CameraShake cameraShake1;
    public CameraShake cameraShake2;
    public CameraShake cameraShake3;

    public Transform gunTrans;

    public float projectileSpeed;
    
    public float fireCD;

    [Header("����ζ�����")]

    public float duaration;

    public float strength;

    [Header("�������")]

    private float fireCounter;

    public static PlayerController instance;

    void Awake()
    {
        instance = this;

        gunTrans = transform.Find("gunPos");

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
        // ������Ч
        AudioManager.Instance.PlaySFX(SoundEffect.Gun_Fire);
        // �ζ���Ļ������
        cameraShake.StartShake(duaration,strength);
        cameraShake1.StartShake(duaration, strength);
        cameraShake2.StartShake(duaration, strength);
        cameraShake3.StartShake(duaration, strength);
        // �����ӵ�Ԥ����
        GameObject obj = ProjectilePool.Instance.GetProjectile();
        obj.transform.position = gunTrans.position;
        Vector3 dir = transform.TransformDirection(new Vector3(0,1,0));
        dir.Normalize();
        obj.GetComponent<Rigidbody2D>().velocity = dir* projectileSpeed;
    }

    //������꣬ƽ��ת��
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
