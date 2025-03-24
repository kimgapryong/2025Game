using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CreatureController
{
    public Define.AtkType atkType;
    public PlayerController player;
    private Rigidbody2D rigid;
    public float backFource = 20;
    public override bool Init()
    {
        base.Init();
        player = Manager.Player;
        Debug.Log(speed);
        rigid = GetComponent<Rigidbody2D>();
        return true;
    }
    protected override void Idle()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= data.MoveArange)
            state = Define.States.Move;
    }
    protected override void Move()
    {
        dir = (player.transform.position - transform.position).normalized;

        if (Vector3.Distance(transform.position, player.transform.position) <= data.AtkArange)
            state = Define.States.Attack;
        else if (Vector3.Distance(transform.position, player.transform.position) > data.MoveArange)
            state = Define.States.Idle;
        else
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    protected override void Attack()
    {
        //몬스터 애니메이션 있으면 넣기
        state = Define.States.Idle;
    }

    protected override void ReBack()
    {
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        state = Define.States.Idle;
        rigid.AddForce(-dir * backFource, ForceMode2D.Impulse);
        player.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
            player.OnDamage(this, damage);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
            player.OnDamage(this, damage);
    }

    public override void OnDamage(CreatureController attker, float damage)
    {
        base.OnDamage(attker, damage);
        ReBack();
    }

    public override IEnumerator WaitAtkTime()
    {
        isCool = true;
        yield return new WaitForSeconds(waitCool);
        isCool = false;
        rigid.velocity = Vector3.zero;
    }
}
