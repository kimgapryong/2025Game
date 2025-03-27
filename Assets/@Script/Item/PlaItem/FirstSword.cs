using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSword : Sword_Base
{
    public override void ChangeAnim(Define.SwordStates state)
    {
        switch (state)
        {
            case Define.SwordStates.Idle:
                animator.Play("Idle");
                break;
            case Define.SwordStates.Attack:
                animator.Play("SwordAnim");
                break;
        }
    }
}
