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
            if(_item > 0)
                SetItemTxt(value);
        }
    }
    private string itemName = null;
    private string itemManagerName = null;  
   enum Texts
    {
        Item_Txt
    }

    public override bool Init()
    {
        base.Init();
        Bind<Text>(typeof(Texts));
        GetText((int)Texts.Item_Txt).gameObject.SetActive(false);
        return true;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        foreach(var slot in Manager.Ui.bagSlotFragment)
        {
            Debug.Log(slot);
            slot.SetBgFalse();
        }
            

        slotImage.gameObject.SetActive(true);

        if(myItem == null || itemCount <= 0) 
            return;

        Manager.Game.Weight -= myItem.itemData.Weight;
        itemCount--;
        myItem.ItemAbility();

        if(itemCount <= 0)
            BagDicClear();
            //bagµñ¼Å³Ê¸® clear
    }

    public void SetItemTxt(int num)
    {
        if(num <=0)
        {
            num = 0;
            GetText((int)Texts.Item_Txt).gameObject.SetActive(false);
        }
        GetText((int)Texts.Item_Txt).gameObject.SetActive(true);
        GetText((int)Texts.Item_Txt).text = $"{itemName}X{num}";
    }

    public void BagDicClear()
    {
        itemName = null;
        itemManagerName = null ;
        GetText((int)Texts.Item_Txt).gameObject.SetActive(false);
        DelItemImage();

        myItem = null;
    }
    public void SetStirng(string itemName, string itmeManagerName)
    {
        this.itemName = itemName;
        this.itemManagerName = itmeManagerName;
    }
}
