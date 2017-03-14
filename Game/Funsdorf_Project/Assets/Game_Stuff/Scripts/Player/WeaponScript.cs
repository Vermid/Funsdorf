using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    #region Inspector
    [SerializeField]
    private enum ArrowType
    {
        Single,
        Burst,
        Multi
    };
    [SerializeField]
    private ArrowType arrowType;
    [SerializeField]
    private float arrowSpeed = 300;
    [SerializeField]
    private int arrowCooldown = 3;
    [SerializeField]
    private int rapidCooldown = 5;
    [SerializeField]
    private int MultiCooldown = 5;
    [SerializeField]
    private float spaceBewteenBulletsFirst = 0.1F;
    [SerializeField]
    private float spaceBewteenBulletsSecond = 0.2F;
    [SerializeField]
    private GameObject arrow;

    #endregion


    private bool attack = true;
    private GameObject arrowClone;
    private List<GameObject> Allclones;
    private GameObject clones;
    int left = -1;
    int right = 1;
    int down = -1;
    int up = 1;
    int zero = 0;
    //private bool range = true;  Set this with the Charsheet on true or false

    void Start()
    {
        clones = GameObject.FindGameObjectWithTag(MyConst.Clones);
        Allclones = new List<GameObject>();
    }

    public void Attack(int i)
    {
        //   if (arrowType == ArrowType.Single)
        if (i == 0)
            AttackSingle();
        //  if (arrowType == ArrowType.Multi)
        if (i == 1)
           AttackMulti();
        //   if (arrowType == ArrowType.Burst)
        if (i == 2)
          AttackBurst();
    }

    public void AttackMulti()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float playerX = gameObject.transform.position.x;
        float playerY = gameObject.transform.position.y;

        if (attack && Allclones.Count < 1)
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

        if (attack && Allclones.Count <= 0)
        {
            if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y < playerY) //DOWN
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x, transform.position.y - spaceBewteenBulletsFirst), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x, transform.position.y - spaceBewteenBulletsSecond), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, down * arrowSpeed));
            }
            else if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y > playerY) //UP
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(zero, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x, transform.position.y + spaceBewteenBulletsFirst), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x, transform.position.y + spaceBewteenBulletsSecond), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, up * arrowSpeed));
            }
            else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x < playerX) //LEFT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - spaceBewteenBulletsFirst, transform.position.y), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - spaceBewteenBulletsSecond, transform.position.y), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, zero));
            }
            else if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x > playerX) //RIGHT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + spaceBewteenBulletsFirst, transform.position.y), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + spaceBewteenBulletsSecond, transform.position.y), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, zero));
            }
            else if (mousePos.x > (playerX + 0.54F) && mousePos.y > (playerY + 0.54F))//UPRIGHT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + spaceBewteenBulletsFirst, transform.position.y + spaceBewteenBulletsFirst), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + spaceBewteenBulletsSecond, transform.position.y + spaceBewteenBulletsSecond), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, up * arrowSpeed));
            }
            else if (mousePos.x > (playerX + 0.54F) && mousePos.y < (playerY - 0.54F))//DOWNRIGHT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + spaceBewteenBulletsFirst, transform.position.y - spaceBewteenBulletsFirst), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x + spaceBewteenBulletsSecond, transform.position.y - spaceBewteenBulletsSecond), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * arrowSpeed, down * arrowSpeed));
            }
            else if (mousePos.x < (playerX - 0.54F) && mousePos.y > (playerY + 0.54F)) //LEFTUP
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - spaceBewteenBulletsFirst, transform.position.y + spaceBewteenBulletsFirst), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - spaceBewteenBulletsSecond, transform.position.y + spaceBewteenBulletsSecond), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, up * arrowSpeed));
            }
            else if (mousePos.x < (playerX - 0.54F) && mousePos.y < (playerY - 0.54F)) //DOWNLEFT
            {
                arrowClone = (GameObject)Instantiate(arrow, transform.position, Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - spaceBewteenBulletsFirst, transform.position.y - spaceBewteenBulletsFirst), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed));

                arrowClone = (GameObject)Instantiate(arrow, new Vector2(transform.position.x - spaceBewteenBulletsSecond, transform.position.y - spaceBewteenBulletsSecond), Quaternion.identity);
                arrowClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(left * arrowSpeed, down * arrowSpeed));
            }
            StartCoroutine(Wait(arrowCooldown + rapidCooldown));
            attack = false;
        }
    }

    public void AttackSingle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float playerX = gameObject.transform.position.x;
        float playerY = gameObject.transform.position.y;

        if (attack && Allclones.Count < 2)
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
        Allclones.Clear();
    }

    void Update()
    {
        Debug.Log(Allclones.Count);
    }
}