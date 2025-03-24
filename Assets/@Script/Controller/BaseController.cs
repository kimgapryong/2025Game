using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private bool isFirst;
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        UpdateMethod();
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

    public virtual void UpdateMethod()
    {

    }
}
