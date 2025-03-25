using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : CreatureController
{
    private string beforeAnimName;
    public Action clickAction;

    public Transform weaponHole;
    public Transform itemHole;
    public override bool Init()
    {
        base.Init();
        state = Define.States.Move;
        return true;
    }
    public override void UpdateMethod()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        dir = new Vector3(x, y, 0);

        if(dir == Vector3.zero )
            state = Define.States.Idle;
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
        transform.position += dir * speed * Time.deltaTime;
    }


}
