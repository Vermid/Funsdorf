using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour
{
    public int potion = 1;

    HealthController healthController;

    // Use this for initialization
    void Start ()
    {
         healthController = GameObject.FindGameObjectWithTag(MyConst.player).GetComponent<HealthController>();
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == MyConst.player)
        {
            healthController.PotionControl(potion);
            Destroy(gameObject);
        }
    }
}
