using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stages
{
    public static bool[] Stage = new bool[6]
    {
        true,
        false,
        false,
        false,
        false,
        false,
    };

    public static bool[] trager = new bool[5]
    {
        false,
        false,
        false,
        false,
        false,
    };
}
public class StageManager
{
   public int CurStageID { get; set; }
    
    public bool CheckStage(int curId)
    {
        if(Stages.Stage[curId])
            return true;

        return false;
    }
    public bool CheckTrage(int curId)
    {
        if (Stages.trager[curId])
            return true;

        return false;
    }

    public void OkStage(int curId)
    {
        Stages.Stage[curId] = true;
    }
    public void OkTrager(int curId)
    {
        Stages.trager[curId] = true;
    }
}
