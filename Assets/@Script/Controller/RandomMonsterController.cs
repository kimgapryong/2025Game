using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMonsterController : BaseController
{
    public CollController collController;
    public GameObject[] monsters;
    private Vector3[] vecs;
    private Vector3[] posVecs = new Vector3[8]
    {
        Vector3.up,
        Vector3.left,
        Vector3.down,
        Vector3.right,
        new Vector3(-1,1),
        new Vector3(-1,-1),
        new Vector3(1,-1),
        new Vector3(1,1),
    };
    public float spwanCount;

    public Vector3 minVec;
    public Vector3 maxVec;

    public int maxCount = 24;
    private int curCount;

    public int maxMonster;
    private int curRoot = 0;
    private int curLoop = 3;
    private int loop = 0;   
    private int curRo;

    public override bool Init()
    {
        vecs = new Vector3[4]
    {
        minVec,
        minVec + Vector3.up * 12f,
        minVec + Vector3.up* 12f,
        maxVec
    };
        return true;
    }
   
    public IEnumerator RandomSpwan()
    {
        while(maxMonster > 0)
        {
            if (curCount >= maxCount)
                continue;

            if (loop >= curLoop || curRoot <= 0)
            {
                curRoot += 1;
                curRo = curRoot * curRoot;

                if (curRo > maxCount)
                    curRo = maxCount;
                loop = 0;
            }

            loop++;
            int randValue = Random.Range(0, monsters.Length);
            GameObject randObj = monsters[randValue];

            float randPosX = Random.Range(minVec.x, maxVec.x);
            float randPosY = Random.Range(minVec.y, maxVec.y);

            Vector3 newVec = new Vector3(randPosX, randPosY);

            if(randObj.GetComponent<FixedMonsterController>() != null)
            {
                for(int j =0; j < 4; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject clone = Instantiate(randObj, vecs[j], Quaternion.identity);
                        clone.GetOnDisable(this);
                        curCount++;
                    }
                }
              
            }
            else
            {
                int curPos = 0;
                for (int i = 0; i < curRo; i++)
                {
                    if (curPos >= posVecs.Length)
                        curPos = 0;

                    GameObject clone = Instantiate(randObj, newVec + posVecs[curPos], Quaternion.identity);
                    clone.GetOnDisable(this);
                    curCount++;
                    curPos++;
                }
            }
           

            yield return new WaitForSeconds(spwanCount);
        }
        Manager.Ui.AllTxt.GetAllTxt("웨이브을 클리어하셨습니다");
        collController.HideDonkTile();
    }
}
