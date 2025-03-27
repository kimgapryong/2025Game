using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizFragment : UI_Base
{
    public int myId;
    public char MyChar { get; set; } = ' ';
    public QuizCanvas QuizCanva { get; set; }
    enum Texts
    {
        Quiz_Txt,
    }
    enum Images
    {
        QuizFragment,
    }
    public void StrInit(int size, float cell)
    {
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));
        GetImage((int)Images.QuizFragment).GetComponent<RectTransform>().sizeDelta = new Vector2 (cell, cell);
        GetImage((int)Images.QuizFragment).gameObject.BindingBtn(()=> { GetText((int)Texts.Quiz_Txt).gameObject.SetActive(false); MyChar = ' '; QuizCanva.QuizSuc[myId] = ' '; });

        GetText((int)Texts.Quiz_Txt).fontSize = size;
        GetText((int)Texts.Quiz_Txt).gameObject.SetActive(false);
    }

    public void SetText(char txt)
    {
        Debug.Log(txt);
        if(QuizCanva.QuizSuc[myId] != ' ')
            return;

        GetText((int)Texts.Quiz_Txt).gameObject.SetActive(true);
        GetText((int)Texts.Quiz_Txt).text = txt.ToString();

        MyChar = txt;
        QuizCanva.QuizSuc[myId] = txt;

    }

}
