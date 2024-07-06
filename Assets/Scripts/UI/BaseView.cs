using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    // 视图的名称
    public string Name;
    // 画布组件，用于UI渲染
    protected Canvas _canvas;   
    // 缓存物体的字典，键为字符串，值为GameObject
    protected Dictionary<string, GameObject> m_cache_gos = new Dictionary<string, GameObject>();
    // 在对象被创建时调用，先获取Canvas组件
    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }
    // 虚方法Start，提供给子类重写
    protected virtual void OnStart() {}
    // 虚方法Awake，提供给子类重写
    protected virtual void OnAwake() {}
    // 查找子物体的方法，传入字符串res返回GameObject对象
    public GameObject Find(string res)
    {
        if(m_cache_gos.ContainsKey(res)) return m_cache_gos[res];
        m_cache_gos.Add(res, transform.Find(res).gameObject);
        return m_cache_gos[res];
    }
    // 传入字符串代表物体名称，返回的是我需要的这个物体名对应的组件
    public T Find<T>(string res) where T : Component
    {
        GameObject obj = Find(res);
        return obj.GetComponent<T>();
    }
}
