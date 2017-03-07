using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour
{
    public float destroyTimer = 5;
    private HealthController healthController;
    private Animator anim;
    private bool death = false;
    // Use this for initialization
    void Start()
    {
        healthController = GameObject.FindGameObjectWithTag(MyConst.Player).GetComponentInChildren<HealthController>();

        anim = GetComponent<Animator>();
        anim.SetTrigger("Spawn");
        Invoke("Spin", 1);
        Invoke(MyConst.Cooldown, 5);

        int waitTime = Random.Range(0, 2);
        StartCoroutine(WaittoFrezze(gameObject, waitTime));
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
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(destroyTimer);
        if (gameObject != null)
            Destroy(gameObject);
    }

    IEnumerator WaittoFrezze(GameObject orb, int waitTime)
    {
        var myOldTransform = transform.localPosition;
        yield return new WaitForSeconds(waitTime);
            orb.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //some error pops up sometime no idea what ? :D
           // gameObject.transform.localPosition.transform.localPosition = myOldTransform;

    }


    void Spin()
    {
        anim.SetBool("Spin", true);
        Invoke("Stop", 3);
    }

    void Stop()
    {
        anim.SetBool("Spin", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == MyConst.PlayerBody)
        {
            healthController.SetOrbs(1);
            Destroy(gameObject);
        }
    }
}
