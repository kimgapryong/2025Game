using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager
{
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        T obj = Resources.Load($"Prefab/{path}") as T;
        return obj;
    } 
    public AudioClip LoadAudio(string path)
    {
        AudioClip audioClip = Load<AudioClip>($"Sounds/{path}");
        return audioClip;
    }
    public GameObject Instantaite(string path, Transform trans = null)
    {
        GameObject obj = Load<GameObject>(path);
        GameObject clone = Object.Instantiate(obj);
        clone.transform.parent = trans;
        clone.name = obj.name;

        return clone;
    }
}
