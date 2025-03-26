using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDonk : DonkCotroller
{
    public float touchDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
            player.OnDamage(this, touchDamage);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
            player.OnDamage(this, touchDamage);
    }
    
}
