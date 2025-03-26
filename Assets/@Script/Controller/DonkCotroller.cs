using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkCotroller : CreatureController
{
    private Define.DonkStastes _state;
    public Define.DonkStastes DonkState
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
            ChangeAnim(value);
        }
    }

    public float fireDamage;
    public float waitTime;
    
    public override bool Init()
    {
        //DonkState = Define.DonkStastes.Idle;
        Debug.Log("ag");
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        StartCoroutine(WaitCool());
        return true;
    }

    public virtual void ChangeAnim(Define.DonkStastes state) { }
    public override void UpdateMethod()
    {
      
        switch (DonkState)
        {
            case Define.DonkStastes.Idle:
                Idle();
                break;
            case Define.DonkStastes.Attack:
                Attack();
                break;
         
        }
    }

    protected virtual IEnumerator WaitCool()
    {
        if(waitTime > 0)
        {
            while (true)
            {
                DonkState = Define.DonkStastes.Attack;
                yield return new WaitForSeconds(waitTime);
                DonkState = Define.DonkStastes.Cool;
            }
        }
        else
        {
            DonkState = Define.DonkStastes.Attack;
        }

       
    }

}
