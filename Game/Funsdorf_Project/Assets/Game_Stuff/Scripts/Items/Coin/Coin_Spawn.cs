using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawn : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject spawn;

    private KI_HealthController ki_HealthController;
    private bool weAreDead = false;

    void Start()
    {
        ki_HealthController = transform.parent.gameObject.GetComponent<KI_HealthController>();
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
            int waitTime = Random.Range(0, 5);
            int x = Random.Range(-5, 5);
            int y = Random.Range(-5, 5);

            GameObject coinClone = (GameObject)Instantiate(spawn, transform.position, Quaternion.identity);
            coinClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * Random.Range(0, moveSpeed));
            i++;
            StartCoroutine(Wait(coinClone, waitTime));
        }

        //instant Spawn
        //Instantiate(spawn, new Vector2(Random.Range(transform.position.x + 2 * 2, transform.position.x - 2 * 2), 
        //    Random.Range(transform.position.y + 2 * 2, transform.position.y - 2 * 2)), Quaternion.identity);
        return true;
    }

    IEnumerator Wait(GameObject coinClone, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (coinClone != null)
            coinClone.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //some error pops up sometime no idea what ? :D
    }
}