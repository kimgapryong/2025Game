using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDonk : DonkCotroller
{

    public void EndEvent()
    {
        DonkState = Define.DonkStastes.Idle;
        coll.enabled = false;
    }

    public override void ChangeAnim(Define.DonkStastes state)
    {
        switch (state)
        {
            case Define.DonkStastes.Idle:
                animator.Play("In_Idle");
                break;
            case Define.DonkStastes.Cool:
                animator.Play("Fire_In_End");
                break;
            case Define.DonkStastes.Attack:
                animator.Play("Fire_In_Loop");
                break;
        }
    }

    protected override void Attack()
    {
        coll.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       PlayerController player = collision.GetComponent<PlayerController>();
        
        if (player != null)
            player.OnDamage(this, fireDamage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
            player.OnDamage(this, fireDamage);
    }
}
