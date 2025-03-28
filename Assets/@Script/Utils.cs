using System;
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

    public static void BindingBtn(this GameObject obj, Action action)
    {
        ButtonEvent btnEvn = obj.AddComponent<ButtonEvent>();
        btnEvn.btnAction = action;
    }

    public static void GetPreatical(this GameObject obj, CreatureController attker, float damage, float speed, Vector3 dir, Transform parent = null)
    {
        Preatical pre = obj.AddComponent<Preatical>();
        float rotate = 0;
        if(parent != null)
            rotate = parent.eulerAngles.z - 90f;
        
        pre.SetInfo(attker, damage, dir, speed, rotate);
    }
    public static void GetOnDisable(this GameObject obj, RandomMonsterController randMonsterCon)
    {
        OnDisable onDis = obj.AddComponent<OnDisable>();
        onDis.randMonsterController = randMonsterCon;
    }
}
