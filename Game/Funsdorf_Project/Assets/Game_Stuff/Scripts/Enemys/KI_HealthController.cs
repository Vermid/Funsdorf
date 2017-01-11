using UnityEngine;
using System.Collections;

public class KI_HealthController : MonoBehaviour
{
    public float health = 2;
    private bool dead = false;
    public GameObject spawn;

    public void Damage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            dead = true;
            Invoke(MyConst.Cooldown, 1);
        }
    }

    public void KI_Damage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            dead = true;
            Invoke(MyConst.Cooldown, 1);
        }
    }
    void Cooldown()
    {
        GameObject itemBag = (GameObject)Instantiate(spawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public bool Dying()
    {
        return dead;
    }
}
