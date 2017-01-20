using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class WeaponScript : MonoBehaviour
{

    public enum ArrowType { Single, Burst, Multi };
    // public GameObject bullet;
    public ArrowType arrowType;

    public float arrowSpeed = 300;
    public int arrowCooldown = 3;
    public int rapidCooldown = 5;
    public int MultiCooldown = 5;
    private bool attack = true;
    //private bool range = true;  Set this with the Charsheet on true or false
    public GameObject arrow;
    private GameObject arrowClone;
    private List<GameObject> Allclones;
    private GameObject clones;
    int left = -1;
    int right = 1;
    int down = -1;
    int up = 1;
    int zero = 0;

    void Start()
    {
        clones = GameObject.FindGameObjectWithTag(MyConst.Clones);

    }

    public void Attack()
    {
        if (arrowType == ArrowType.Single)
            AttackSingle();

        if (arrowType == ArrowType.Multi)
            AttackMulti();

        if (arrowType == ArrowType.Burst)
            AttackBurst();
    }

    public void AttackMulti()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float playerX = gameObject.transform.position.x;
        float playerY = gameObject.transform.position.y;

        if (attack)
        {
            //call PlayerAnimation.Dash(); for the Animation
            if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y < playerY) //DOWN
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, down * arrowSpeed));//downRight

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed)); // down

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed)); //downLeft
            }
            else if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y > playerY) //UP
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));//UpLeft

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, up * arrowSpeed)); // up

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed));//UpRight
            }
            else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x < playerX) //LEFT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));//UpLeft

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero)); //left

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed));//DownLeft

            }
            else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x > playerX)
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed)); //upRight

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero));//right

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, down * arrowSpeed));//DownLeft
            }
            else if (mousePos.x > (playerX + 0.54F) && mousePos.y > (playerY + 0.54F))
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero));//right

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed)); //upRight

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, up * arrowSpeed)); // up
            }
            else if (mousePos.x > (playerX + 0.54F) && mousePos.y < (playerY - 0.54F))
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero)); //Right

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, down * arrowSpeed));//DownRight

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed)); //Down
            }
            else if (mousePos.x < (playerX - 0.54F) && mousePos.y > (playerY + 0.54F))
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero)); // Left

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));//UpLeft

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, up * arrowSpeed));//Up
            }
            else if (mousePos.x < (playerX - 0.54F) && mousePos.y < (playerY - 0.54F))
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero)); //left

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed));//DownLeft

                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed)); // down
            }
            StartCoroutine(Wait(arrowCooldown + MultiCooldown));
            attack = false;
        }
    }

    public void AttackBurst()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float playerX = gameObject.transform.position.x;
        float playerY = gameObject.transform.position.y;

        if (attack)
        {
            if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y < playerY) //DOWN
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x, transform.position.y -1), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x, transform.position.y -2) , Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed));
            }
            else if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y > playerY) //UP
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, up * arrowSpeed));
            }
            else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x < playerX) //LEFT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - 2, transform.position.y), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero));
            }
            else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x > playerX) //RIGHT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero));
            }
            else if (mousePos.x > (playerX + 0.54F) && mousePos.y > (playerY + 0.54F))//UPRIGHT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + 1, transform.position.y + 1), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + 2, transform.position.y  + 2), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed));
            }
            else if (mousePos.x > (playerX + 0.54F) && mousePos.y < (playerY - 0.54F))//DOWNRIGHT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + 1, transform.position.y - 1 ), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + 2, transform.position.y - 2), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, down * arrowSpeed));
            }
            else if (mousePos.x < (playerX - 0.54F) && mousePos.y > (playerY + 0.54F)) //LEFTUP
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - 2, transform.position.y + 2), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));
            }
            else if (mousePos.x < (playerX - 0.54F) && mousePos.y < (playerY - 0.54F)) //DOWNLEFT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - 1, transform.position.y - 1), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - 2, transform.position.y - 2), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed));
            }
        }
        StartCoroutine(Wait(arrowCooldown + rapidCooldown));
        attack = false;
    }

    public void AttackSingle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float playerX = gameObject.transform.position.x;
        float playerY = gameObject.transform.position.y;

        if (attack)
        {
            //call PlayerAnimation.Dash(); for the Animation
            if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y < playerY)
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed));
            }
            else if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y > playerY)
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, up * arrowSpeed));
            }
            else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x < playerX)
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero));
            }
            else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x > playerX)
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero));
            }
            else if (mousePos.x > (playerX + 0.54F) && mousePos.y > (playerY + 0.54F))
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed));
            }
            else if (mousePos.x > (playerX + 0.54F) && mousePos.y < (playerY - 0.54F))
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * arrowSpeed, down * arrowSpeed));
            }
            else if (mousePos.x < (playerX - 0.54F) && mousePos.y > (playerY + 0.54F))
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));
            }
            else if (mousePos.x < (playerX - 0.54F) && mousePos.y < (playerY - 0.54F))
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed));
            }

            StartCoroutine(Wait(arrowCooldown));
            attack = false;
        }
    }

    IEnumerator Wait(int waitTime)
    {
        Allclones = new List<GameObject>(GameObject.FindGameObjectsWithTag("Arrow"));

        for (int i = 0; i < Allclones.Count; i++)
        {
            Allclones[i].transform.parent = clones.transform;
        }

        yield return new WaitForSeconds(waitTime);

        attack = true;
        for (int i = 0; i < Allclones.Count; i++)
        {
            if(Allclones[i] != null)
             Destroy(Allclones[i]);
        }
    }

    IEnumerator ShootAgainTimer(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ShootAgin();

    }
    void ShootAgin()
    { 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float playerX = gameObject.transform.position.x;
        float playerY = gameObject.transform.position.y;

        //call PlayerAnimation.Dash(); for the Animation
        if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y < playerY)
        {
            arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
            arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1 * arrowSpeed));
        }
        else if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y > playerY)
        {
            arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
            arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1 * arrowSpeed));
        }
        else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x < playerX)
        {
            arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
            arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * arrowSpeed, 0));
        }
        else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x > playerX)
        {
            arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
            arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * arrowSpeed, 0));
        }
        else if (mousePos.x > (playerX + 0.54F) && mousePos.y > (playerY + 0.54F))
        {
            arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
            arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * arrowSpeed, 1 * arrowSpeed));
        }
        else if (mousePos.x > (playerX + 0.54F) && mousePos.y < (playerY - 0.54F))
        {
            arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
            arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * arrowSpeed, -1 * arrowSpeed));
        }
        else if (mousePos.x < (playerX - 0.54F) && mousePos.y > (playerY + 0.54F))
        {
            arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
            arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * arrowSpeed, 1 * arrowSpeed));
        }
        else if (mousePos.x < (playerX - 0.54F) && mousePos.y < (playerY - 0.54F))
        {
            arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
            arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * arrowSpeed, -1 * arrowSpeed));
        }
    }
}