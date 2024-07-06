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

    [Header("����")]
    public float CurrentHealth;

    public float MaxHealth;

    public float moveSpeed;

    public EnemyType enemyType;

    // ��Ҫ�����ԣ�һ��ʼ���
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
            // player��Ѫ������20

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
            // ��Ҽ�һ
            GameManager.Instance.coins += 1;
            // ����
            Destroy(gameObject);
        }
        else
        {
            npcBar.SetHealth(CurrentHealth, MaxHealth);
            // �ܵ��˺���˸
            StartCoroutine(FlashDamage());
        }
    }
    private IEnumerator FlashDamage()
    {
        spriteRenderer.color = Color.white; // ��ɰ�ɫ
        yield return new WaitForSeconds(0.1f); // ���0.1��
        spriteRenderer.color = originalC; // �ָ�ԭ������ɫ
    }
}
