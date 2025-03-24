using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotFragment : UI_Base, IPointerClickHandler
{
    public Item_Base myItem;

    public Image slotImage;
    public Image itemImage;
    enum Images
    {
        Bg_Slot,
        Sprite_Image
    }

    public override bool Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        slotImage = GetImage((int)Images.Bg_Slot);
        slotImage.gameObject.SetActive(false);

        itemImage = GetImage((int)Images.Sprite_Image);
        return true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //전부다 초기화
        foreach(var slot in Manager.Ui.fragments)
            slot.SetBgFalse();

        slotImage.gameObject.SetActive(true);
        if(myItem != null)
            Manager.Player.plaItemEvent = myItem.ItemAbility;
    }

    public void SetBgFalse()
    {
        slotImage.gameObject.SetActive(false);
    }
}
