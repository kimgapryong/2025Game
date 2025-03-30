using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingCanvas : UI_Base
{
    enum Objects
    {
        Content,
    }

    public override bool Init()
    {
        base.Init();
        Bind<GameObject>(typeof(Objects));

        List<int> scoreList = Manager.Ranking.GetRankingList();

        if(scoreList.Count <= 0 )
            return false;

        for(int i = 0; i < scoreList.Count; i++)
        {
            RankingFragment rank = Manager.Ui.CreateUi<RankingFragment>("Fragment/RankingFragment",GetObject((int)Objects.Content).transform);
            rank.StrInit(i + 1, scoreList[i]);
        }

        if(gameObject.activeSelf) 
            gameObject.SetActive(false);
        return true;
    }

    public void GoStage()
    {
        SceneManager.LoadScene("StartDialogue");
    }
}
