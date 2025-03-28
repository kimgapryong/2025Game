using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMonsterController : BaseController
{

    public GameObject[] monsters;

    public float spwanCount;

    public Vector2 minVec;
    public Vector2 maxVec;

    private int maxCount = 24;
    private int curCount;

    public int maxMonster;
    private int curRoot = 0;
    private int curLoop = 3;
    private int loop = 0;   
    private int curRo;

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
            for(int i =0; i < curRo; i++)
            {
                GameObject clone = Instantiate(randObj, newVec, Quaternion.identity);
                clone.GetOnDisable(this);
            }

            yield return new WaitForSeconds(spwanCount);
        }
    }
}
