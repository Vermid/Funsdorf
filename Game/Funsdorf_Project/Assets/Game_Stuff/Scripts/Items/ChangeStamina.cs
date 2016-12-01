using UnityEngine;
using System.Collections;

/*  ToDo:
*   DecreaseStamina   
*/

public class ChangeStamina : MonoBehaviour
{
    public float stamina = 10;

    private PlayerController playerController;
    // Use this for initialization
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag(MyConst.Player).GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == MyConst.PlayerBody)
        {
            playerController.StaminaControl(stamina);
            Destroy(gameObject);
        }
    }
}
