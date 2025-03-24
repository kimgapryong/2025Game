using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Item_Base
{
    public override void ItemAbility()
    {
        if (isEquair)
        {
            isEquair = false;
            gameObject.SetActive(false);
        }
        else
        {
            isEquair = true;
            gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if(Manager.Player.dir == Vector3.zero)
            return;

        float rotate = Mathf.Atan2(-Manager.Player.dir.x, Manager.Player.dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotate);
    }
}
