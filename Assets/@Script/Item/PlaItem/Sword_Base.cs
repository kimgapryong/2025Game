using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Base : Item_Base
{

    public Collider2D coll;
    public Coroutine _cor;
    public Animator animator;
    private bool canAtk;
    private Define.SwordStates _state;
    public Define.SwordStates State
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
    public override bool Init()
    {
        base.Init();
        coll = GetComponent<Collider2D>();
        animator = transform.Find("Sword").GetComponent<Animator>();
        coll.enabled = false;
        return true;
    }
    public override void ItemAbility()
    {
        if (!canAtk)
        {
            canAtk = true;
            State = Define.SwordStates.Attack;
            Camera.main.GetComponent<CameraController>().StartShake(0.15f, 0.1f);
            coll.enabled = true;
            StartCoroutine(AtkCor());
        }
    }
    protected virtual IEnumerator AtkCor()
    {
        yield return new WaitForSeconds(0.2f);
        State = Define.SwordStates.Idle;
        canAtk = false;
        coll.enabled = false;
    }
    public virtual void ChangeAnim(Define.SwordStates state) { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MonsterController monster = collision.GetComponent<MonsterController>();
        if (monster != null)
        {
            Debug.Log(itemData.Damange);
            monster.OnDamage(player, itemData.Damange);
        }
            
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        MonsterController monster = collision.GetComponent<MonsterController>();
        if (monster != null)
            monster.OnDamage(player, itemData.Damange);
    }
}
