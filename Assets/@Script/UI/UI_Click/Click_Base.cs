using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Click_Base : UI_Base
{
    enum Images
    {
        ClickImage,
    }
    Image curImage;
    public PlayerController player;

    public override bool Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        curImage = GetImage((int)Images.ClickImage);
        player = Manager.Player;
        return true;
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= 1.8f)
        {
            curImage.gameObject.SetActive(true);
            player.clickAction = ClickAction;
        }
        else
        {
            curImage.gameObject.SetActive(false);
            player.clickAction -= ClickAction;
        }
    }

    public abstract void ClickAction();
}
