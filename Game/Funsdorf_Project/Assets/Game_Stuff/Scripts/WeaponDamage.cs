using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {

    public float damage = 1;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == MyConst.Enemy)
        {
            other.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == MyConst.Enemy)
        {
            other.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
