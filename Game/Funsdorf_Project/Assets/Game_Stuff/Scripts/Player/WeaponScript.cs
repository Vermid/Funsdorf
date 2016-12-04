using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    public float damage = 1;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}