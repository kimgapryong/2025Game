using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStarter : Base_Stage
{
    public override bool Init()
    {
        base.Init();
        sceneType = Define.SceneType.Lobby;

        //敲饭捞绢 积己
        if(Manager.Player == null)
        {
            GameObject pla = Manager.Resources.Instantaite("Creature/Player");
            PlayerController playerCon = pla.GetOrAddComponent<PlayerController>();
            Manager.Player = playerCon;
            playerCon.weaponHole = pla.transform.Find("WeaponHole");
            playerCon.itemHole = pla.transform.Find("ItemHole");
            DontDestroyOnLoad(pla);
        }
        //墨皋扼 积己
        if(Camera.main == null)
        {
            GameObject cam = Manager.Resources.Instantaite("Main Camera");
            CameraController camCon = cam.GetOrAddComponent<CameraController>();
            DontDestroyOnLoad (cam);
        }
        //牢亥配府 积己
        if(Manager.Ui.Inventory == null)
        {
            InvenCanvas inven = Manager.Ui.CreateUi<InvenCanvas>("InvenCanvas");
            Manager.Ui.Inventory = inven;
            DontDestroyOnLoad(inven.gameObject);
        }
        //惑痢 积己
        if(Manager.Ui.Shop == null)
        {
            ShopCanvas shop = Manager.Ui.CreateUi<ShopCanvas>("ShopCanvas");
            Manager.Ui.Shop = shop;
            DontDestroyOnLoad(shop.gameObject);
        }
        //惑牢 积己
        GameObject shoper = GameObject.Find("Shoper");
        if (shoper == null)
        {
            shoper = Manager.Resources.Instantaite("Creature/Shoper");
            shoper.transform.Find("ClickCanvas").gameObject.GetOrAddComponent<Shop_Click>();
            shoper.transform.position = new Vector3(9f, -8f, 0);
        }

        //啊规 积己
        Manager.Ui.Inventory.ReBack();

        return true;
    }
}
