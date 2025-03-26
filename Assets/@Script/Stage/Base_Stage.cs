using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Stage : MonoBehaviour
{
    public int myStageID;
    public Define.SceneType sceneType;
    public Vector3 StartPos;
    public bool isFirst;
    public void Start()
    {
        Init();
    }

    public virtual bool Init()
    {
        if(!isFirst)
        {
            isFirst = true;
            Manager.Stage.CurStageID = myStageID;
            return true;
        }

        return false;
    }
}
