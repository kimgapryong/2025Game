using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieDialogue : DialogueSystem
{
    public Text godTxt;
    public Button button;

    public override void Init()
    {
        godTxt.gameObject.SetActive(false);

        button.gameObject.BindingBtn(() => { Destroy(Manager.Instance.gameObject); SceneManager.LoadScene("StartScene"); });
        button.gameObject.SetActive(false);

        base.Init();
    }
    public override IEnumerator StarteDialogue()
    {
        yield return base.StarteDialogue();

        yield return new WaitForSeconds(1.2f);
        dialogueText.color = Color.red;
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = "YOU DIE";
        yield return new WaitForSeconds(1.2f);
        dialogueText.color = Color.black;
        dialogueText.gameObject.SetActive(true);
        godTxt.gameObject.SetActive(true) ;

        for(int i = 0; i < Manager.Game.PlayerSocore; i++)
        {
            dialogueText.text = i.ToString();
            yield return null;
        }
        button.gameObject.SetActive(true);
    }
}
