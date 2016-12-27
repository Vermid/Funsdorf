using UnityEngine;
using System.Collections;

public class HealthOrb : MonoBehaviour
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
            weAreDead= SpawnMe();
    }

    bool SpawnMe()
    {
        float minOrbs = 1;
        float maxOrbs = 5;
        int howMuch;
        int i = 0;

        howMuch = Mathf.RoundToInt(Random.Range(minOrbs, maxOrbs));

        while (i < howMuch)
        {
            int waitTime = Random.Range(0, 5);     
            int x = Random.Range(-10, 10);
            int y = Random.Range(-10, 10);
            int z =Random.Range(0, 5);
            z = (z >= 2) ? 1 : -1;

            GameObject orbClone = (GameObject)Instantiate(spawn, transform.position, Quaternion.identity);
            orbClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * Random.Range(0, moveSpeed));
            i++;
            StartCoroutine(Wait(orbClone, waitTime));
        }

        //instant Spawn
        //Instantiate(spawn, new Vector2(Random.Range(transform.position.x + 2 * 2, transform.position.x - 2 * 2), 
        //    Random.Range(transform.position.y + 2 * 2, transform.position.y - 2 * 2)), Quaternion.identity);
        return true;
    }

    IEnumerator Wait(GameObject orbClone, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if(orbClone != null)
            orbClone.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //some error pops up sometime no idea what ? :D
    }
}
