using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // ��delegate������һ��û�в���û�з���ֵ�ķ���
    public delegate void GameOverAction();
    // �����¼���ʹ��ί�е����ͣ�����Ϸ������ʱ�򣬸������ж�����
    public static event GameOverAction OnGameOver;
    //
    public float bulletDamage;
    public float attackTime;
    public float defenseLevel;
    public float currentHealth;
    public int coins;
    public void GameOver()
    {
        if(OnGameOver != null)
        {
            OnGameOver();
        }
    }
    // ��ʼ������
    public void Init()
    {
        coins = 0;
        bulletDamage = 20f;
        attackTime = 1.0f;
        defenseLevel = 1.0f;
        currentHealth = 150f;
    }
}
