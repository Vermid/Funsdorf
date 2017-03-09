using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawn : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject spawn;

    private KI_HealthController ki_HealthController;
    private bool weAreDead = false;
    GameObject parent;
    void Start()
    {
        ki_HealthController = transform.parent.gameObject.GetComponent<KI_HealthController>();
        parent = GameObject.FindGameObjectWithTag(MyConst.Clones);
    }

    void Update()
    {
        bool dead = false;
        if (!weAreDead)
            dead = ki_HealthController.Dying();
        if (dead)
            weAreDead = SpawnMe();
    }

    bool SpawnMe()
    {
        float minCoins = 20;
        float maxCoins = 50;
        int howMuch;
        int i = 0;

        howMuch = Mathf.RoundToInt(Random.Range(minCoins, maxCoins));
        while (i < howMuch)
        {
            int x = Random.Range(-5, 5);
            int y = Random.Range(-5, 5);

            GameObject coinClone = (GameObject)Instantiate(spawn, transform.position, Quaternion.identity);
            coinClone.transform.parent = parent.transform;
            coinClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * Random.Range(0, moveSpeed));
            i++;
        }
        //instant Spawn
        //Instantiate(spawn, new Vector2(Random.Range(transform.position.x + 2 * 2, transform.position.x - 2 * 2), 
        //    Random.Range(transform.position.y + 2 * 2, transform.position.y - 2 * 2)), Quaternion.identity);
        return true;
    }
}