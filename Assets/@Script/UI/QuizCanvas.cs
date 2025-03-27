using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizCanvas : UI_Base
{
    public int stageID;
    public string chaName;
    public int fontSize;
    public float cellSize;
    public Sprite sprite;

    private bool isOk;
    public char[] QuizSuc { get; set; }

    private char[] alphabet = new char[26]
    {
        'A','B','C','D','E','F','G','H','I','J','K','M','L','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
    };

    public List<QuizFragment> fragments = new List<QuizFragment>();
    enum Images
    {
        Animal_Image,
        Alphabet_Content,
    }
    enum Objects
    {
        Alphabet_Bg,
    }
    enum Buttons
    {
        CloseBtn
    }

    public void StrInit()
    {
        
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(Objects));
        Bind<Button>(typeof(Buttons));
        QuizSuc = new char[chaName.Length];
        for(int i = 0; i < QuizSuc.Length; i++)
        {
            QuizSuc[i] = ' ';
        }

        GetImage((int)Images.Animal_Image).sprite = sprite;
        GetButton((int)Buttons.CloseBtn).gameObject.BindingBtn(() => gameObject.SetActive(false));

        for (int i = 0; i < chaName.Length; i++)
        {
            QuizFragment quiz = Manager.Ui.CreateUi<QuizFragment>("Fragment/QuizFragment", GetImage((int)Images.Alphabet_Content).transform);
            quiz.QuizCanva = this;
            quiz.myId = i;
            fragments.Add(quiz);
            quiz.StrInit(fontSize, cellSize);
        }

        for (int i = 0; i < alphabet.Length; i++)
        {
            AlphabetFragment alpha = Manager.Ui.CreateUi<AlphabetFragment>("Fragment/AlphabetFragment", GetObject((int)Objects.Alphabet_Bg).transform);
            alpha.QuizCanva = this;
            alpha.strInit(alphabet[i]);
        }
    }

    private void Update()
    {
        if (chaName == string.Concat(QuizSuc) && !isOk)
        {
            isOk = true;
            Manager.Ui.AllTxt.GetAllTxt("∆€¡Ò¿Ã «Æ∑»Ω¿¥œ¥Ÿ");
            Manager.Stage.OkStage(stageID);
            foreach(var door in GameObject.FindGameObjectsWithTag("Door"))
            {
                Destroy(door);
            }
            Destroy(gameObject);
        }
    }
}

