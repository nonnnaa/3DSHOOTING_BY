using UnityEngine;
public class BYSingleton <T> where T: class, new()
{
    public static readonly T singleton = new T();
    public static T instance
    {
        get
        {
            return singleton;
        }
    }
}
public class BYSingletonMono<T>: MonoBehaviour where T: MonoBehaviour
{
    private static T instance_;
    public static T instance
    {
        get
        {
            if(BYSingletonMono<T>.instance_==null)
            {
                BYSingletonMono<T>.instance_ = (T)FindAnyObjectByType(typeof(T));
                if(BYSingletonMono<T>.instance_==null)
                {
                    GameObject go = new GameObject();
                    go.name = "[@" + typeof(T).Name + "]";
                    BYSingletonMono<T>.instance_ = go.AddComponent<T>();
                }

            }
            return BYSingletonMono<T>.instance_;
        }
    }
    private void Reset()
    {
        gameObject.name = typeof(T).Name;
    }
}