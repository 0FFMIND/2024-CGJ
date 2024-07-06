using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    // ��ͼ������
    public string Name;
    // �������������UI��Ⱦ
    protected Canvas _canvas;   
    // ����������ֵ䣬��Ϊ�ַ�����ֵΪGameObject
    protected Dictionary<string, GameObject> m_cache_gos = new Dictionary<string, GameObject>();
    // �ڶ��󱻴���ʱ���ã��Ȼ�ȡCanvas���
    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }
    // �鷽��Start���ṩ��������д
    protected virtual void OnStart() {}
    // �鷽��Awake���ṩ��������д
    protected virtual void OnAwake() {}
    // ����������ķ����������ַ���res����GameObject����
    public GameObject Find(string res)
    {
        if(m_cache_gos.ContainsKey(res)) return m_cache_gos[res];
        m_cache_gos.Add(res, transform.Find(res).gameObject);
        return m_cache_gos[res];
    }
    // �����ַ��������������ƣ����ص�������Ҫ�������������Ӧ�����
    public T Find<T>(string res) where T : Component
    {
        GameObject obj = Find(res);
        return obj.GetComponent<T>();
    }
}
