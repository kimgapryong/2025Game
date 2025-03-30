using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankingManager
{
    private const string RANKING = "Ranking";
    public void AddScore(int score)
    {
        List<int> scores = GetRankingList();
        scores.Add(score);  

        scores = scores.OrderByDescending(x => x).Take(10).ToList();

        SaveRanking(scores);
    }

    public List<int> GetRankingList()
    {
        List<int> lists = new List<int>();  
        for(int i =0; i < 10; i++)
        {
            if(PlayerPrefs.HasKey($"{RANKING}_{i}"))
                lists.Add(PlayerPrefs.GetInt($"{RANKING}_{i}"));
        }
        return lists;
    }

    private void SaveRanking(List<int> socres)
    {
        for(int i = 0; i < socres.Count; i++)
            PlayerPrefs.SetInt($"{RANKING}_{i}", socres[i]);

        PlayerPrefs.Save();
    }
}
