using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : Base_Stage
{
    public float setSpeed;
    public float setTime;
    public GameObject onePiece;
    public override bool Init()
    {
        base.Init();
        sceneType = Define.SceneType.Stage;
        onePiece = GameObject.Find("OnePiece");
        Manager.Player.transform.position = StartPos;

        if (Manager.Stage.CheckStage(myStageID))
            foreach(var door in GameObject.FindGameObjectsWithTag("Door"))
                Destroy(door);

        if(Manager.Stage.CheckTrage(myStageID))
            Destroy(onePiece);

        if(Manager.Player.breathCor != null)
        {
            StopCoroutine(Manager.Player.breathCor);
            Manager.Player.breathCor = null;
        }

        Manager.Player.breathCor = StartCoroutine(SetBreath());
        return true;
    }

    private IEnumerator SetBreath()
    {
        while(true)
        {
            yield return new WaitForSeconds(setTime);  
            Manager.Game.Breath -= setSpeed;
        }
    }
}

