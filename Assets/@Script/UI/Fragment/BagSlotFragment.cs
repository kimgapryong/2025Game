using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagSlotFragment : SlotFragment
{
    private int _item;
    public int itemCount
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;
            SetItemTxt(value);
        }
    }
    public string itemName = null;
   enum Texts
    {
        Item_Txt
    }

    public override bool Init()
    {
        base.Init();
        Bind<Text>(typeof(Texts));
        return true;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        foreach(var slot in Manager.Ui.bagSlotFragment)
            slot.SetBgFalse();

        slotImage.gameObject.SetActive(true);

        if(myItem == null || itemCount <= 0) 
            return;

        itemCount--;
        myItem.ItemAbility();
    }

    public void SetItemTxt(int num)
    {
        if(num <=0)
        {
            num = 0;
            GetText((int)Texts.Item_Txt).gameObject.SetActive(false);
        }
        GetText((int)Texts.Item_Txt).text = $"{itemName}X{num}";
    }
}
