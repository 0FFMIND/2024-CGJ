using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    Dictionary<string, BaseView> m_cache_view = new Dictionary<string, BaseView>();
    // ����д��
    public static TitleManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    // ����

    // ����һ��BaseView��������Dictionary����
    public void RegisterView(BaseView view)
    {
        if (!m_cache_view.ContainsKey(view.Name))
        {
            m_cache_view.Add(view.Name, view);
        }
    }
    // ���Ҷ�Ӧ�����ַ���BaseView
    public BaseView Find(string name)
    {
        if (m_cache_view.ContainsKey(name))
        {
            return m_cache_view[name];
        }
        return null;
    }
}
