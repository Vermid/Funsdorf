using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    public float health = 10;
    private float startHealth;

    public float lifePoints = 5;
    private float startLifePoints;
    private bool damageAble = true;

    public Transform playerSpawnPoint;
    PlayerController playerController;

    // Use this for initialization
    void Start ()
    {
        GetStartValues();
        playerController = GameObject.FindGameObjectWithTag(MyConst.player).GetComponent<PlayerController>();
    }

    void GetStartValues()
    {
        startHealth = health;
        startLifePoints = lifePoints;
    }

    public void Damage(float damage)
    {
        if (damageAble)
        {
            //SetAnimHit
            damageAble = false;
            health -= damage;
            Invoke(MyConst.GetDamage, 0.5F);

            if (health == 0)
            {
                playerController.enabled = false;
                lifePoints--;
                health = startHealth;

                //where to spawn
                transform.position = playerSpawnPoint.position;
                Invoke(MyConst.SetSpawn, 2);
            }
        }
        if(lifePoints == 0)
        {
            //SetAnimDead
            playerController.enabled = false;
            lifePoints = startLifePoints; 
        }
    }

    void SetSpawn()
    {
        playerController.enabled = true;
    }
    void GetDamage()
    {
        damageAble = true;
    }
}