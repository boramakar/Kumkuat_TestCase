using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class SerializedSingleton<T> : SerializedMonoBehaviour where T : SerializedMonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            lock(_m)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        var obj = new GameObject(nameof(T));
                        _instance = obj.AddComponent<T>();
                    }
                }  
            }

            return _instance;
        }
    }

    private static object _m = new object();
    
    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this as T;
    }
}
