using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagCanvas : UI_Base
{
   enum Objects
    {
        Bag_Content
    }
    enum Buttons
    {
        Close_Btn
    }
    public override bool Init()
    {
        base.Init();
        Bind<GameObject>(typeof(Objects));
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Close_Btn).gameObject.BindingBtn(() => gameObject.SetActive(false));

        for(int i = 0; i < Manager.Game.BagCount; i++)
        {
            Manager.Ui.bagSlotFragment.Add(Manager.Ui.CreateUi<BagSlotFragment>("Fragment/BagSlot_Fragment",GetObject((int)Objects.Bag_Content).transform));
            Debug.Log(Manager.Ui.bagSlotFragment[i]);
        }
        Debug.Log(Manager.Ui.bagSlotFragment.Count);

        gameObject.SetActive(false);
        return true;
    }
}
