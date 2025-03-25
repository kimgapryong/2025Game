using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Click : Click_Base
{
    public override void ClickAction()
    {
      Manager.Ui.Shop.gameObject.SetActive(true);
    }
}
