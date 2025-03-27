using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopFragment : UI_Base
{
    public Define.WeaponType waponType;
    public ItemData[] datas;
    private Image[] upgrades;
    enum Images
    {
        ItemImage,
    }
    enum Texts
    {
        ItemName,
        ItemTxt,
    }
    enum Buttons
    {
        ItemBtn,
    }
    enum Objects
    {
        UpgradeBar,
    }

    public Image itemImage;
    public Text itemName;
    public Text itemBuyTxt;

    private int upgradeCount;

    public  void  StrInit()
    {
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(Objects));

        itemImage = GetImage((int)Images.ItemImage);
        itemName = GetText((int)Texts.ItemName);
        itemBuyTxt = GetText((int)Texts.ItemTxt);

        GetButton((int)Buttons.ItemBtn).gameObject.BindingBtn(BuyItem);

        SetStartData();
        for (int i = 0; i < datas.Length; i++)
        {
            upgrades[i] = Manager.Resources.Instantaite("UI/Anather/UpgradeBarObj",GetObject((int)Objects.UpgradeBar).transform).GetComponent<Image>();
        }

        if(waponType == Define.WeaponType.Bag || waponType == Define.WeaponType.FlashLight || waponType == Define.WeaponType.Sword)
            BuyItem();
    }

    //가장 처음에 설정하는 코드
    private void SetStartData()
    {
        upgrades = new Image[datas.Length];

        itemImage.sprite = datas[0].Image;
        itemName.text = datas[0].ItemName;
        itemBuyTxt.text = datas[0].Money.ToString();

        upgradeCount = -1;
    }

    //아이템 구매
    public void BuyItem()
    {
        if(upgradeCount + 1 >= datas.Length)
        {
            Manager.Ui.AllTxt.GetAllTxt("이미 최대로 강화하였습니다");
            return;
        }

        int nextCont = upgradeCount + 1;
        if(Manager.Game.Money < datas[nextCont].Money)
        {
            Manager.Ui.AllTxt.GetAllTxt("돈이 부족합니다");
            return ;
        }

        upgrades[nextCont].color = Color.green;
       
        Manager.Game.Money -= datas[nextCont].Money;

        Manager.Item.LoadPlayerItem(waponType, datas[nextCont]);

        if (nextCont + 1 >= datas.Length)
            return ;

        itemImage.sprite = datas[nextCont + 1].Image;
        itemName.text = datas[nextCont + 1].ItemName;
        itemBuyTxt.text = datas[nextCont + 1].Money.ToString();

        upgradeCount = nextCont;


    }
}
