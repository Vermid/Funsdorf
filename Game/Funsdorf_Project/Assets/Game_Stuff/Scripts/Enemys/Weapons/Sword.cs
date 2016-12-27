using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    public float damage = 1;
    private HealthController healthController;
    // Use this for initialization
    void Start()
    {
        healthController = GameObject.FindGameObjectWithTag(MyConst.PlayerBody).GetComponent<HealthController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == MyConst.PlayerBody)
            healthController.Damage(damage);
    }
}
