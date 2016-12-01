using UnityEngine;
using System.Collections;

public class DotDamage : MonoBehaviour
{
    HealthController healthController;
    public bool dot = true;

    // Use this for initialization
    void Start () {
        healthController = GameObject.FindWithTag(MyConst.PlayerBody).GetComponent<HealthController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == MyConst.PlayerBody)
        {
            healthController.damageOverTime(dot);
            Destroy(gameObject);
        }
    }
}
