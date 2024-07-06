using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // ��delegate������һ��û�в���û�з���ֵ�ķ���
    public delegate void GameOverAction();
    // �����¼���ʹ��ί�е����ͣ�����Ϸ������ʱ�򣬸������ж�����
    public static event GameOverAction OnGameOver;

    // ������Ϸ��ʱ����õķ���
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
        
    }
}
