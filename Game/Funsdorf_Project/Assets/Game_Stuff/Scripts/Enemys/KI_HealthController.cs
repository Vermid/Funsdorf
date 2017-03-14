using UnityEngine;
using System.Collections;

public class KI_HealthController : MonoBehaviour
{
    public float health = 2;
    private bool dead = false;
    public GameObject spawn;
    private EnemyMovementController enemyMovementController;

    void Start()
    {
        enemyMovementController = gameObject.GetComponent<EnemyMovementController>();
    }
    public void Damage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            dead = true;
            enemyMovementController.StopME();
            Invoke(MyConst.Cooldown, 1);
        }
    }

    void Cooldown()
    {
        int i = Random.Range(0, 101);
        if (i > 75)
        {
            GameObject itemBag = (GameObject)Instantiate(spawn, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public bool Dying()
    {
        return dead;
    }
}
