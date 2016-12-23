using UnityEngine;
using System.Collections;

public class KI_HealthController : MonoBehaviour
{
    public float health = 2;
    private bool dead = false;
    public GameObject lootbagSpawnObject;

    public void Damage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            dead = true;
            Invoke(MyConst.Cooldown, 5);
        }
    }

    public void KI_Damage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            dead = true;
            Invoke(MyConst.Cooldown, 5);
        }
    }
    void Cooldown()
    {
        int percentageDrop;

        percentageDrop = Random.Range(1, 101);
        Debug.Log(percentageDrop);
        if (percentageDrop  >= 0)
        {
            Instantiate(lootbagSpawnObject, transform.position, Quaternion.identity);
        }//Script !!
        Destroy(gameObject);
    }

    public bool Dying()
    {
        return dead;
    }
}
