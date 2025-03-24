using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Create New CreatureData",menuName ="New CreatureData")]
public class CreatureData : ScriptableObject
{
    public float Hp;
    public float Speed;
    public float Damage;

    //∏ÛΩ∫≈Õ
    public float MoveArange;
    public float AtkArange;
}
