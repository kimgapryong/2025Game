using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotFragment : UI_Base, IPointerClickHandler
{
    public Item_Base myItem;
    public Define.WeaponType weaponType = Define.WeaponType.None;
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
        itemImage.gameObject.SetActive(false);
        return true;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        //전부다 초기화
        foreach(var slot in Manager.Ui.slotFragments)
        {
            slot.SetBgFalse();
            
            if(slot.myItem != null)
            {
                if (slot.myItem.GetType() == typeof(FlashLight))
                    continue;
                slot.myItem.gameObject.SetActive(false);
            }
        }
            

        slotImage.gameObject.SetActive(true);
        if (myItem == null)
        {
            Manager.Player.plaItemEvent = null;
            return;
        }

        myItem.gameObject.SetActive(true);
        Manager.Player.plaItemEvent = myItem.ItemAbility;
    }

    public void SetBgFalse()
    {
        slotImage.gameObject.SetActive(false);
    }

    //아이템 이미지 설정
    public void SetItemImage(Sprite image)
    {
        itemImage.sprite = image;
        itemImage.gameObject.SetActive(true);
    }
    public void DelItemImage()
    {
        itemImage.gameObject.SetActive(false );
    }
}
