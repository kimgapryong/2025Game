using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodItem : Item_Base
{
    public float setTime = 5f;
    public override void ItemAbility()
    {
        if (player.godCor != null)
        {
            player.isGod = false;
            player.godCor = null;
        }

        player.godCor = StartCoroutine(SetGod());
    }
    private IEnumerator SetGod()
    {
        player.isGod = true;
        yield return new WaitForSeconds(setTime);
        player.isGod = false;
    }
}
