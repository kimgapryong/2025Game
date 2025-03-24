using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Define
{
   public enum States
    {
        Idle,
        Attack,
        Move,
    }
    public enum AtkType
    {
        Hp,
        Breath,
    }

    public enum SceneType
    {
        Lobby,
        Stage,
        End,
    }
}
