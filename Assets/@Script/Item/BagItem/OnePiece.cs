using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePiece : Item_Base
{
    public override void ItemAbility()
    {
        gameObject.transform.parent = null;
        gameObject.transform.position = player.transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
    }
}
