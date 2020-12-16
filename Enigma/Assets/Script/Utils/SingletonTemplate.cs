using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance = default(T);
    public static T Instance => instance;

    void Awake()
    {
        if(instance && instance != this)
        {
            Destroy(this);
        }
        instance = this as T;
    }


}
