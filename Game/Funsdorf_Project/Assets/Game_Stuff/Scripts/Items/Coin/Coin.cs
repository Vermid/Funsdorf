using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float destroyTimer = 5;
    private PlayerController playerController;
    private Animator anim;
    private bool death = false;
    // Use this for initialization
    void Start()
    {
        playerController = GameObject.FindWithTag(MyConst.Player).GetComponent<PlayerController>();

        anim = GetComponent<Animator>();
        anim.SetTrigger("Spawn");
        Invoke("Spin", 1);
        Invoke(MyConst.Cooldown, destroyTimer);

        int waitTime = Random.Range(0, 3);
        StartCoroutine(WaittoFrezze(gameObject, 1));

    }

    void Update()
    {
        if (death)
            StartCoroutine("Wait");
    }

    void Cooldown()
    {
        death = true;
    }

    IEnumerator Wait()
    {
        death = false;
        anim.SetTrigger("Destroy");
        yield return new WaitForSeconds(1);
        if (gameObject != null)
            Destroy(gameObject);
    }

    void Spin()
    {
        anim.SetBool("Idle", true);
        Invoke("Stop", 10);
    }

    void Stop()
    {
        anim.SetBool("Idle", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == MyConst.PlayerBody)
        {
            playerController.SetCoin(1);
            Destroy(gameObject);
        }
    }

    IEnumerator WaittoFrezze(GameObject coin, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        coin.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //some error pops up sometime no idea what ? :D
    }
}

