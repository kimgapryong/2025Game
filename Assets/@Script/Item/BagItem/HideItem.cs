using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideItem : Item_Base
{
    public float setTime = 5f;
    public override void ItemAbility()
    {
        if (player.godCor != null)
        {
            player.isHide = false;
            player.hideCor = null;
        }

        player.hideCor = StartCoroutine(SetHide());
    }
    private IEnumerator SetHide()
    {
        player.isHide = true;
        yield return new WaitForSeconds(setTime);
        player.isHide = false;
    }
}
