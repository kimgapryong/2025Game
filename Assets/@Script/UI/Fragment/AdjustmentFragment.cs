using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustmentFragment : UI_Base
{
    enum Images
    {
        ItemImage,
    }
    enum Texts
    {
        ItemName,
        ItemValue
    }
    public override bool Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));
        return true;

    }
    public void SetImage(Sprite sprite, string name, int count, float value)
    {
        GetImage((int)Images.ItemImage).sprite = sprite;
        GetText((int)Texts.ItemName).text = $"{name}X{count}";
        StartCoroutine(SetValue(value));
    }
    private IEnumerator SetValue(float value)
    {
        for(int i = 0; i <= (int)value; i++)
        {
            GetText((int)Texts.ItemValue).text = i.ToString();
            yield return null;
        }
    }
}
