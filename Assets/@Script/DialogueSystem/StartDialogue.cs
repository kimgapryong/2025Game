using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartDialogue : DialogueSystem
{
    public Button startBtn;

    public override void Init()
    {
        base.Init();
        startBtn.gameObject.BindingBtn(() => SceneManager.LoadScene("Stage0"));
        startBtn.gameObject.SetActive(false);
    }

    public override IEnumerator StarteDialogue()
    {
        yield return base.StarteDialogue();

        yield return new WaitForSeconds(2f);
        dialogueText.gameObject.SetActive(false);
        startBtn.gameObject.SetActive(true);
    }
}
