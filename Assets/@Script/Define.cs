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
    public enum WeaponType
    {
        Sword,
        Bag,
        Breath,
        FlashLight,
        Gun1,
        Gun2,
        Gun3,
        MiniMap,
    }
    public enum Rating
    {
        Common,
        Normal,
        Legend,
    }

    public enum DonkStastes
    {
        Idle,
        Attack,
        Cool
    }
}
