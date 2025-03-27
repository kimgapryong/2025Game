using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlphabetFragment : UI_Base
{
    public char myAlphabet;
    public QuizCanvas QuizCanva { get; set; }
    enum Texts
    {
        Alphabet_Txt,
    }
    public void strInit(char alpha)
    {
        Bind<Text>(typeof(Texts));
        myAlphabet = alpha;
        GetText((int)Texts.Alphabet_Txt).text = alpha.ToString();
        GetText((int)Texts.Alphabet_Txt).gameObject.BindingBtn(SetChar);
    }

    public void SetChar()
    {
        foreach(var quiz in QuizCanva.fragments)
        {
            if(quiz.MyChar != ' ')
                continue;

            quiz.SetText(myAlphabet);
            break;
        }
    }
}
