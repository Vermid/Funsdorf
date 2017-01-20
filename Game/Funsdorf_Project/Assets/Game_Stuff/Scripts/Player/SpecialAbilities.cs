using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilities : MonoBehaviour {



    public float speed = 5;
    private bool dash = true;
    private PlayerController playerController;

    private Rigidbody2D rg2;
    // Use this for initialization
    void Start ()
    {
        playerController = GetComponent<PlayerController>();
        rg2 = GetComponent<Rigidbody2D>();
    }

    public void SpAbilities()
    {
        if (dash)
            Dash();
    }

    void Dash()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        float playerX = playerController.transform.position.x;
        float playerY = playerController.transform.position.y;

        //call PlayerAnimation.Dash(); for the Animation
        if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y < playerY)
        {
            rg2.velocity = new Vector2(0, -1 * speed);
            // Call Animation Here
        }
        else if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y > playerY)
        {
            rg2.velocity = new Vector2(0, 1 * speed);
            // Call Animation Here
        }
        else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x < playerX)
        {
            rg2.velocity = new Vector2(-1 * speed, 0);
            // Call Animation Here
        }
        else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x > playerX)
        {
            rg2.velocity = new Vector2(1 * speed, 0);
            // Call Animation Here
        }
        else if (mousePos.x > (playerX + 0.54F) && mousePos.y > (playerY + 0.54F))
        {
            rg2.velocity = new Vector2(1 * (speed - 5), 1 * (speed - 5));
            // Call Animation Here
        }
        else if (mousePos.x > (playerX + 0.54F) && mousePos.y < (playerY - 0.54F))
        {
            rg2.velocity = new Vector2(1 * (speed - 5), -1 * (speed - 5));
            // Call Animation Here
        }
        else if (mousePos.x < (playerX - 0.54F) && mousePos.y > (playerY + 0.54F))
        {
            rg2.velocity = new Vector2(-1 * (speed - 5), 1 * (speed - 5));
            // Call Animation Here
        }
        else if (mousePos.x < (playerX - 0.54F) && mousePos.y < (playerY - 0.54F))
        {
            rg2.velocity = new Vector2(-1 * (speed - 5), -1 * (speed - 5));
            // Call Animation Here
        }

        Invoke("StopCharge", 0.1F);

    }


    void StopCharge()
    {
        rg2.velocity = Vector2.zero;
        dash = false;
        Invoke(MyConst.Cooldown, 5);
    }

    void Cooldown()
    {
        dash = true;
    }
}
