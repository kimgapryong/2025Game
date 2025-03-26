using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : Item_Base
{
    private GameObject onePiece;

    public override void ItemAbility()
    {
        onePiece = GameObject.FindGameObjectWithTag("OnePiece");
        if (Manager.Player.weaponHole.Find("MiniMap"))
        {
            Manager.Ui.AllTxt.GetAllTxt("지도 상에 보물의 위치가 표시됩니다");
            onePiece.transform.Find("OnePeiceSprite").gameObject.SetActive(true);
        }
        else
        {
            Manager.Ui.AllTxt.GetAllTxt("지도을 구입하고 사용해야 진가가 드러날것 같아");
        }
    }
}
