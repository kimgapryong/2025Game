using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlphabetFragment : UI_Base
{
    enum Texts
    {
        Alphabet_Txt,
    }
    public override bool Init()
    {
        base.Init();
        Bind<Text>(typeof(Texts));
        return true;
    }
}
