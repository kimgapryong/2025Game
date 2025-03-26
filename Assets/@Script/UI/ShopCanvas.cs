using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemDatas
{
    public Define.WeaponType weaponType;
    public ItemData[] itemDataArange;
}
public class ShopCanvas : UI_Base
{
    public ItemDatas[] itemDatas;
    enum Objects
    {
        Content,
    }
    enum Texts
    {
        MoneyTxt
    }
    enum Buttons
    {
        CloseBtn,
    }

    public override bool Init()
    {
        base.Init();
        Bind<GameObject>(typeof(Objects));
        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.CloseBtn).gameObject.BindingBtn(() => gameObject.SetActive(false));
        Manager.Game.moneyAction = ChangeMoney;

        //»ý¼º
        for(int i = 0; i < itemDatas.Length; i++)
        {
            ShopFragment shop = Manager.Ui.CreateUi<ShopFragment>("Fragment/ShopFragment",GetObject((int)Objects.Content).transform);
            shop.datas = itemDatas[i].itemDataArange;
            shop.waponType = itemDatas[i].weaponType;
            shop.StrInit();
        }

        gameObject.SetActive(false);
        return true;
    }

    public void ChangeMoney(float money)
    {
        GetText((int)Texts.MoneyTxt).text = ((int)money).ToString();
    }
}
