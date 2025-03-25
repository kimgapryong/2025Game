using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : BaseController
{
    PlayerController player;
    public float speed;

    public float shakeForce;
    public float shakeDuration;
    private Vector3 curPos;
    public override bool Init()
    {
        base.Init();
        player = Manager.Player;
        speed = 25f;
        return true;
    }
    public override void UpdateMethod()
    {
        transform.position =  Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    public IEnumerator ShakeCam()
    {
        float curTime = 0;
        curPos = transform.position;
        while(curTime <= shakeDuration)
        {
            float randX = Random.Range(-1f,1f) * shakeForce;
            float randY = Random.Range(-1f,1f) * shakeForce;

            transform.localPosition = curPos + new Vector3(randX, randY);
            curTime += Time.deltaTime;

            yield return null;
        }
        transform.position = curPos;
    }
}
