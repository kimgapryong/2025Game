using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStarter : Base_Stage
{
    public override bool Init()
    {
        base.Init();
        sceneType = Define.SceneType.Lobby;

        //플레이어 생성
        if(Manager.Player == null)
        {
            GameObject pla = Manager.Resources.Instantaite("Creature/Player");
            PlayerController playerCon = pla.GetOrAddComponent<PlayerController>();
            Manager.Player = playerCon;
            playerCon.weaponHole = pla.transform.Find("WeaponHole");
            playerCon.itemHole = pla.transform.Find("ItemHole");
            DontDestroyOnLoad(pla);
        }
        Manager.Player.transform.position = StartPos;
        Manager.Player.currentHP = Manager.Player.maxHp;
        Manager.Game.Breath = Manager.Game.MaxBreath;
        //카메라 생성
        if (Camera.main == null)
        {
            GameObject cam = Manager.Resources.Instantaite("Main Camera");
            CameraController camCon = cam.GetOrAddComponent<CameraController>();
            DontDestroyOnLoad (cam);
        }
        //인벤토리 생성
        if(Manager.Ui.Inventory == null)
        {
            InvenCanvas inven = Manager.Ui.CreateUi<InvenCanvas>("InvenCanvas");
            Manager.Ui.Inventory = inven;
            DontDestroyOnLoad(inven.gameObject);
        }
        //상점 생성
        if(Manager.Ui.Shop == null)
        {
            ShopCanvas shop = Manager.Ui.CreateUi<ShopCanvas>("ShopCanvas");
            Manager.Ui.Shop = shop;
            DontDestroyOnLoad(shop.gameObject);
        }
        //상인 생성
        GameObject shoper = GameObject.Find("Shoper");
        if (shoper == null)
        {
            shoper = Manager.Resources.Instantaite("Creature/Shoper");
            shoper.transform.Find("ClickCanvas").gameObject.GetOrAddComponent<Shop_Click>();
            shoper.transform.position = new Vector3(9f, -8f, 0);
        }

        //가방 생성
        Manager.Ui.Inventory.ReBack();

        //미니맵 생성
        if(Manager.Ui.MiniMap == null)
        {
            MiniMapCanvas mini = Manager.Ui.CreateUi<MiniMapCanvas>("MiniMapCanvas");
            Manager.Ui.MiniMap = mini;
            DontDestroyOnLoad(mini.gameObject);
        }

        //맨아래 생성 TextCanvas
        if(Manager.Ui.AllTxt == null)
        {
            AllTxtCanvas allTxt = Manager.Ui.CreateUi<AllTxtCanvas>("AllTxtCanvas");
            Manager.Ui.AllTxt = allTxt;
            DontDestroyOnLoad(allTxt.gameObject);
        }

        return true;
    }
}
