using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preatical : MonoBehaviour
{
    public float damage;
    public CreatureController attker;
    public Vector3 dir;
    public float speed;
    public float rotateZ;
    
    public void SetInfo(CreatureController attker, float damage, Vector3 dir, float speed, float rotateZ)
    {
        this.attker = attker;
        this.dir = dir;
        this.speed = speed;
        this.rotateZ = rotateZ;
        this.damage = damage;
    }
    private void Start()
    {
        gameObject.transform.eulerAngles = new Vector3(0f, 0f, rotateZ);
        Destroy(gameObject, 2);
    }
    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreatureController creature = collision.GetComponent<CreatureController>();
        if (creature != null)
            creature.OnDamage(attker, damage);

        Destroy(gameObject);
    }

}
