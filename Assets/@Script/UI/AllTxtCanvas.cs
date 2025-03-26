using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTxtCanvas : UI_Base
{
    public Coroutine _cor;
   enum Texts
    {
        All_Txt,
    }
    public override bool Init()
    {
        base.Init();

        Bind<Text>(typeof(Texts));
        gameObject.SetActive(false);
        return true;
    }
    public void GetAllTxt(string text)
    {
        if (_cor != null)
            StopCoroutine(WatiTxtCool());

        GetText((int)Texts.All_Txt).text = text;
        _cor = StartCoroutine(WatiTxtCool());
    }
    private IEnumerator WatiTxtCool()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
