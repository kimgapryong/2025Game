using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathItem : Item_Base
{
    public float setBr = 30;
    public override void ItemAbility()
    {
        if (Manager.Game.Breath >= Manager.Game.MaxBreath)
            return;

        float br = setBr;
        if (Manager.Game.Breath + setBr >= Manager.Game.MaxBreath)
            br = Manager.Game.Breath + setBr - Manager.Game.MaxBreath;

        Manager.Game.Breath += br;
    }
}

