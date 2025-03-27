using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : MonoBehaviour
{
    public ItemData itemData;
    private bool isFrist;
    public bool isEquair { get; set; }
    public PlayerController player;

    private void Start()
    {
        Init();
    }
    public virtual bool Init()
    {
        if(!isFrist)
        {
            isFrist = true;
            player = Manager.Player;
            return true;
        }

        return false;
    }
    public abstract void ItemAbility();
}
