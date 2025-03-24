using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Utils
{
    public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
    {
        T com = obj.GetComponent<T>();
        if(com == null)
            com = obj.AddComponent<T>();
        return com;
    }

    public static T FindChild<T>(this GameObject obj, string name) where T : UnityEngine.Object
    {
        if(typeof(T) == typeof(GameObject))
        {
            foreach(var trans in obj.GetComponentsInChildren<Transform>())
            {
                if(trans.name == name)
                    return trans.gameObject as T;
            }
        }

        foreach(var com in obj.GetComponentsInChildren<T>())
        {
            if(com.name == name)
                return com;
        }

        return null;
    }
}
