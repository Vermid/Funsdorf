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
	void Start ()
    {
        playerController = GameObject.FindGameObjectWithTag(MyConst.player).GetComponent<PlayerController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == MyConst.player)
        {
            playerController.StaminaControl(stamina);
            Destroy(gameObject);
        }
    }
}
