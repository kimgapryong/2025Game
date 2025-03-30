using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollController : BaseController
{
    public RandomMonsterController randMonster;
    public GameObject donkTile;
    public GameObject trigger;
    public GameObject boss;

    public override bool Init()
    {
        trigger.GetTriggerEvnet(() => { donkTile.SetActive(true); StartCoroutine(randMonster.RandomSpwan()); trigger.transform.position = new Vector3(-1000, -1000); if (boss != null) Destroy(boss); });

        if(donkTile.activeSelf)
            donkTile.SetActive(false);
        return true;
    }
    public void HideDonkTile()
    {
        donkTile.SetActive(false);
    }
}
