using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizCanvas : UI_Base
{
    private char[] alphabet = new char[26]
    {
        'A','B','C','D','E','F','G','H','I','J','K','M','L','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
    };
    enum Images
    {
        Animal_Image,
        Alphabet_Content,
    }
    enum Objects
    {
        Alphabet_Bg,
    }

    public override bool Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(Objects));

        return true;
    }
}
