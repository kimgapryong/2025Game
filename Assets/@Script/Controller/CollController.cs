using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollController : BaseController
{
    public GameObject donkTile;
    public GameObject trigger;

    public override bool Init()
    {
        trigger.GetTriggerEvnet(() => donkTile.SetActive(true));

        if(trigger.activeSelf)
            trigger.SetActive(false);
        return true;
    }
    public void HideDonkTile()
    {
        donkTile.SetActive(false);
    }
}
