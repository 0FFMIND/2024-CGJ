using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    Dictionary<string, BaseView> m_cache_view = new Dictionary<string, BaseView>();
    // 单例写法
    public static TitleManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    // 单例

    // 加入一个BaseView到单例的Dictionary里面
    public void RegisterView(BaseView view)
    {
        if (!m_cache_view.ContainsKey(view.Name))
        {
            m_cache_view.Add(view.Name, view);
        }
    }
    // 查找对应的名字返回BaseView
    public BaseView Find(string name)
    {
        if (m_cache_view.ContainsKey(name))
        {
            return m_cache_view[name];
        }
        return null;
    }
}
