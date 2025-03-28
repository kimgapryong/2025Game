using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisable : MonoBehaviour
{
    public RandomMonsterController randMonsterController;
    private void OnDestroy()
    {
        randMonsterController.maxMonster--;
    }
}
