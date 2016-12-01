using UnityEngine;
using System.Collections;


/* ToDo
*   Dot Dmg stop when you dont move 
*/

public class HealthController : MonoBehaviour
{
    public float health = 10;
    private float startHealth;

    public float lifePoints = 5;
    private float startLifePoints;

    public float potion = 1;
    public float potionHp = 10;

    private bool damageAble = true;

    public Transform playerSpawnPoint;
    PlayerController playerController;

    void Start ()
    {
        GetStartValues();
       // playerController = GameObject.FindGameObjectWithTag(MyConst.player).GetComponent<PlayerController>();
        playerController = transform.parent.gameObject.GetComponent<PlayerController>();
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
            Dying(damage);
            Invoke(MyConst.GetDamage, 0.5F);

            if (health <= 0)
            {
                playerController.enabled = false;
                lifePoints--;
                health = startHealth;

                //where to spawn
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

    public void PotionControl(int pot)
    {
        potion += pot;
    }
    public bool AddHealth()
    {
        if (potion >= 1 && health != startHealth)
        {
            health += potionHp;
            health = Mathf.Min(startHealth, health);
            potion--;
            return true;
        }
        else
            return false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        float dmg = (Time.deltaTime / 4);
        if (other.gameObject.tag == "Fire")
            Dying(dmg);
    }

    void Dying(float damage)
    {
        health -= damage;
    }
    void SetSpawn()
    {
        playerController.enabled = true;
        playerController.PlayerSpawn();
    }
    void GetDamage()
    {
        damageAble = true;
    }
}