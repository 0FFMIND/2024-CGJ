using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType
{
    Cube,
    Tri,
    Circle,
}
public class BaseEnemy : MonoBehaviour
{
    protected Vector3 target;
    protected Vector3 direction;

    [Header("属性")]
    public float CurrentHealth;

    public float MaxHealth;

    public float moveSpeed;

    public EnemyType enemyType;

    // 需要的属性，一开始获得
    private SpriteRenderer spriteRenderer;
    private Color originalC;
    private NpcBar npcBar;

    private void Awake()
    {
        target = PlayerController.instance.transform.position;

        direction = target - transform.position;

        direction.Normalize();

        CurrentHealth = MaxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalC = spriteRenderer.color;
        npcBar = GetComponentInChildren<NpcBar>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            // player的血量减少20

            Destroy(gameObject);
        }
    }
    public void HandleDamage(float damage, BulletStatus status)
    {
        float damageRecv = 0f;
        switch (status)
        {
            case BulletStatus.Red:
                if(enemyType == EnemyType.Cube)
                {
                    damageRecv = damage * 1.5f;
                }
                else
                {
                    damageRecv = damage * 0.7f;
                }
                break;
            case BulletStatus.Green:
                if (enemyType == EnemyType.Tri)
                {
                    damageRecv = damage * 1.5f;
                }
                else
                {
                    damageRecv = damage * 0.7f;
                }
                break;
            case BulletStatus.Blue:
                if (enemyType == EnemyType.Circle)
                {
                    damageRecv = damage * 1.5f;
                }
                else
                {
                    damageRecv = damage * 0.7f;
                }
                break;
        }
        CurrentHealth -= damageRecv;
        
        if (CurrentHealth <= 0)
        {
            // 金币加一
            GameManager.Instance.coins += 1;
            // 死亡
            Destroy(gameObject);
        }
        else
        {
            npcBar.SetHealth(CurrentHealth, MaxHealth);
            // 受到伤害闪烁
            StartCoroutine(FlashDamage());
        }
    }
    private IEnumerator FlashDamage()
    {
        spriteRenderer.color = Color.white; // 变成白色
        yield return new WaitForSeconds(0.1f); // 间隔0.1秒
        spriteRenderer.color = originalC; // 恢复原来的颜色
    }
}
