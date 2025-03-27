using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Click : Click_Base
{

    public override void ClickAction()
    {
        Item_Base item = transform.parent.GetComponent<Item_Base>();
        foreach (var bag in Manager.Ui.bagSlotFragment)
        {
            if(bag.myItem == null)
            {
                bag.myItem = item;
                bag.SetStirng(item.itemData.ItemName, item.itemData.ItemManaterName);
                bag.SetItemImage(item.GetComponent<SpriteRenderer>().sprite);
                bag.itemCount++;
                Manager.Game.Weight += item.itemData.Weight;
                break;
            }
            else if(bag.myItem.itemData.ItemManaterName == item.itemData.ItemManaterName) 
            {
                bag.itemCount++;
                Manager.Game.Weight += item.itemData.Weight;
                break;
            }
        }

        transform.parent.SetParent(Manager.Player.itemHole);
        transform.parent.position = new Vector3(-1000, -1000, 0);
    }
}
