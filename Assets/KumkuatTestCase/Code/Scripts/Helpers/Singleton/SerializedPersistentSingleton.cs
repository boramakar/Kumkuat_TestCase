using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializedPersistentSingleton<T> : SerializedSingleton<T> where T : SerializedSingleton<T>
{
    protected override void Awake()
    {
        base.Awake();
        
        DontDestroyOnLoad(gameObject);
    }
}
