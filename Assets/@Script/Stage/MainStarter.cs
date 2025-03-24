using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStarter : Base_Stage
{
    public override bool Init()
    {
        base.Init();
        sceneType = Define.SceneType.Lobby;

        //플레이어 생성
        if(Manager.Player == null)
        {
            GameObject pla = Manager.Resources.Instantaite("Creature/Player");
            PlayerController playerCon = pla.GetOrAddComponent<PlayerController>();
            Manager.Player = playerCon;
        }
        //카메라 생성
        if(Camera.main == null)
        {
            GameObject pla = Manager.Resources.Instantaite("Main Camera");
            CameraController camCon = pla.GetOrAddComponent<CameraController>();
        }

        return true;
    }
}
