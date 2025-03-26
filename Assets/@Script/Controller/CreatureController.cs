using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : BaseController
{

    public Action<float, float> hpAction;

    //플레이어 아이템 and 무기 이벤트
    public Action plaItemEvent;

    public CreatureData data;

    private Define.States _state;
    public Define.States state
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

    private Vector3 _dir;
    public Vector3 dir
    {
        get
        {
            return _dir;
        }
        set
        {
            _dir  = value.normalized;
        }
    }
    public Animator animator;
    public Collider2D coll;

    protected float waitCool = 0.5f;
    protected bool isCool;

    public float maxHp;

    private float _curHp;
    public float currentHP
    {
        get
        {
            return _curHp;
        }
        set
        {
            _curHp = value;
            hpAction?.Invoke(value, maxHp);
        }
    }

    public float speed;
    public float damage;

    public override bool Init()
    {
        base.Init();

        maxHp = data.Hp;
        currentHP = maxHp;
        speed = data.Speed;
        damage = data.Damage;

        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        return true;
    }

    public virtual void ChangeAnim(Define.States state) { }

    public override void UpdateMethod()
    {
        transform.eulerAngles = dir.x > 0 ? Vector3.zero : dir.x < 0 ? new Vector3(0, -180, 0) : transform.eulerAngles;
        switch (state)
        {
            case Define.States.Idle:
                Idle();
                break;
            case Define.States.Attack:
                Attack();
                break;
            case Define.States.Move:
                Move();
                break;
        }
    }

    protected virtual void Idle() { }
    protected virtual void Attack() { }
    protected virtual void Move() { }

    public virtual void OnDamage(CreatureController attker, float damage)
    {
        if(isCool)
            return;

        currentHP -= damage;

        if(currentHP<= 0)
            OnDie();

        StartCoroutine(WaitAtkTime());
    }
    protected virtual void OnDie()
    {
        Debug.Log("나는 죽었다");
    }

    //공격 받을때 나타나는 현상
    protected virtual void ReBack() { }

    public virtual IEnumerator WaitAtkTime()
    {
        isCool = true;
        yield return new WaitForSeconds(waitCool);
        isCool = false;
    }

}
