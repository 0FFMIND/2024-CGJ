using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonLoader : MonoBehaviour
{
    private void Awake()
    {
        CursorFollower.Instance.Init();
        GameManager.Instance.Init();
        AudioManager.Instance.PlayBGM(BGM.AllInOne);
    }
}
