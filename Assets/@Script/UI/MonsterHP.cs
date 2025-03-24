using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : UI_Base
{
    CreatureController monster;
    enum Images
    {
        MonsterHp_Bar,
    }
    public override bool Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        monster = transform.parent.GetComponent<CreatureController>();
        monster.hpAction = ChangeHp;

        return true;
    }

    public void ChangeHp(float cur, float max)
    {
        float sliderValue = Mathf.Max(cur, 0);
        GetImage((int)Images.MonsterHp_Bar).fillAmount = sliderValue / max;
    }


}

