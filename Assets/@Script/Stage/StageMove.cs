using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMove : MonoBehaviour
{
    public int nextStageId;
    public Transform trans;

    private void Update()
    {
        if(Vector3.Distance(Manager.Player.transform.position, trans.position) <= 2f)
        {
            if(nextStageId <= 6)
            {
                //캐릭터 죽이기
            }
            SceneManager.LoadScene($"Stage{nextStageId}");
        }
    }
}
