using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour
{
    public int potion = 1;

    HealthController healthController;
    // Use this for initialization
    void Start ()
    {
         healthController = GameObject.FindWithTag(MyConst.PlayerBody).GetComponent<HealthController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == MyConst.PlayerBody)
        {
            healthController.PotionControl(potion);
            Destroy(gameObject);
        }
    }
}
