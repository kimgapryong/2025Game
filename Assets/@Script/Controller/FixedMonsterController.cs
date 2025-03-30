using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMonsterController : MonsterController
{
     
    private Vector3[] squareDir = new Vector3[4]
    {
        Vector3.up,
        Vector3.left,
        Vector3.down,
        Vector3.right,
    };
    private Vector3[] lineDirUD = new Vector3[2]
    {
        Vector3.up,
        Vector3.down,
    };
    private Vector3[] lineDirLR = new Vector3[2]
    {
        Vector3.left,
        Vector3.right,
    };
    private List<Vector3[]> vecLists;
    private Vector3[] myVec;
    private Vector3 nextPos;
    private int curVecInt = 0;

    public Define.FixedDir myDir;
    public float distance;

    public override bool Init()
    {
        base.Init();
        state = Define.States.Move;
        vecLists = new List<Vector3[]>
        {
            squareDir,
            lineDirUD,
            lineDirLR,
        };

        myVec = vecLists[(int)myDir];
        dir = myVec[curVecInt];
        nextPos = transform.position + dir * distance;
        return true;
    }

    protected override void Move()
    {
        if (Vector3.Distance(transform.position, nextPos) <= 0.02f)
        {
            if (curVecInt + 1 >= myVec.Length)
                curVecInt = -1;

            curVecInt++;
            dir = myVec[curVecInt];
            nextPos = transform.position + dir * distance;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed *Time.deltaTime);
        }
    }
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if(player == null)
        {
            if (curVecInt + 1 >= myVec.Length)
                curVecInt = -1;

            curVecInt++;
            dir = myVec[curVecInt];
            nextPos = transform.position + dir * distance;
        }
        else
        {
            player.OnDamage(this, damage);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player == null)
        {
            if (curVecInt + 1 >= myVec.Length)
                curVecInt = -1;

            curVecInt++;
            dir = myVec[curVecInt];
            nextPos = transform.position + dir * distance;
        }
        else
        {
            player.OnDamage(this, damage);
        }
    }

    protected override void ReBack()
    {
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        rigid.AddForce(-dir * backFource, ForceMode2D.Impulse);
        player.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
