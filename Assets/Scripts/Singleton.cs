using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 私有变量
    private static T instance;
    // 创建属性
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
