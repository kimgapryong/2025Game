using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemManager 
{
    public void LoadPlayerItem(string path, Transform trans)
    {
        GameObject item = Manager.Resources.Instantaite($"Item/PlaItem/{path}", trans);
        item.transform.localPosition = Vector3.zero;

        Item_Base itemCom = item.GetComponent<Item_Base>();
        
        foreach(var slot in Manager.Ui.slotFragments)
        {
            if(slot.myItem != null)
                continue;

            slot.myItem = itemCom;
            slot.SetItemImage(itemCom.itemData.Image);
            return;
        }
    }

    public void LoadPlayerItem(Define.WeaponType type, ItemData data)
    {
        if(type == Define.WeaponType.Bag)
        {
            Manager.Game.BagCount = (int)data.Damange;
            Manager.Game.MaxWeight = data.Weight;
            Manager.Ui.Inventory.ReBack();
        }
        else if(type == Define.WeaponType.Breath)
        {
            Manager.Game.MaxBreath += data.Damange;
        }
        else
        {
            string itemName = data.ItemManaterName;
            LoadPlayerItem(itemName, Manager.Player.weaponHole);
        }
    }

}
