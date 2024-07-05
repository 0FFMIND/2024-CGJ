using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    public String Name;

    protected Canvas _canvas;

    protected Dictionary<string, GameObject> m_cache_gos = new Dictionary<string, GameObject>();//»º´æÎïÌåµÄ×Öµä

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }

    protected virtual void OnStart()
    {
        
    }

    protected virtual void OnAwake()
    {
        
    }


    public GameObject Find(string res)
    {
        if(m_cache_gos.ContainsKey(res)) return m_cache_gos[res];
        m_cache_gos.Add(res, transform.Find(res).gameObject);
        return m_cache_gos[res];
    }

    public T Find<T>(string res) where T : Component
    {
        GameObject obj = Find(res);
        return obj.GetComponent<T>();
    }
}
