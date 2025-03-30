using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;
    public string[] dialogueString;
    public float waitTime;

    private bool isClick;
    private Queue<string> queue;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;
        }
    }

    public virtual void Init()
    {
        dialogueText.gameObject.SetActive(false); 
        queue = new Queue<string>(dialogueString);
        StartCoroutine(StarteDialogue());
    }

    public virtual IEnumerator StarteDialogue()
    {
        Manager.Ranking.AddScore(Manager.Game.PlayerSocore);

        yield return new WaitForSeconds(1.2f);
        dialogueText.gameObject.SetActive(true);

        while (queue.Count > 0)
        {
            string curStr = queue.Dequeue();
            dialogueText.text = "";

       
            foreach (var str in curStr)
            {
                if (isClick) 
                {
                    isClick = false; 
                    dialogueText.text = curStr;
                    break;
                }
                dialogueText.text += str;
                yield return new WaitForSeconds(waitTime);
            }

            while (!Input.GetMouseButtonDown(0))
            {
                yield return null;
            }
            isClick = false; 
        }

        yield return new WaitForSeconds(0.5f); 
        dialogueText.gameObject.SetActive(false); 
    }
}
