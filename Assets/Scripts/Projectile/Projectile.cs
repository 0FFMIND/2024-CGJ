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
        // 更改子弹颜色和状态
        if (PlayScroller.status == 0)
        {
            // 100%时间为红色
            status = BulletStatus.Red;
            spriteRenderer.color = Color.red;
        }
        if (PlayScroller.status == 1)
        {
            // 200%的时间绿色
            status = BulletStatus.Green;
            spriteRenderer.color = Color.green;
        }
        if (PlayScroller.status == 2)
        {
            // 300%的时间蓝色
            status = BulletStatus.Blue;
            spriteRenderer.color = Color.cyan;
        }

        // 添加子弹拖尾
        if (trailRenderer == null)
        {
            trailRenderer = gameObject.AddComponent<TrailRenderer>();
            trailRenderer.time = 0.2f;
            trailRenderer.startWidth = 0.1f;
            trailRenderer.endWidth = 0.0f;
            // 设置拖尾颜色
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
        // 在5秒后子弹回到对象池
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
            trailRenderer = null; // 防止多次销毁
        }
        ProjectilePool.Instance.ReturnProjectile(this.gameObject);
    }

}
