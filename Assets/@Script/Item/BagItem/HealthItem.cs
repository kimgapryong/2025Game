using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item_Base
{
    public float setHp = 50;
    public override void ItemAbility()
    {
        if(Manager.Player.currentHP >= Manager.Player.maxHp)
            return;

        float hp = setHp;        
        if(Manager.Player.currentHP + setHp >= Manager.Player.maxHp)
            hp = Manager.Player.currentHP + setHp - Manager.Player.maxHp;

        Manager.Player.currentHP += hp;
    }
}
