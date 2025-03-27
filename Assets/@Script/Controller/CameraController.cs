using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : BaseController
{
    PlayerController player;
    public float speed;

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

    public void StartShake(float force, float time)
    {
        curPos = transform.localPosition;
        StartCoroutine(ShakeCam(force, time));
    }

    IEnumerator ShakeCam(float force, float time)
    {
        float eskape = 0f;
        while (eskape < time)
        {
            float x = Random.Range(-1f, 1f) * force;
            float y = Random.Range(-1f, 1f) * force;

            transform.localPosition = curPos + new Vector3(x, y);
            eskape += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = curPos;
    }
}
