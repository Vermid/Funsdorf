using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public float damage = 1;
    public int waitTime = 3;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == MyConst.Enemy)
        {
            other.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
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
    void Start()
    {
        StartCoroutine(DestroyProjektil(waitTime));
    }

    IEnumerator DestroyProjektil(int time)
    {
        yield return new WaitForSeconds(time);
                Destroy(gameObject);
    }


}
