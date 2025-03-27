using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class InvenCanvas : UI_Base
{
    private const int SLOT_COUNT = 6;
    private float plaCurSpee;
    enum Images
    {
        Slot_Bg,
        Hp_Slider,
        Br_Slider,
        Bag_Slider,
        Bag_Click
    }
    enum Texts
    {
        Hp_Txt,
        Br_Txt,
    }
    public override bool Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));

        GetImage((int)Images.Bag_Click).gameObject.BindingBtn(() =>
        {
            if (Manager.Ui.Bag.gameObject.activeSelf)
                Manager.Ui.Bag.gameObject.SetActive(false);
            else
                Manager.Ui.Bag.gameObject.SetActive(true);
        });

        Manager.Player.hpAction = ChangeHp;
        Manager.Game.breathAction = ChangeBr;

        for(int i = 0; i < SLOT_COUNT; i++)
        {
            Manager.Ui.slotFragments.Add(Manager.Ui.CreateUi<SlotFragment>("Fragment/Slot_Fragment",GetImage((int)Images.Slot_Bg).transform));
        }
        return true;
    }

    public void ReBack()
    {
        
        if (Manager.Ui.Bag != null)
        {
            Manager.Ui.bagSlotFragment.Clear();
            Destroy(Manager.Ui.Bag.gameObject);
        }
        BagCanvas bag = Manager.Ui.CreateUi<BagCanvas>("BagCanvas");

        plaCurSpee = Manager.Player.speed;
        Manager.Game.Weight = 0;
        Manager.Ui.Bag = bag;
        DontDestroyOnLoad(bag.gameObject);
    }

    public void ChangeHp(float cur, float max)
    {
        float hp = Mathf.Max(cur, 0);
        GetText((int)Texts.Hp_Txt).text = $"{hp}/{max}";
        GetImage((int)Images.Hp_Slider).fillAmount = hp / max;
    }
    public void ChangeBr(float cur, float max)
    {
        float br = Mathf.Max(cur, 0);
        GetText((int)Texts.Br_Txt).text = $"{br}/{max}";
        GetImage((int)Images.Br_Slider).fillAmount = br / max;
    }
    public void ChangeWeight(float cur,float max)
    {
        float curWeight = cur / max;
        GetImage((int)Images.Bag_Slider).fillAmount = curWeight;
        if(curWeight >= 0.8)
        {
            GetImage((int)Images.Bag_Slider).color = Color.red;
            Manager.Player.speed *= 0.2f;
        }
        else if(curWeight >= 0.75)
        {
            GetImage((int)Images.Bag_Slider).color = new Color(255,165,0);
            Manager.Player.speed *= 0.5f;
        }
        else
        {
            GetImage((int)Images.Bag_Slider).color = Color.yellow;
            Manager.Player.speed = plaCurSpee;
        }

    }
}
