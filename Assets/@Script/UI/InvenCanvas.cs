using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenCanvas : UI_Base
{
    enum Images
    {
        Slot_Bg,
        Hp_Slider,
        Br_Slider,
        Bag_Slider,
        Bag_Click
    }
    public override bool Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        return true;
    }
}
