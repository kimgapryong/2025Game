using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : Item_Base
{
    public override void ItemAbility()
    {
        if (Manager.Ui.MiniMap.gameObject.activeSelf)
        {
            Manager.Ui.MiniMap.gameObject.SetActive(false);
        }
        else
        {
            Manager.Ui.MiniMap.gameObject.SetActive(true);
        }
    }

   
}
