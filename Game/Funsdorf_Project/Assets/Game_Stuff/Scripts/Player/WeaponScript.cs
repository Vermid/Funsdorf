using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    public float damage = 1;
    //Things to delete
    KI_HealthController kiHealthController;

    void Start()
    {
        //Delete me
        kiHealthController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<KI_HealthController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
            kiHealthController.Damage(damage);
    }
}