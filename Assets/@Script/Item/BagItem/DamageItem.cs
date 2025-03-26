using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : Item_Base
{
    public float setDamage = 20f;
    public float setTime = 5f;

    public override void ItemAbility()
    {
        if (player.damageCor != null)
        {
            player.damage -= setDamage;
            player.damageCor = null;
        }

        player.damageCor = StartCoroutine(SetDamage());
    }

    private IEnumerator SetDamage()
    {
        player.damage += setDamage;
        yield return new WaitForSeconds(setTime);
        player.damage -= setDamage;
    }
}
