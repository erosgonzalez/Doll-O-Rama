using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new GameObject().AddComponent<T>();

            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Other instance of "+ this.GetType().Name+ " has been destoryed");
        }

        instance = this as T;
    }
}
