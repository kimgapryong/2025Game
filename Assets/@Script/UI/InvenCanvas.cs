using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenCanvas : UI_Base
{
    private const int SLOT_COUNT = 6;
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

        GetImage((int)Images.Bag_Click).gameObject.BindingBtn(() =>
        {
            if (Manager.Ui.Bag.gameObject.activeSelf)
                Manager.Ui.Bag.gameObject.SetActive(false);
            else
                Manager.Ui.Bag.gameObject.SetActive(true);
        });

        for(int i = 0; i < SLOT_COUNT; i++)
        {
            Manager.Ui.slotFragments.Add(Manager.Ui.CreateUi<SlotFragment>("Fragment/Slot_Fragment",GetImage((int)Images.Slot_Bg).transform));
        }
        return true;
    }

    public void ReBack()
    {
        if (Manager.Ui.Bag != null)
            Destroy(Manager.Ui.Bag.gameObject);
        BagCanvas bag = Manager.Ui.CreateUi<BagCanvas>("BagCanvas");
        Manager.Ui.Bag = bag;
        DontDestroyOnLoad(bag.gameObject);
    }
}
