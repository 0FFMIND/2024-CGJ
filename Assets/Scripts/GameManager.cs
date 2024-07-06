using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 用delegate声明了一个没有参数没有返回值的方法
    public delegate void GameOverAction();
    // 定义事件，使用委托的类型，当游戏结束的时候，告诉所有订阅者
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
    // 初始化函数
    public void Init()
    {
        coins = 0;
        bulletDamage = 20f;
        attackTime = 1.0f;
        defenseLevel = 1.0f;
        currentHealth = 150f;
    }
}
