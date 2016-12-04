using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour
{
    public float destroyTimer = 200;
    private HealthController healthController;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        healthController = GameObject.FindWithTag(MyConst.PlayerBody).GetComponent<HealthController>();
        Invoke(MyConst.Cooldown, destroyTimer);

        anim = GetComponent<Animator>();
        anim.SetBool("Spin",true);
        Invoke("Stop", 3);
    }

    void Cooldown()
    {
        Destroy(gameObject);
    }

    public void Stop()
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
