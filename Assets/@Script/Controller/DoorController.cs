using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : BaseController
{
    public int stageId;
    public string chaName;
    public Sprite sprite;
    public int fontSize;
    public float cellSize;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if(player == null) 
            return;

        QuizCanvas canvas = Manager.Ui.CreateUi<QuizCanvas>("QuizCanvas");
        canvas.sprite = sprite;
        canvas.fontSize = fontSize;
        canvas.cellSize = cellSize;
        canvas.chaName = chaName;
        canvas.stageID = stageId;

        canvas.StrInit();

        canvas.gameObject.SetActive(true);
    }
}
