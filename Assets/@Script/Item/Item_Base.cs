using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : MonoBehaviour
{
    public ItemData itemData;
    private bool isFrist;
    public bool isEquair { get; set; }

    private void Start()
    {
        isFrist = true;
    }
    public virtual bool Init()
    {
        if(!isFrist)
        {
            isFrist = true;
            return true;
        }

        return false;
    }
    public abstract void ItemAbility();
}
