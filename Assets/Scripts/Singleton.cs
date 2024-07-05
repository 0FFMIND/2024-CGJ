using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // ˽�б���
    private static T instance;
    // ��������
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                string name = typeof(T).ToString();
                GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/" + name));
                obj.name = name;
                instance = obj.GetComponent<T>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }
}
