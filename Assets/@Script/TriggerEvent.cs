using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public Action triggerAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if(player != null )
        {
            Manager.Ui.AllTxt.GetAllTxt("몬스터 웨이브가 시작됩니다");
            triggerAction?.Invoke();
        }
    }
}
