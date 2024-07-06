using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BulletStatus
{
    Red,
    Green,
    Blue,
}
public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float lifetime = 5f;
    public Material RedMaterial;
    public Material GreenMaterial;
    public Material BlueMaterial;
    public BulletStatus status;
    private TrailRenderer trailRenderer;
    private SpriteRenderer spriteRenderer;
    private void OnEnable()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        // �����ӵ���ɫ��״̬
        if (PlayScroller.status == 0)
        {
            // 100%ʱ��Ϊ��ɫ
            status = BulletStatus.Red;
            spriteRenderer.color = Color.red;
        }
        if (PlayScroller.status == 1)
        {
            // 200%��ʱ����ɫ
            status = BulletStatus.Green;
            spriteRenderer.color = Color.green;
        }
        if (PlayScroller.status == 2)
        {
            // 300%��ʱ����ɫ
            status = BulletStatus.Blue;
            spriteRenderer.color = Color.cyan;
        }

        // ����ӵ���β
        if (trailRenderer == null)
        {
            trailRenderer = gameObject.AddComponent<TrailRenderer>();
            trailRenderer.time = 0.2f;
            trailRenderer.startWidth = 0.1f;
            trailRenderer.endWidth = 0.0f;
            // ������β��ɫ
            switch (status)
            {
                case BulletStatus.Red:
                    trailRenderer.material = RedMaterial;
                    break;
                case BulletStatus.Green:
                    trailRenderer.material = GreenMaterial;
                    break;
                case BulletStatus.Blue:
                    trailRenderer.material = BlueMaterial;
                    break;
            }
        }
        // ��5����ӵ��ص������
        Invoke("Deactivate", lifetime);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Deactivate()
    {
        if (trailRenderer != null)
        {
            Destroy(trailRenderer);
            trailRenderer = null; // ��ֹ�������
        }
        ProjectilePool.Instance.ReturnProjectile(this.gameObject);
    }

}
