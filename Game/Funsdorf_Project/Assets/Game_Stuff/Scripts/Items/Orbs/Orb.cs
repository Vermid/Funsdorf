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
