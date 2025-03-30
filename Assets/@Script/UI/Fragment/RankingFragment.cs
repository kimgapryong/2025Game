using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingFragment : UI_Base
{
    enum Texts
    {
        RankTxt,
        SocreTxt,
    }
    public void StrInit(int rank, int score)
    {
        Bind<Text>(typeof(Texts));
        GetText((int)Texts.RankTxt).text = rank.ToString();
        GetText((int)Texts.SocreTxt).text = score.ToString();
    }
}
