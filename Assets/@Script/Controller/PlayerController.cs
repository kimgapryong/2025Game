using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : CreatureController
{
    private string beforeAnimName;
    public Action clickAction;

    private Rigidbody2D rigid;
    public Transform weaponHole;
    public Transform itemHole;

    public Coroutine breathCor;
    public Coroutine damageCor;
    public Coroutine speedCor;
    public Coroutine hideCor;
    public Coroutine godCor;

    public bool isGod;
    public bool isHide;
    
    public override bool Init()
    {
        base.Init();
        state = Define.States.Move;
        rigid = GetComponent<Rigidbody2D>();
        Manager.Game.MaxBreath = 100;
        Manager.Game.Breath = Manager.Game.MaxBreath;
        return true;
    }
    public override void UpdateMethod()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        dir = new Vector3(x, y, 0);

        if(dir == Vector3.zero)
        {
            state = Define.States.Idle;
            rigid.velocity = Vector3.zero;
        }
            
        else
            state = Define.States.Move;
        
        base.UpdateMethod();

        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            plaItemEvent?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            clickAction?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("Stage5");
        }
    }

    public override void ChangeAnim(Define.States state)
    {
        switch (state)
        {
            case Define.States.Move:
                {
                    if (dir.x != 0)
                        beforeAnimName = "PlayerWalk";
                    else if (dir.y > 0)
                        beforeAnimName = "PlayerBackWalk";
                    else if (dir.y < 0)
                        beforeAnimName = "PlayerFrontWalk";

                    animator.Play(beforeAnimName);
                }
                break;
            case Define.States.Idle:
                {
                    string curName = beforeAnimName == "PlayerWalk" ? "PlayerIdle" :
                                  beforeAnimName == "PlayerBackWalk" ? "PlayerBackIdle" :
                                  beforeAnimName == "PlayerFrontWalk" ? "PlayerFrontIdle" :
                                  "PlayerIdle";

                    animator.Play(curName);
                }
                break;
        }
    }
    protected override void Move()
    {
       rigid.velocity = dir * speed;
    }

    public override void OnDamage(CreatureController attker, float damage)
    {
        MonsterController monster = attker.GetComponent<MonsterController>();
        if(isGod || isCool) 
            return;

        if(monster != null)
        {
            switch (monster.atkType)
            {
                case Define.AtkType.Hp:
                    currentHP -= damage;
                    break;

                case Define.AtkType.Breath:
                    Manager.Game.Breath -= damage;
                    break;
            }
        }
        else
        {
            currentHP -= damage;
        }

        Manager.Game.PlayerSocore--;
      
        if (currentHP <= 0 || Manager.Game.Breath <= 0)
            OnDie();

        StartCoroutine(WaitAtkTime());
    }

}
