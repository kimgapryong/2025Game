using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDonk : DonkCotroller
{
    public GameObject arrow;
    public Transform target;
    private Vector3 myDir;

    public override bool Init()
    {
        myDir = target.position - transform.position;
        base.Init();
        return true;
    }

    protected override IEnumerator WaitCool()
    {
        while (true)
        {
            GameObject obj = Instantiate(arrow);
            obj.transform.position = transform.position;
            obj.name = arrow.name;

            obj.GetPreatical(this, fireDamage, speed, myDir, transform);
            yield return new WaitForSeconds(waitTime);
        }
    }

}
