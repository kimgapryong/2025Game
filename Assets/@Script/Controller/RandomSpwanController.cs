using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ItemRating
{
    public Define.Rating itemRating;
    public GameObject[] items;
}
public class RandomSpwanController : BaseController
{
    public ItemRating[] itemRatings;

    public void SpwanRandomItem(Vector3 pos)
    {

        int randValue = Random.Range(0, 101);
        int randSpwan = 0;

        if(randValue  <= 50)
            return;
        else if(randValue <= 80) 
            randSpwan = 0;
        else if(randValue <= 98)
            randSpwan = 1;
        else if(randValue <= 100)
            randSpwan = 2;

        GameObject obj = Instantiate(itemRatings[randSpwan].items[Random.Range(0, itemRatings[randSpwan].items.Length - 1)], pos, Quaternion.identity);
        Item_Click itemClick = Manager.Ui.CreateUi<Item_Click>("ClickCanvas",obj.transform);

        switch (itemRatings[randSpwan].itemRating)
        {
            case Define.Rating.Common:
                itemClick.clickImage.color = Color.white;
                break;

            case Define.Rating.Normal:
                itemClick.clickImage.color = Color.yellow;
                break;

            case Define.Rating.Legend:
                itemClick.clickImage.color = Color.red;
                break;
        }

    }
}
