using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    private bool isFirst;
    Dictionary<Type, UnityEngine.Object[]> uiDic = new Dictionary<Type, UnityEngine.Object[]>();

    private void Awake()
    {
        Init();
    }

    public virtual bool Init()
    {
        if(!isFirst)
        {
            isFirst = true;
            return true;
        }
        return false;
    }
    public void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = type.GetEnumNames();
        UnityEngine.Object[] objs= new UnityEngine.Object[names.Length];

        for(int i = 0; i < names.Length; i++)
        {
            objs[i] = gameObject.FindChild<T>(names[i]);
        }
        uiDic.Add(typeof(T), objs);
    }

    public T Get<T>(int key) where T : UnityEngine.Object
    {
        UnityEngine.Object[] obj = null;
        if (uiDic.TryGetValue(typeof(T), out obj))
            return obj[key] as T;

        return null;
    }

    protected Image GetImage(int key) { return Get<Image>(key); }
    protected GameObject GetObject(int key) { return Get<GameObject>(key); }
    protected Text GetText(int key) { return Get<Text>(key); }
    protected Button GetButton(int key) { return Get<Button>(key); }
}
