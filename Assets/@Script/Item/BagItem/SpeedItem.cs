using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : Item_Base
{
    public float setSpeed = 10f;
    public float setTime = 5f;

    public override void ItemAbility()
    {
        if (player.speedCor != null)
        {
            player.speed -= setSpeed;
            player.speedCor = null;
        }

        player.speedCor = StartCoroutine(SetSpeed());
    }

    private IEnumerator SetSpeed()
    {
        player.damage += setSpeed;
        yield return new WaitForSeconds(setTime);
        player.damage -= setSpeed;
    }
}
